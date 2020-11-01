
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
    public class AccountMovManager
    {
        private AccMovCrudFactory crudAccountMov;
        private AccountCrudFactory accountCrud;
        Account account = new Account();

        public AccountMovManager()
        {
            crudAccountMov = new AccMovCrudFactory();
            accountCrud = new AccountCrudFactory();
        }

        public void Create(AccountMovement accountMov, Account account)
        {
            try
            {
                account.AccountNum = accountMov.AccountNum;
                account.UserId = accountMov.UserId;
                var accountBalance = (accountCrud.Retrieve<Account>(account)).Balance;
                if((accountBalance - accountMov.Amount) >= 0)
                {
                    crudAccountMov.Create(accountMov);
                }
                else
                {
                    throw new Exception("Fondos insuficientes");
                }

            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public List<AccountMovement> RetrieveAll()
        {
            return crudAccountMov.RetrieveAll<AccountMovement>();
        }

        public List<AccountMovement> RetrieveById(AccountMovement accountMov)
        {
            return crudAccountMov.RetrieveById<AccountMovement>(accountMov);
        }

        public void Update(AccountMovement accountMov)
        {
            crudAccountMov.Update(accountMov);
        }

        public void Delete(AccountMovement accountMov)
        {
            crudAccountMov.Delete(accountMov);
        }
    }
}
