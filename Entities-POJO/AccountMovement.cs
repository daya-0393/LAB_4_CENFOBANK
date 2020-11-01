using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class AccountMovement : BaseEntity
    {
        public int MovementId { get; set; } 
        public int AccountNum { get; set; }
        public DateTime Date { get; set; }
        public char MovType { get; set; }
        public double Amount { get; set; }
        public string UserId { get; set; }


        public AccountMovement()
        {
        }

        public AccountMovement(string[] accMovementInfo, int accNum, string userId)
        {
            if (accMovementInfo != null && accNum != 0)
            {
                UserId = userId;
                AccountNum = Convert.ToInt32(accNum);
                Date = Convert.ToDateTime(accMovementInfo[0]);
                MovType = Convert.ToChar(accMovementInfo[1]);
                Amount = Convert.ToDouble(accMovementInfo[2]);
            }
            else
            {
                throw new Exception("Todos los valores son requeridos");
            }

        }
    }
}
