using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.Setting.APISetting.Abstract
{
    public interface IclsAPI
    {
        string funAPIBaseURL();
        Task<string> RunAsync(string pPath);
        DataTable funResultGet(string pPath);
        string funResultGetJSON(string pPath);
    }
}
