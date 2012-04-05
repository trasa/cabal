using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Cabal.Core.Helpers
{
    // egads!  inspired by http://www.c-sharpcorner.com/Blogs/BlogDetail.aspx?BlogId=863
    // where inspired is roughly equivalent to 'copied.'
    public class JsonFilter : ActionFilterAttribute
    {
        public string Param { get; set; }
        public Type RootType { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object o;
            var reader = new StreamReader(filterContext.HttpContext.Request.InputStream);
            string data = reader.ReadToEnd();
            Stream s = new MemoryStream(Encoding.UTF8.GetBytes(data));
            if ((filterContext.HttpContext.Request.ContentType ?? string.Empty).Contains("application/json"))
            {
                o = DeserializeJson(s);
            }
            else
            {
                o = DeserializeXml(s, filterContext.HttpContext.Request.ContentEncoding);
            }
            filterContext.ActionParameters[Param] = o;
        }

        public object DeserializeJson(Stream stream)
        {
            var serializer = new DataContractJsonSerializer(RootType);
            return serializer.ReadObject(stream);
        }

        public object DeserializeXml(Stream stream, Encoding encoding)
        {
            var xmlRoot = XElement.Load(new StreamReader(stream, encoding));
            return new XmlSerializer(RootType).Deserialize(xmlRoot.CreateReader());
        }
    }
}
