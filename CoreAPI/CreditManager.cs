using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using DataAcess.Crud;

namespace CoreAPI
{
    public class CreditManager
    {
        private CreditCrudFactory crudCredit;

        public CreditManager()
        {
            crudCredit = new CreditCrudFactory();
        }

        public void Create(Credit credit)
        {
            try
            {
                crudCredit.Create(credit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Credit> RetrieveAll()
        {
            return crudCredit.RetrieveAll<Credit>();
        }

        public List<Credit> RetrieveById(Credit credit)
        {
            return crudCredit.RetrieveById<Credit>(credit);
        }

        public void Update(Credit credit)
        {
            crudCredit.Update(credit);
        }

        public void Delete(Credit credit)
        {
            crudCredit.Delete(credit);
        }
    }
}
