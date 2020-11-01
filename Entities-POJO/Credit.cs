using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Credit : BaseEntity
    {
        public int CreditId { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public double InterestRate { get; set; }
        public string CreditLine { get; set; }
        public double Fee { get; set; }
        public DateTime StartDate { get; set; }
        public char Status { get; set; }
        public double Balance { get; set; }


        public Credit()
        {
        }

        public Credit(string[] creditsInfo, string userId)
        {
            if (creditsInfo != null && userId != null )
            {
                UserId = userId;
                Amount = Convert.ToInt32(creditsInfo[0]);
                InterestRate = Convert.ToInt32(creditsInfo[1]);
                CreditLine = creditsInfo[2];
                Fee = Convert.ToInt32(creditsInfo[3]);
                StartDate = Convert.ToDateTime(creditsInfo[4]);
                Status = Convert.ToChar(creditsInfo[5]);
            }
            else
            {
                throw new Exception("Todos los valores son requeridos");
            }

        }
    }
}
