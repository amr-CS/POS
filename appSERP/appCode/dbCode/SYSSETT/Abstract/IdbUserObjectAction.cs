using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SYSSETT.Abstract
{
    public interface IdbUserObjectAction
    {

         string funUserObjectActionGET(
         int? pUserObjectActionId = null, int? pUserObjectActionSeq = null, int? pUserId = null, int? pObjectId = null, string pObjectProName = null,
         int? pObjectAction = null, int? pObjectActionId = null, bool? pObjectIsAdmin = null, bool? pIsDeleted = null, int? pQueryTypeId = null);

        DataTable funUserObjectGET(int UserId);

        DataTable funUserObjectTypeGET(DataTable pDtObject);

        DataTable funUserSystemGET(DataTable pDtObjectType);


        string vSystemMessage { get; set; }
        int vSystemMessageTypeId { get; set; }
    }
}
