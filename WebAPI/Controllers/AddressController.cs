using CenfoBank_client;
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
    public class AddressController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        public IHttpActionResult Get()
        {

            apiResp = new ApiResponse();
            var mng = new AddressManager();
            apiResp.Data = mng.RetrieveAll();

            return Ok(apiResp);
        }

        //Retrieves id of address object
        public IHttpActionResult Get(Address address)
        {
            var mng = new AddressManager();
            int addressId = mng.RetrieveId(address);

            return Ok(addressId);
        }

        // POST 
        // CREATE
        public IHttpActionResult Post(Address address)
        {

            try
            {
                var mng = new AddressManager();
                mng.Create(address);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }

        // PUT
        // UPDATE
        public IHttpActionResult Put(Address address)
        {
            try
            {
                var mng = new AddressManager();
                mng.Update(address);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

        // DELETE ==
        public IHttpActionResult Delete(Address address)
        {
            try
            {
                var mng = new AddressManager();
                mng.Delete(address);

                apiResp = new ApiResponse();
                apiResp.Message = "Action was executed.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}
