using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreAPI;
using Entities_POJO;

namespace WebAPI.Controllers
{
    public class CreditController : ApiController
    {
        // Retrieve all
        public IHttpActionResult Get()
        {
            var mng = new CreditManager();
            List<Credit> creditList = mng.RetrieveAll();
            if (creditList == null)
            {
                return Content(HttpStatusCode.NotFound, "Not found");
            }
            return Ok(creditList);
        }

        public IHttpActionResult Get(Credit credit)
        {
            var mng = new CreditManager();

            List<Credit> accounList = mng.RetrieveById(credit);
            if (accounList == null)
            {
                return Content(HttpStatusCode.NotFound, "Not found");
            }
            return Ok(accounList);
        }

        public IHttpActionResult Post(Credit credit)
        {
            try
            {
                var mng = new CreditManager();
                mng.Create(credit);
                return Content(HttpStatusCode.OK, "CREDITO REGISTRADO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL REGISTRAR");
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Credit credit)
        {
            try
            {
                var mng = new CreditManager();
                mng.Update(credit);
                return Content(HttpStatusCode.OK, "CREDITO ACTUALIZADO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL ACTUALIZAR");
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Credit credit)
        {
            try
            {
                var mng = new CreditManager();
                mng.Delete(credit);
                return Content(HttpStatusCode.OK, "CREDITO ACTUALIZADO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL ELIMINAR");
            }
        }
    }
}
