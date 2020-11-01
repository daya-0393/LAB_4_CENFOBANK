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
using System.Web.Http.Results;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class CustomerController : ApiController
    {


        // GET api/customer
        // Retrieve all
        public IHttpActionResult Get()
        {
            var mng = new CustomerManager();
            List<Customer> customerList = mng.RetrieveAll();
            if (customerList == null)
            {
                return Content(HttpStatusCode.NotFound, "No se ha encontrado");
            }
            return Ok(customerList);
        }
        public IHttpActionResult Get(string id)
        {
            var mng = new CustomerManager();
            var customer = new Customer
            {
                Id = id
            };
            customer = mng.RetrieveById(customer);
            if (customer == null)
            {
                return Content(HttpStatusCode.NotFound, "No se ha encontrado");
            }
            return Ok(customer);
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Customer customer)
        {
            try
            {
                var mng = new CustomerManager();
                mng.Create(customer);
                return Content(HttpStatusCode.OK, "USUARIO REGISTRADO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL REGISTRAR");
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Customer customer)
        {
            try
            {
                var mng = new CustomerManager();
                mng.Update(customer);
                return Content(HttpStatusCode.OK, "USUARIO ACTUALIZADO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL ACTUALIZAR");
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Customer customer)
        {
            try
            {
                var mng = new CustomerManager();
                mng.Delete(customer);
                return Content(HttpStatusCode.OK, "USUARIO ELIMINADO");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return Content(HttpStatusCode.BadRequest, "ERROR AL ELIMINAR");
            }
        }
    }
}
