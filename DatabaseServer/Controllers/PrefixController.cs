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
    public class PrefixController : ApiController
    {
        public IHttpActionResult GetPrefix(string prefix)
        {
            object obj;
            try
            {
                var currentPrefix = new Repository<string>().GetMethod("GetPrefix", prefix);
                var data = currentPrefix.Select(q => q).ToList();
                if (data == null || data.Count == 0)
                    throw new Exception($"{prefix} Prefixi İle Kayıt Bulunamadı...");
                obj = GeneralHelper.GetMessage<Prefix>(data, Messages.SUCCESS_GET,
                   GeneralHelper.StatusType.Success, $"{data.Count()} Adet Kayıt Bulundu.");

            }
            catch (Exception e)
            {
                obj = GeneralHelper.GetMessage<Prefix>(null, Messages.ERROR_GET,
                   GeneralHelper.StatusType.Error, e.Message);
            }
            return Json(obj);
        }
    }
}
