using CoreAPI;
using Entities_POJO;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class AccountController : ApiController
    {

        // GET api/account
        // Retrieve all
        public IHttpActionResult Get()
        {
            var mng = new AccountManager();
            List<Account> accountList = mng.RetrieveAll();
            if (accountList == null)
            {
                return Content(HttpStatusCode.NotFound, "No se ha encontrado");
            }
            return Ok(accountList);
        }

        public IHttpActionResult Get(Account account)
        {
            var mng = new AccountManager();

            List<Account> accounList = mng.RetrieveById(account);
            if (accounList == null)
            {
                return Content(HttpStatusCode.NotFound, "No se ha encontrado");
            }
            return Ok(accounList);
        }

        public IHttpActionResult Post(Account account)
        {
            try
            {
                var mng = new AccountManager();
                mng.Create(account);
                return Content(HttpStatusCode.OK, "CUENTA REGISTRADO");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL REGISTRAR");
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Account account)
        {
            try
            {
                var mng = new AccountManager();
                mng.Update(account);
                return Content(HttpStatusCode.OK, "CUENTA ACTUALIZADA");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL ACTUALIZAR");
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Account account)
        {
            try
            {
                var mng = new AccountManager();
                mng.Delete(account);
                return Content(HttpStatusCode.OK, "CUENTA ELIMINADA");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL ELIMINAR");
            }
        }
    }
}
