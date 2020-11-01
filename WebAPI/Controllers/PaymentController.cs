using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace WebAPI.Controllers
{
    public class PaymentController : ApiController
    {
        public IHttpActionResult Get()
        {
            var mng = new PaymentManager();
            List<Payment> paymentList = mng.RetrieveAll();
            if (paymentList == null)
            {
                return Content(HttpStatusCode.NotFound, "Not found");
            }
            return Ok(paymentList);
        }

        public IHttpActionResult Get(Payment payment)
        {
            var mng = new PaymentManager();

            List<Payment> accounList = mng.RetrieveById(payment);
            if (accounList == null)
            {
                return Content(HttpStatusCode.NotFound, "Not found");
            }
            return Ok(accounList);
        }

        public IHttpActionResult Post(Payment payment)
        {
            try
            {
                var mng = new PaymentManager();
                mng.Create(payment);
                return Ok("Pago registrado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Payment payment)
        {
            try
            {
                var mng = new PaymentManager();
                mng.Update(payment);
                return Ok("Pago actualizada");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Payment payment)
        {
            try
            {
                var mng = new PaymentManager();
                mng.Delete(payment);
                return Ok("Pago eliminado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }
    }
}
