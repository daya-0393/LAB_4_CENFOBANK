using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities_POJO;
using DataAcess.Crud;

namespace CoreAPI
{
    public class PaymentManager
    {
        private PaymentCrudFactory crudPayment;
        private CreditCrudFactory creditCrud;
        Credit credit = new Credit();

        public PaymentManager()
        {
            crudPayment = new PaymentCrudFactory();
            creditCrud = new CreditCrudFactory();
        }

        public void Create(Payment payment)
        {
            try
            {
                credit.CreditId = payment.CreditId;
                credit.UserId = payment.UserId;
                var creditBalance = (creditCrud.Retrieve<Credit>(credit).Balance);
                if ((creditBalance - payment.Amount) >= 0)
                {
                    crudPayment.Create(payment);
                }
                else
                {
                    throw new Exception("El pago excede el saldo");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Payment> RetrieveAll()
        {
            return crudPayment.RetrieveAll<Payment>();
        }

        public List<Payment> RetrieveById(Payment payment)
        {
            return crudPayment.RetrieveById<Payment>(payment);
        }

        public void Update(Payment payment)
        {
            crudPayment.Update(payment);
        }

        public void Delete(Payment payment)
        {
            crudPayment.Delete(payment);
        }
    }
}
