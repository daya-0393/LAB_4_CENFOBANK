using CoreAPI;
using Entities_POJO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;


namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class AccountMovController : ApiController
    {
        // Retrieve all
        public IHttpActionResult Get()
        {
            var mng = new AccountMovManager();
            List<AccountMovement> accountMovList = mng.RetrieveAll();
            if (accountMovList == null)
            {
                return Content(HttpStatusCode.NotFound, "No se ha encontrado");
            }
            return Ok(accountMovList);
        }
        //Retrieve By Id
        public IHttpActionResult Get(AccountMovement accountMov)
        {
            var mng = new AccountMovManager();

            List<AccountMovement> accounList = mng.RetrieveById(accountMov);
            if (accounList == null)
            {
                return Content(HttpStatusCode.NotFound, "No se ha encontrado");
            }
            return Ok(accounList);
        }

        public IHttpActionResult Post(AccountMovement accountMov, Account account)
        {
            try
            {
                var mng = new AccountMovManager();
                mng.Create(accountMov, account);
                return Content(HttpStatusCode.OK, "MOVIMIENTO BANCARIO REGISTRADO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL REGISTRAR");
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(AccountMovement accountMov)
        {
            try
            {
                var mng = new AccountMovManager();
                mng.Update(accountMov);
                return Content(HttpStatusCode.OK, "MOVIMIENTO BANCARIO ACTUALIZADO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL ACTUALIZAR");
            }
        }

        // DELETE
        public IHttpActionResult Delete(AccountMovement accountMov)
        {
            try
            {
                var mng = new AccountMovManager();
                mng.Delete(accountMov);
                return Content(HttpStatusCode.OK, "MOVIMIENTO BANCARIO ELIMINADO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL ELIMINAR");
            }
        }
    }
}