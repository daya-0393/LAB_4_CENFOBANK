
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
    public class AccountManager
    {
        private AccountCrudFactory crudAccount;

        public AccountManager()
        {
            crudAccount = new AccountCrudFactory();
        }

        public void Create(Account account)
        {
            try
            {
                if(account.Type == "A" || account.Type == "C")
                {
                    crudAccount.Create(account);
                }
                else
                {
                    throw new Exception("Valores de Tipo de cuenta incorrectos");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Account> RetrieveAll()
        {
            return crudAccount.RetrieveAll<Account>();
        }

        public List<Account> RetrieveById(Account account)
        {
            return crudAccount.RetrieveById<Account>(account);
        }

        public void Update(Account account)
        {
            crudAccount.Update(account);
        }

        public void Delete(Account account)
        {
            crudAccount.Delete(account);
        }
    }
}
