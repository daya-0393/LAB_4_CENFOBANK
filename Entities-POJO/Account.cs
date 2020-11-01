using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Account : BaseEntity
    {
        public int AccountNum { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string Currency { get; set; }
        public int Balance { get; set; }

        public Account()
        {

        }

        public Account(string[] accountInfo, int accNum)
        {
            if (accountInfo != null && accountInfo.Length >= 3)
            {
                AccountNum = accNum;
                UserId = accountInfo[0];
                Type = accountInfo[1];
                Currency = accountInfo[2];
                Balance = Convert.ToInt32(accountInfo[3]);
            }
            else
            {
                throw new Exception("Todos los valores son requeridos");
            }

        }
    }
}
