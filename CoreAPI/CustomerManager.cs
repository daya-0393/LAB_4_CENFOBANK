
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class CustomerManager 
    {
        private CustomerCrudFactory crudCustomer;

        public CustomerManager()
        {
            crudCustomer = new CustomerCrudFactory();
        }

        public void Create(Customer customer)
        {
            try
            {
                var c = crudCustomer.Retrieve<Customer>(customer);

                if (c != null)
                {
                    //Customer already exist
                    throw new Exception("El usuario ya existe");
                }

                if (customer.Age >= 18)
                    crudCustomer.Create(customer);
                else
                {
                    throw new Exception("Debe ser mayor de edad");
                }
            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Customer> RetrieveAll()
        {
            return crudCustomer.RetrieveAll<Customer>();
        }

        public Customer RetrieveById(Customer customer)
        {
            Customer c=null;
            try
            {
                c = crudCustomer.Retrieve<Customer>(customer);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch(Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Customer customer)
        {
            crudCustomer.Update(customer);
        }

        public void Delete(Customer customer)
        {
            crudCustomer.Delete(customer);
        }
    }
}
