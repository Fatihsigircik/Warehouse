using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.ServiceModel.Channels;

namespace DatabaseServer.Helper
{
    internal class GeneralHelper
    {
        internal enum StatusType
        {
            Success,
            Error,
        }

        internal static object GetMessage<T>(IEnumerable data, string message, StatusType statusType, string specialMessage = "")
        {
            return new
            {
                Status = statusType.ToString(),
                Model = typeof(T).Name,
                Message = message,
                Data = data ?? new List<object>(),
                SpecialMessage = specialMessage
            };
        }

        internal static string GetClientIp()
        {
            var serverVariables = HttpContext.Current.Request.ServerVariables;
            return (serverVariables["HTTP_X_FORWARDED_FOR"] ?? serverVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
        }

        internal static string GetClientIp(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                var prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            return HttpContext.Current != null ? HttpContext.Current.Request.UserHostAddress : null;
        }


        internal static T ConvertType<T>(object o) where T : class,new()
        {
            var ent = Activator.CreateInstance<T>();
            var properties = ent.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (o.GetType().GetProperty(property.Name) != null)
                {
                    property.SetValue(ent,o.GetType().GetProperty(property.Name).GetValue(o,null));
                }
            }

            return ent;
        }

        internal static void SetFields<T>(T from,ref T to) where T : class, new()
        {
             
            var properties = to.GetType().GetProperties();
            foreach (var property in properties)
            {
                property.SetValue(to, from.GetType().GetProperty(property.Name).GetValue(from, null));
            }
        }
    }
}