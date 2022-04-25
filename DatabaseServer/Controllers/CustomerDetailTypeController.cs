using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using DatabaseServer.Filters;
using DatabaseServer.Helper;

namespace DatabaseServer.Controllers
{
    [JwtAuthentication]
    public class CustomerDetailTypeController : ApiController
    {
        public IHttpActionResult Get()
        {
            var customerDetailTypes = new Repository<CustomerDetailType>().Get().ToList();
            return Json(GeneralHelper.GetMessage<CustomerDetailType>(customerDetailTypes, Messages.SUCCESS_GET, GeneralHelper.StatusType.Success, $"{customerDetailTypes.Count} Adet Kayıt Bulundu."));
        }
    }
}
