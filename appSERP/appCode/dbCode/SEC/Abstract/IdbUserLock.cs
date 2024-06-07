using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbUserLock
    {
        string funUserLockGET(
            int? pUserLockId = null,
            int? pUserId = null,
            string pDevice = "",
            DateTime? pLastLoginTime = null,
            int? pQueryTypeId = null);

        string vSystemMessage { get; set; }
        int vSystemMessageTypeId { get; set; }
    }
}
