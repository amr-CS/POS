using appSERP.Logger;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.appCode
{
    [Serializable]
    public class ExceptionWrapper: OnExceptionAspect
    {
        private ILog _ILog;
        public ExceptionWrapper(ILog log)
        {
            _ILog = log;
        }

        public override void OnException(MethodExecutionArgs args)
        {
            _ILog.LogException(args.Exception.ToString());
        }
    }
}