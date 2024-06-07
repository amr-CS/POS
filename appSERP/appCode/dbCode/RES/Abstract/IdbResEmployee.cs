using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.RES.Abstract
{
    public interface IdbResEmployee
    {
        string funResEmployeeGET(
        int? pResEmployeeId = null,
        string pResEmployeeCode = null,
        int? pEmpSeq = null,
        int? Credit = null,
        string pResEmployeeNameL1 = null,
        string pResEmployeeNameL2 = null,
        DateTime? pHireDate = null,
        int? pDeptSeq = null,
        int? pEmpStatusId = null,
        DateTime? pExitDate = null,
        string pAddress = null,
        DateTime? pBirthDate = null,
        string pMobile = null,
        int? pGender = null,
        int? pIdentityTypeId = null,
        int? pIdentityNumber = null,
        DateTime? pIdentityDate = null,
        int? pNationalityId = null,
        decimal? pDeliveryValue = null,
        int? pValueTypeId = null,
        decimal? pPercentageRange = null,
        int? pExitTypeId = null,
        string pExitReason = null,
        bool? pResEmployeeIsActive = null,
        bool? pIsDeleted = null,
        int? pCreatedBy = null,
        DateTime? pCreatedOn = null,
        int? pLastUpdatedBy = null,
        DateTime? pLastUpdatedOn = null,
        int? pLanguageId = null,
        int? pQueryTypeId = null,
        string pLstNationality = null,
        string pLstIdentityType = null,
        string pLstEmpStatus = null,
        string pLstValueType = null,
        string pLstExitType = null,
        int? UserId = null


        );

        DataTable funGetResEmployeeReport(bool? pIsActive = null);
    }
}
