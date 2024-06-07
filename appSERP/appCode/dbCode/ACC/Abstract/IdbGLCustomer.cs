using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbGLCustomer
    {
        string funGLCustomerGET(
         int? pCustomerId = null,
       string pCustomerCode = null,
         string pCustomerSequence = null,
         int? pDelivaryCompanyType = null,
         float? pDelivaryCompanyValue = null,
         string pSeqByType = null,
         string pCustomerNameL1 = null,
         string pCustomerNameL2 = null,
         string pCustomerAddress = null,
         string pCustomerPhoneNumber = null,
         string pCustomerTaxNumber = null,
         string pCustomerPostBox = null,
         string pCustomerFax = null,
         string pCustomerEmail = null,
         string pAuthorizePerson = null,
         int? pCustomerTypeId = null,
         int? pSalesId = null,
         int? pSellCostTypeId = null,
         int? pCustomerDailyStopType = null,
         int? pCustomerDailyDay = null,
         int? pAreaId = null,
         int? pCategoryId = null,
         int? pStatus = null,
         string pAuthorizePersonTel = null,
         string pCustomerVATCode = null,
         int? pCustomerParentId = null,
         int? pCountryId = null,
         int? pCityId = null,
         decimal? pCustomerAmountLimit = null,
         int? pAccountId = null,
          int? pTypeId = null,
         bool? pCustomerIsActive = null,
         bool? pIsDeleted = null,
         int? pIsParent = null,
         bool? pIsCustomer = null,
         bool? pIsBlackList = null,
        string pNotes = null,
        string pOrganization = null,
         string pStreet = null,
         string pCity = null,
         string pBuildingNumber = null,
         string pPostalZone = null,
         string pDistrictName = null,
        int? pQueryTypeId = clsQueryType.qSelect);

        DataTable funGetGLCustomerReport(int? pCustomerId = null, bool? pIsActive = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
