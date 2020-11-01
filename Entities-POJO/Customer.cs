using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Customer : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public char CivilStatus { get; set; }
        public char Gender { get; set; }
        public int AddressId { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set;}
        public string Distrito { get; set;}



        public Customer()
        {

        }

        public Customer(string[] customerInfo, int addressId)
        {
            if (customerInfo != null && customerInfo.Length >= 7)
            {
                Id = customerInfo[0];
                Name = customerInfo[1];
                LastName = customerInfo[2];
                BirthDate = Convert.ToDateTime(customerInfo[3]);
                CivilStatus = Convert.ToChar(customerInfo[5]);
                Gender = Convert.ToChar(customerInfo[6]);
                AddressId = addressId;

                var age = 0;
                if (Int32.TryParse(customerInfo[4], out age))
                    Age = age;
                else
                    throw new Exception("La edad debe ser un numero");
            }
            else
            {
                throw new Exception("Todos los valores son requeridos");
            }

        }

    }
}
