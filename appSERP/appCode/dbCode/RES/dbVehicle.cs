using appSERP.appCode.dbCode.RES.Abstract;
using appSERP.appCode.Setting.Company;
using appSERP.appCode.Setting.TimeSetting;
using appSERP.appCode.Setting.User;
using appSERP.appCode.SQL.Abstract;
using appSERP.appCode.SQL.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace appSERP.appCode.dbCode.RES
{
    public class dbVehicle : IdbVehicle
    {

        public string vSQLResult { get; set; }
        public int vSQLResultTypeId { get; set; }

        private IclsADO _clsADO;
        public dbVehicle(clsADO clsADO)
        {
            _clsADO = clsADO;
        }
        public string funVehicleGET(
         int? pVehicleId  = null,
         string pVehicleCode = null, 
   string pVecDescL1 = null, 
   string pVecDescL2 = null, 
    DateTime?  pInitialDate = null,
  string pPanelNumber = null, 
 int? pVecModelId = null,
    string pVecVINNO = null, 
int?  pVecTypeId = null,
int? pBrandId = null, 
int? pVecColorId = null,
 string pComments = null,
  int? pVecStatus = null,
 string pVehicleImage = null,
 string pListVehicles = null,
bool? pVehicleIsActive = null,
bool? pIsDeleted = null,
    int? pQueryTypeId = null,
    string pLstStatus = null,
    string pLstType = null,
    string pLstBrand = null,
    string pLstColor = null,
    string pSearchDate = null
    )
        {
            // Declaration 
            string vData = string.Empty;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("VehicleId", pVehicleId));
            vlstParam.Add(new SqlParameter("VehicleCode", pVehicleCode));
            vlstParam.Add(new SqlParameter("VecDescL1", pVecDescL1));
            vlstParam.Add(new SqlParameter("VecDescL2", pVecDescL2));
            vlstParam.Add(new SqlParameter("InitialDate", pInitialDate));
            vlstParam.Add(new SqlParameter("PanelNumber", pPanelNumber));
            vlstParam.Add(new SqlParameter("VecModelId", pVecModelId));
            vlstParam.Add(new SqlParameter("VecVINNO", pVecVINNO));
            vlstParam.Add(new SqlParameter("VecTypeId", pVecTypeId));
            vlstParam.Add(new SqlParameter("BrandId", pBrandId));
            vlstParam.Add(new SqlParameter("VecColorId", pVecColorId));
            vlstParam.Add(new SqlParameter("Comments", pComments));
            vlstParam.Add(new SqlParameter("VecStatus", pVecStatus));
            vlstParam.Add(new SqlParameter("VehicleImage", pVehicleImage));
            vlstParam.Add(new SqlParameter("ListVehicles", pListVehicles));
            vlstParam.Add(new SqlParameter("VehicleIsActive", pVehicleIsActive));
            vlstParam.Add(new SqlParameter("IsDeleted", pIsDeleted));
            vlstParam.Add(new SqlParameter("CreatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CreatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LastUpdatedBy", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("LastUpdatedOn", clsTimeSetting.funBranchTime()));
            vlstParam.Add(new SqlParameter("LanguageId", clsUser.vUserLanguageId));
            vlstParam.Add(new SqlParameter("QueryTypeId", pQueryTypeId));
            vlstParam.Add(new SqlParameter("LstStatus", pLstStatus));
            vlstParam.Add(new SqlParameter("LstType", pLstType));
            vlstParam.Add(new SqlParameter("LstBrand", pLstBrand));
            vlstParam.Add(new SqlParameter("LstColor", pLstColor));
            vlstParam.Add(new SqlParameter("SearchDate", pSearchDate));


            vData = _clsADO.funExecuteScalar("RES.spVehicleCRUD", vlstParam, "Data GET").ToString();
            return vData;
        }

        public DataTable funGetVehicleReport(bool? pIsActive = null)
        {
            // Declaration 
            DataTable vData;
            // Parameters
            List<SqlParameter> vlstParam = new List<SqlParameter>();
            vlstParam.Add(new SqlParameter("CompanyId", clsCompany.vCompanyId));
            vlstParam.Add(new SqlParameter("UserId", clsUser.vUserId));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL1", clsCompany.vCompanyLanguage1NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchNameL2", clsCompany.vCompanyLanguage2NameL1));
            vlstParam.Add(new SqlParameter("CompanyBranchTel", clsCompany.vCompanyPhone1));
            vlstParam.Add(new SqlParameter("CompanySite", clsCompany.vCompanySite));
            vlstParam.Add(new SqlParameter("CompanyImage", clsCompany.vCompanyImage));
            vlstParam.Add(new SqlParameter("UserFullName", clsUser.vUserFullName));
            vlstParam.Add(new SqlParameter("IsActive", pIsActive));

            vData = _clsADO.funFillDataTable("RES.GetVehiclesReport", vlstParam, "Data GET");


            return vData;
        }
    }
}