﻿using System;
using System.Web;
using System.Xml;

namespace Amalay.HttpHandler
{
    public class RssHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";

            using (XmlWriter xmlWriter = XmlWriter.Create(context.Response.OutputStream))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteElementString("Rss", "Amalay Http Handler RSS Feed!");
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();
            }
        }

        #endregion
    }
}
