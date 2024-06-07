using appSERP.appCode.dbCode.ACC;
using appSERP.appCode.dbCode.ACC.Abstract;
using appSERP.appCode.SQL.QueryType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace appSERP.Controllers.DataAPI.ACC
{
    public class APIGLCustomerController : ApiController
    {
        private IdbGLCustomer _dbGLCustomer;
        public APIGLCustomerController(IdbGLCustomer dbGLCustomer) {
            _dbGLCustomer = dbGLCustomer;
        }

        [HttpGet]
        public string GLCustomerGET(
         int? pCustomerId = null,
        string pCustomerCode = null,
         string pCustomerSequence = null,
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
         bool? pCustomerIsActive = true,
         bool? pIsDeleted = false,
         int? pDelivaryCompanyType = null,
         float? pDelivaryCompanyValue = null,
     int? pQueryTypeId = clsQueryType.qSelect)
        {
            try
            {
                // Get Data
                string vData = _dbGLCustomer.funGLCustomerGET(
                pCustomerId: pCustomerId,
                pCustomerCode: pCustomerCode,
                pCustomerSequence: pCustomerSequence,
                pSeqByType: pSeqByType,
                pCustomerNameL1: pCustomerNameL1,
                pCustomerNameL2: pCustomerNameL2,
                pCustomerAddress: pCustomerAddress,
                pCustomerPhoneNumber: pCustomerPhoneNumber,
                pCustomerTaxNumber: pCustomerTaxNumber,
                pCustomerPostBox: pCustomerPostBox,
                pCustomerFax: pCustomerFax,
                pCustomerEmail: pCustomerEmail,
                pAuthorizePerson: pAuthorizePerson,
                pCustomerTypeId: pCustomerTypeId,
                pSalesId: pSalesId,
                pSellCostTypeId: pSellCostTypeId,
                pCustomerDailyStopType: pCustomerDailyStopType,
                pCustomerDailyDay: pCustomerDailyDay,
                pAreaId: pAreaId,
                pCategoryId: pCategoryId,
                pStatus: pStatus,
                pAuthorizePersonTel: pAuthorizePersonTel,
                pCustomerVATCode: pCustomerVATCode,
                pCustomerParentId: pCustomerParentId,
                pCountryId: pCountryId,
                pCityId: pCityId,
                pCustomerAmountLimit: pCustomerAmountLimit,
                pAccountId: pAccountId,
                pIsParent: pIsParent,
                pTypeId: pTypeId,
                pIsCustomer: pIsCustomer,
                pIsBlackList: pIsBlackList,
                pNotes: pNotes,
                pOrganization: pOrganization,
                pStreet: pStreet,
                pCity: pCity,
                pBuildingNumber: pBuildingNumber,
                pPostalZone: pPostalZone,
                pDistrictName: pDistrictName,

                pCustomerIsActive: pCustomerIsActive,
                pDelivaryCompanyType: pDelivaryCompanyType,
                pDelivaryCompanyValue: pDelivaryCompanyValue,
                pIsDeleted: pIsDeleted,
                pQueryTypeId: pQueryTypeId
                   );
                // Return Data
                return vData;
            }
            catch(Exception ex)
            {
                if (ex.Message == "2627" || ex.Message == "2601")
                {
                    return "2627" ;
                }
                return ex.Message;
            }
        }
    }
}
