using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP
{
    public class ViewAsPdf2 : PartialViewAsPdf
    {
        public ViewAsPdf2(string viewName) : base(viewName) { }
        public byte[] GetByte(ControllerContext context)
        {
            base.PrepareResponse(context.HttpContext.Response);
            base.ExecuteResult(context);
            return base.CallTheDriver(context);

        }
    }
}