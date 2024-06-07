using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.SEC.Abstract
{
    public interface IdbUserGroup
    {
       string funUserGroupGET(
       int? pUserGroupId = null,
       int? pUserId = null,
       int? pGroupId = null,
       bool? pIsDeleted = null,
       int? pCreatedBy = null,
       DateTime? pCreatedOn = null,
       int? pLastUpdatedBy = null,
       DateTime? pLastUpdatedOn = null,
       int? pLanguageId = null,
       int? pQueryTypeId = null);
    }
}
