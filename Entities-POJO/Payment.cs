using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Payment : BaseEntity
    {
        public DateTime PaymentDate { get; set; }
        public int Amount { get; set; }
        public int CreditId { get; set; }
        public string UserId {get; set;}

        public Payment()
        {

        }

        public Payment(string[] paymentInfo, int creditId, string userId)
        {
            if (paymentInfo != null && creditId != 0)
            {
                PaymentDate = Convert.ToDateTime(paymentInfo[0]);
                Amount = Convert.ToInt32(paymentInfo[1]);
                CreditId = creditId;
                UserId = userId;
            }
            else
            {
                throw new Exception("Todos los valores son requeridos");
            }

        }
    }
}
