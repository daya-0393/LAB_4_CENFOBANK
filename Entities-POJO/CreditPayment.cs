using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    class CreditPayment
    {

        public int CreditId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Amount { get; set; }

        public CreditPayment()
        {
        }

        public CreditPayment(string[] creditPaymentInfo)
        {
            if (creditPaymentInfo != null && creditPaymentInfo.Length == 7)
            {
                CreditId = Convert.ToInt32(creditPaymentInfo[0]);
                PaymentDate = Convert.ToDateTime(creditPaymentInfo[1]);
                Amount = Convert.ToInt32(creditPaymentInfo[2]);
            }
            else
            {
                throw new Exception("Todos los valores son requeridos");
            }

        }

    }
}
