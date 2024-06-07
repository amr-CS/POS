using appSERP.appCode.dbCode.CPanel.Abstract;
using appSERP.appCode.dbCode.GD;
using appSERP.appCode.dbCode.SEC;
using appSERP.appCode.dbCode.SETT;
using appSERP.appCode.dbCode.SETT.Abstract;
using appSERP.appCode.dbCode.SYSSETT;
using appSERP.appCode.dbCode.SYSSETT.Abstract;
using appSERP.appCode.Setting.APISetting;
using appSERP.appCode.Setting.APISetting.Abstract;
using appSERP.appCode.Setting.APISetting.APIDirectory;
using appSERP.appCode.Setting.GD;
using appSERP.appCode.Setting.GD.Abstract;
using appSERP.appCode.Setting.GSetting;
using appSERP.appCode.SQL.QueryType;
using appSERP.Models;
using appSERP.Models.GD;
using appSERP.Models.SEC;
using appSERP.Models.SETT;
using appSERP.Models.SYSSETT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appSERP.Controllers.DataAPI.CPanel
{
    public class CPanelController : Controller
    {
        #region CompanyBranch               

        private IdbCompanyBranch _dbCompanyBranch;
        private IdbCompanySystem _dbCompanySystem;
        private IdbDevCompany _dbDevCompany;
        private IdbUserObjectAction _dbUserObjectAction;
        private IdbFont _dbFont;
        private IdbSystem _dbSystem;
        private IdbSystemMessage _dbSystemMessage;
        private IdbObjects _dbObjects;
        private IdbLanguage _dbLanguage;
        private IclsAPI _clsAPI;
        private IDevCompanySetting _DevCompanySetting;

        public CPanelController(IdbCompanyBranch dbCompanyBranch, IdbCompanySystem dbCompanySystem,
            IdbDevCompany dbDevCompany, IdbUserObjectAction dbUserObjectAction, IdbFont dbFont, IdbSystem dbSystem, IdbSystemMessage dbSystemMessage
            , IdbObjects dbObjects, IdbLanguage dbLanguage, IclsAPI clsAPI, IDevCompanySetting DevCompanySetting)
        {
            _dbCompanyBranch = dbCompanyBranch;
            _dbCompanySystem = dbCompanySystem;
            _dbDevCompany = dbDevCompany;
            _dbUserObjectAction = dbUserObjectAction;
            _dbFont = dbFont;
            _dbSystem = dbSystem;
            _dbSystemMessage = dbSystemMessage;
            _dbObjects = dbObjects;
            _dbLanguage = dbLanguage;
            _clsAPI = clsAPI;
            _DevCompanySetting = DevCompanySetting;
        }

        // GET: CompanyBranch
        public ActionResult CompanyBranch()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICompanyBranch;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            return View(vDtData);
        }
        public ActionResult CompanyBranchDataModel(int? id = 0)
        {
            // New Model
            CompanyBranchModel vCompanyBranchModel = new CompanyBranchModel();
            if (id == 0)
            {

                ViewBag.vbcPLAccountId = 0;
                ViewBag.vbcRDAccountId = 0;
                ViewBag.vbcFinancialYearId = 0;
                ViewBag.vbcCurrencyId = 0;
                ViewBag.vbcLanguageId = 0;
                ViewBag.vbcLanguage2Id = 0;
            }

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = @"/APICompanyBranch/CompanyBranchGet";
                string vParameters = "?pCompanyBranchId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcPLAccountId = Convert.ToInt32(vDtData.Rows[0]["PLAccountId"].ToString());
                ViewBag.vbcRDAccountId = Convert.ToInt32(vDtData.Rows[0]["RDAccountId"].ToString());
                ViewBag.vbcFinancialYearId = Convert.ToInt32(vDtData.Rows[0]["FinancialYearId"].ToString());
                ViewBag.vbcCurrencyId = Convert.ToInt32(vDtData.Rows[0]["DefaultCurrencyId"].ToString());
                ViewBag.vbcLanguageId = Convert.ToInt32(vDtData.Rows[0]["Language1Id"].ToString());
                ViewBag.vbcLanguage2Id = Convert.ToInt32(vDtData.Rows[0]["Language2Id"].ToString());
                // Set Model Data
                vCompanyBranchModel.CompanyBranchId = Convert.ToInt32(vDtData.Rows[0]["CompanyBranchId"]);
                vCompanyBranchModel.CompanyBranchCode = vDtData.Rows[0]["CompanyBranchNameL1"].ToString();
                vCompanyBranchModel.CompanyBranchNameL1 = vDtData.Rows[0]["CompanyBranchNameL1"].ToString();
                vCompanyBranchModel.CompanyBranchNameL2 = vDtData.Rows[0]["CompanyBranchNameL2"].ToString();
                vCompanyBranchModel.CompanyBranchLevel = Convert.ToInt32(vDtData.Rows[0]["CompanyBranchLevel"]);
                vCompanyBranchModel.IsHolding = Convert.ToBoolean(vDtData.Rows[0]["IsHolding"].ToString());
                vCompanyBranchModel.AccountCodeHierarchy = vDtData.Rows[0]["AccountCodeHierarchy"].ToString();
                vCompanyBranchModel.LastClosedYear = Convert.ToInt32(vDtData.Rows[0]["LastClosedYear"].ToString());
                vCompanyBranchModel.LastClosedMonth = Convert.ToInt32(vDtData.Rows[0]["LastClosedMonth"]);
                vCompanyBranchModel.RefNumberIsVisible = Convert.ToBoolean(vDtData.Rows[0]["RefNumberIsVisible"].ToString());
                vCompanyBranchModel.CostCenterIsRequired = Convert.ToBoolean(vDtData.Rows[0]["CostCenterIsRequired"]);
                vCompanyBranchModel.PostIsSerialized = Convert.ToBoolean(vDtData.Rows[0]["PostIsSerialized"].ToString());
                vCompanyBranchModel.DepositIsSentDirectToBank = Convert.ToBoolean(vDtData.Rows[0]["DepositIsSentDirectToBank"]);
                vCompanyBranchModel.IsPostZeroEntry = Convert.ToBoolean(vDtData.Rows[0]["IsPostZeroEntry"].ToString());
                vCompanyBranchModel.DefaultCurrencyId = Convert.ToInt32(vDtData.Rows[0]["DefaultCurrencyId"]);
                vCompanyBranchModel.PLAccountId = Convert.ToInt32(vDtData.Rows[0]["PLAccountId"].ToString());
                vCompanyBranchModel.RDAccountId = Convert.ToInt32(vDtData.Rows[0]["RDAccountId"]);
                vCompanyBranchModel.FinancialYearId = Convert.ToInt32(vDtData.Rows[0]["FinancialYearId"].ToString());
                vCompanyBranchModel.CompanyBranchIsActive = Convert.ToBoolean(vDtData.Rows[0]["CompanyBranchIsActive"]);
                vCompanyBranchModel.Language1Id = Convert.ToInt32(vDtData.Rows[0]["Language1Id"]);
                vCompanyBranchModel.Language2Id = Convert.ToInt32(vDtData.Rows[0]["Language2Id"]);
            }

            // Return Result
            return View(vCompanyBranchModel);
        }
        [HttpPost]
        public ActionResult CompanyBranchDataModel(int? id = 0, CompanyBranchModel pCompanyBranchModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {

                // API Path
                string vPath = @"/APICompanyBranch/CompanyBranchGet";
                string vParameters =
                    "?pCompanyBranchId=" + id +
                    "&pCompanyBranchCode=" + pCompanyBranchModel.CompanyBranchCode +
                    "&pCompanyBranchNameL1=" + pCompanyBranchModel.CompanyBranchNameL1 +
                    "&pCompanyBranchNameL2=" + pCompanyBranchModel.CompanyBranchNameL2 +
                    "&pCompanyBranchLevel=" + pCompanyBranchModel.CompanyBranchLevel +
                    "&pIsHolding=" + pCompanyBranchModel.IsHolding +
                    "&pAccountCodeHierarchy=" + pCompanyBranchModel.AccountCodeHierarchy +
                    "&pLastClosedYear=" + pCompanyBranchModel.LastClosedYear +
                    "&pLastClosedMonth=" + pCompanyBranchModel.LastClosedMonth +
                    "&pRefNumberIsVisible=" + pCompanyBranchModel.RefNumberIsVisible +
                    "&pCostCenterIsRequired=" + pCompanyBranchModel.CostCenterIsRequired +
                    "&pPostIsSerialized=" + pCompanyBranchModel.PostIsSerialized +
                    "&pDepositIsSentDirectToBank=" + pCompanyBranchModel.DepositIsSentDirectToBank +
                    "&pIsPostZeroEntry=" + pCompanyBranchModel.IsPostZeroEntry +
                    "&pDefaultCurrencyId=" + pCompanyBranchModel.DefaultCurrencyId +
                    "&pPLAccountId=" + pCompanyBranchModel.PLAccountId +
                    "&pRDAccountId=" + pCompanyBranchModel.RDAccountId +
                    "&pFinancialYearId=" + pCompanyBranchModel.FinancialYearId +
                    "&pLanguage1Id=" + pCompanyBranchModel.Language1Id +
                    "&pLanguage2Id=" + pCompanyBranchModel.Language2Id +
                    "&pCompanyBranchIsActive=" + pCompanyBranchModel.CompanyBranchIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;


                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCompanyBranch.vSQLResult = vDrwResult[0].ToString();
                _dbCompanyBranch.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                // Go To Index
                return RedirectToAction("CompanyBranch");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        #endregion CompanyBranch

        #region CompanySystem

        // GET: CompanySystem
        public ActionResult CompanySystem()
        {
            // API Path
            string vPath = appAPIDirectory.vAPICompanySystem;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View

            return View(vDtData);
        }
        public ActionResult CompanySystemDataModel(int? id = 0)
        {
            // New Model
            CompanySystemModel vCompanySystemModel = new CompanySystemModel();
            if (id == 0)
            {
                ViewBag.vbcCompanyId = 0;
                ViewBag.vbcSystemId = 0;
            }

            // Edit Case
            if (id > 0)
            {

                // API Path
                string vPath = appAPIDirectory.vAPICompanySystem;
                string vParameters = "?pCompanySystemId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcCompanyId = Convert.ToInt32(vDtData.Rows[0]["CompanyId"].ToString());
                ViewBag.vbcSystemId = Convert.ToInt32(vDtData.Rows[0]["SystemId"].ToString());

                // Set Model Data
                vCompanySystemModel.CompanySystemId = Convert.ToInt32(vDtData.Rows[0]["CompanySystemId"]);
                vCompanySystemModel.CompanySystemCode = vDtData.Rows[0]["CompanySystemCode"].ToString();
                vCompanySystemModel.CompanyId = Convert.ToInt32(vDtData.Rows[0]["CompanyId"].ToString());
                vCompanySystemModel.SystemId = Convert.ToInt32(vDtData.Rows[0]["SystemId"].ToString());
                vCompanySystemModel.CompanySystemIsActive = Convert.ToBoolean(vDtData.Rows[0]["CompanySystemIsActive"]);
            }

            // Return Result
            return View(vCompanySystemModel);
        }
        [HttpPost]
        public ActionResult CompanySystemDataModel(int? id = 0, CompanySystemModel pCompanySystemModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {

                // API Path
                string vPath = appAPIDirectory.vAPICompanySystem;
                string vParameters =
                        "?pCompanySystemId=" + id +
                        "&pCompanySystemCode=" + pCompanySystemModel.CompanySystemCode +
                        "&pCompanyId=" + pCompanySystemModel.CompanyId +
                        "&pSystemId=" + pCompanySystemModel.SystemId +
                        "&pCompanySystemIsActive=" + pCompanySystemModel.CompanySystemIsActive +
                        "&pIsDeleted=" + pIsDelete +
                        "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbCompanySystem.vSQLResult = vDrwResult[0].ToString();
                _dbCompanySystem.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                // Go To Index
                return RedirectToAction("CompanySystem");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        #endregion CompanySystem

        #region Admin

        // GET: Admin
        public ActionResult Admin()
        {
            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }

        #endregion Admin

        #region System

        // GET: System
        public ActionResult System()
        {
            // API Path
            string vPath = appAPIDirectory.vAPISystem;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View

            return View(vDtData);
        }
        public ActionResult SystemDataModel(int? id = 0)
        {
            // New Model
            SystemModel vSystemModel = new SystemModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPISystem;
                string vParameters = "?pSystemId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vSystemModel.SystemId = Convert.ToInt32(vDtData.Rows[0]["SystemId"]);
                vSystemModel.SystemCode = vDtData.Rows[0]["SystemCode"].ToString();
                vSystemModel.SystemNameL1 = vDtData.Rows[0]["SystemNameL1"].ToString();
                vSystemModel.SystemNameL2 = vDtData.Rows[0]["SystemNameL2"].ToString();
                vSystemModel.SystemImageLogo = vDtData.Rows[0]["SystemImageLogo"].ToString();
                vSystemModel.SystemVersion = vDtData.Rows[0]["SystemVersion"].ToString();
                vSystemModel.SystemLastUpdated = DateTime.Parse(vDtData.Rows[0]["SystemLastUpdated"].ToString());
            }

            // Return Result
            return View(vSystemModel);
        }
        [HttpPost]
        public ActionResult SystemDataModel(int? id = 0,
            SystemModel pSystemModel = null,
            bool? pIsDelete = false,
            HttpPostedFileBase pFile = null)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            // User Image
            if (pFile != null)
            {
                pSystemModel.SystemImageLogo = clsFileSave.funFileSave(pFile, "/Image/DataImage/GD", pSystemModel.SystemImageLogo);
            }

            try
            {

                // API Path
                string vPath = appAPIDirectory.vAPISystem;
                string vParameters =
                        "?pSystemId=" + pSystemModel.SystemId +
                        "&pSystemCode=" + pSystemModel.SystemCode +
                        "&pSystemNameL1=" + pSystemModel.SystemNameL1 +
                        "&pSystemNameL2=" + pSystemModel.SystemNameL2 +
                        "&pSystemImageLogo=" + pSystemModel.SystemImageLogo +
                        "&pSystemVersion=" + pSystemModel.SystemVersion +
                        "&pSystemLastUpdated=" + pSystemModel.SystemLastUpdated.ToString("yyyy-MM-dd hh:mm:ss") +
                        "&pIsDeleted=" + pIsDelete +
                        "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSystem.vSQLResult = vDrwResult[0].ToString();
                _dbSystem.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                // Go To Index
                return RedirectToAction("System");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        #endregion System

        #region Font

        // GET: Font
        public ActionResult Font()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIFont;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            return View(vDtData);
        }
        public ActionResult FontDataModel(int? id = 0)
        {
            // New Model
            FontModel vFontModel = new FontModel();
            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = @"/APIFont/FontGet";
                string vParameters = "?pFontId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vFontModel.FontId = Convert.ToInt32(vDtData.Rows[0]["FontId"]);
                vFontModel.FontName = vDtData.Rows[0]["FontName"].ToString();
                vFontModel.FontPath = vDtData.Rows[0]["FontPath"].ToString();
                vFontModel.FontIsActive = Convert.ToBoolean(vDtData.Rows[0]["FontIsActive"]);
            }

            // Return Result
            return View(vFontModel);
        }
        [HttpPost]
        public ActionResult FontDataModel(int? id = 0, FontModel pFontModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }
            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPIFont;
                string vParameters =
                    "?pFontId=" + id +
                    "&pFontName=" + pFontModel.FontName +
                    "&pFontPath=" + pFontModel.FontPath +
                    "&pFontIsActive=" + pFontModel.FontIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbFont.vSQLResult = vDrwResult[0].ToString();
                _dbFont.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                // Go To Index
                return RedirectToAction("Font");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        #endregion Font


        // GET: 

        public ActionResult DevCompany()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIDevCompany;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);


        }


        public ActionResult DevCompanyDataModel(int? id = 0)
        {
            // New Model
            DevCompanyModel vDevCompanyModel = new DevCompanyModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIDevCompany;
                string vParameters = "?pDevCompanyId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                // Set Model Data
                vDevCompanyModel.DevCompanyId = Convert.ToInt32(vDtData.Rows[0]["DevCompanyId"]);
                vDevCompanyModel.DevCompanyNameL1 = vDtData.Rows[0]["DevCompanyNameL1"].ToString();
                vDevCompanyModel.DevCompanyNameL2 = vDtData.Rows[0]["DevCompanyNameL2"].ToString();
                vDevCompanyModel.DevCompanyPhone = vDtData.Rows[0]["DevCompanyPhone"].ToString();
                vDevCompanyModel.DevCompanyPhone2 = vDtData.Rows[0]["DevCompanyPhone2"].ToString();
                vDevCompanyModel.DevCompanyEmail = vDtData.Rows[0]["DevCompanyEmail"].ToString();
                vDevCompanyModel.DevCompanyWebsite = vDtData.Rows[0]["DevCompanyWebsite"].ToString();
                vDevCompanyModel.DevCompanyAddress = vDtData.Rows[0]["DevCompanyAddress"].ToString();
                vDevCompanyModel.DevCompanyImage = vDtData.Rows[0]["DevCompanyImage"];
                vDevCompanyModel.DevCompanyImageFull = vDtData.Rows[0]["DevCompanyImageFull"];
                vDevCompanyModel.DevAppNameL1 = vDtData.Rows[0]["DevAppNameL1"].ToString();
                vDevCompanyModel.DevAppNameL2 = vDtData.Rows[0]["DevAppNameL2"].ToString();
                vDevCompanyModel.DevAppImage = vDtData.Rows[0]["DevAppImage"].ToString();
                vDevCompanyModel.DevCompanyIsActive = Convert.ToBoolean(vDtData.Rows[0]["DevCompanyIsActive"]);

            }

            // Return Result
            return View(vDevCompanyModel);
        }

        [HttpPost]
        public ActionResult DevCompanyDataModel(int? id = 0, DevCompanyModel pDevCompanyModel = null, bool? pIsDelete = false,
             HttpPostedFileBase pDevCompanyImage = null,
             HttpPostedFileBase pDevCompanyImageFull = null,
             HttpPostedFileBase pDevAppImage = null)
        {

            // Dev Company Image
            byte[] vDevCompanyImage = null;
            if (pDevCompanyImage != null)
            {
                MemoryStream vMSDevCompanyImage = new MemoryStream();
                pDevCompanyImage.InputStream.CopyTo(vMSDevCompanyImage);
                vDevCompanyImage = vMSDevCompanyImage.ToArray();
            }

            // Dev Company ImageFull
            byte[] vDevCompanyImageFull = null;
            if (pDevCompanyImageFull != null)
            {
                MemoryStream vMSDevCompanyImageFull = new MemoryStream();
                pDevCompanyImageFull.InputStream.CopyTo(vMSDevCompanyImageFull);
                vDevCompanyImageFull = vMSDevCompanyImageFull.ToArray();
            }


            // Dev App Image
            byte[] vDevAppImage = null;
            if (pDevAppImage != null)
            {
                MemoryStream vMSDevAppImage = new MemoryStream();
                pDevAppImage.InputStream.CopyTo(vMSDevAppImage);
                vDevAppImage = vMSDevAppImage.ToArray();
            }


            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // Save
                _dbDevCompany.funDevCompanyGET(
                    pDevCompanyId: id,
                    pDevCompanyNameL1: pDevCompanyModel.DevCompanyNameL1,
                    pDevCompanyNameL2: pDevCompanyModel.DevCompanyNameL2,
                    pDevCompanyPhone: pDevCompanyModel.DevCompanyPhone,
                    pDevCompanyPhone2: pDevCompanyModel.DevCompanyPhone2,
                    pDevCompanyEmail: pDevCompanyModel.DevCompanyEmail,
                    pDevCompanyWebsite: pDevCompanyModel.DevCompanyWebsite,
                    pDevCompanyAddress: pDevCompanyModel.DevCompanyAddress,
                    pDevCompanyImage: vDevCompanyImage,
                    pDevCompanyImageFull: vDevCompanyImageFull,
                    pDevCompanyIsActive: pDevCompanyModel.DevCompanyIsActive,
                    pDevAppNameL1: pDevCompanyModel.DevAppNameL1,
                    pDevAppNameL2: pDevCompanyModel.DevAppNameL2,
                    pDevAppImage: vDevAppImage,
                    pIsDeleted: pIsDelete,
                    pQueryTypeId: vQueryTypeId);


                //// SQL Result
                //DataRow vDrwResult = clsAPI.funResultGet(vPath + vParameters).Rows[0];
                //dbDevCompany.vSQLResult = vDrwResult[0].ToString();
                //dbDevCompany.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                // SET Dev Company Data
                _DevCompanySetting.SetDevCompanySetting();

                // Go To Index
                return RedirectToAction("DevCompany");
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        // GET: Language
        public ActionResult Language()
        {
            // API Path
            string vPath = appAPIDirectory.vAPILanguage;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            return View(vDtData);
        }
        public ActionResult LanguageDataModel(int? id = 0)
        {
            // New Model
            LanguageModel vLanguageModel = new LanguageModel();
            if (id == 0)
            {
                ViewBag.vbcFontId = 0;
            }
            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPILanguage;
                string vParameters = "?pLanguageId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcFontId = Convert.ToInt32(vDtData.Rows[0]["DefaultFontId"]);
                // Set Model Data
                vLanguageModel.LanguageId = Convert.ToInt32(vDtData.Rows[0]["LanguageId"]);
                vLanguageModel.LanguageCode = vDtData.Rows[0]["LanguageCode"].ToString();
                vLanguageModel.LanguageNameL1 = vDtData.Rows[0]["LanguageNameL1"].ToString();
                vLanguageModel.LanguageNameL2 = vDtData.Rows[0]["LanguageNameL2"].ToString();
                vLanguageModel.CultureName = vDtData.Rows[0]["CultureName"].ToString();
                vLanguageModel.LanguageImage = vDtData.Rows[0]["LanguageImage"].ToString();
                vLanguageModel.DefaultFontId = Convert.ToInt32(vDtData.Rows[0]["DefaultFontId"].ToString());
                vLanguageModel.LanguageIsActive = Convert.ToBoolean(vDtData.Rows[0]["LanguageIsActive"]);
            }

            // Return Result
            return View(vLanguageModel);
        }

        [HttpPost]
        public ActionResult LanguageDataModel(int? id = 0, LanguageModel pLanguageModel = null, bool? pIsDelete = false,
            HttpPostedFileBase pFile = null)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            // User Image
            if (pFile != null)
            {
                pLanguageModel.LanguageImage = clsFileSave.funFileSave(pFile, "/Image/DataImage/SETT", pLanguageModel.LanguageImage);
            }


            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPILanguage;
                string vParameters =
                    "?pLanguageId=" + id +
                    "&pLanguageCode=" + pLanguageModel.LanguageCode +
                    "&pLanguageNameL1=" + pLanguageModel.LanguageNameL1 +
                    "&pLanguageNameL2= " + pLanguageModel.LanguageNameL2 +
                    "&pCultureName=" + pLanguageModel.CultureName +
                    "&pLanguageImage=" + pLanguageModel.LanguageImage +
                    "&pDefaultFontId=" + pLanguageModel.DefaultFontId +
                     "&pLanguageIsActive=" + pLanguageModel.LanguageIsActive +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbLanguage.vSQLResult = vDrwResult[0].ToString();
                _dbLanguage.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                // Go To Index
                return RedirectToAction("Language");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        // GET: Objects
        public ActionResult Objects()
        {
            // API Path
            string vPath = appAPIDirectory.vAPIObjects;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            return View(vDtData);
        }

        public ActionResult ObjectsDataModel(int? id = 0)
        {
            // New Model
            ObjectsModel vObjectModel = new ObjectsModel();

            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPIObjects;
                string vParameters = "?pObjectId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);

                // Set Model Data
                vObjectModel.ObjectId = Convert.ToInt32(vDtData.Rows[0]["ObjectId"]);
                vObjectModel.ObjectSeq = Convert.ToInt32(vDtData.Rows[0]["ObjectSeq"]);
                vObjectModel.ObjectProName = vDtData.Rows[0]["ObjectProName"].ToString();
                vObjectModel.ObjectNameL1 = vDtData.Rows[0]["ObjectNameL1"].ToString();
                vObjectModel.ObjectNameL2 = vDtData.Rows[0]["ObjectNameL2"].ToString();
                vObjectModel.ObjectNameL3 = vDtData.Rows[0]["ObjectNameL3"].ToString();
                vObjectModel.ObjectNameL4 = vDtData.Rows[0]["ObjectNameL4"].ToString();
                vObjectModel.ObjectNameL5 = vDtData.Rows[0]["ObjectNameL5"].ToString();
                vObjectModel.ObjectNameL6 = vDtData.Rows[0]["ObjectNameL6"].ToString();
                vObjectModel.ObjectNameL7 = vDtData.Rows[0]["ObjectNameL7"].ToString();
                vObjectModel.ObjectNameL8 = vDtData.Rows[0]["ObjectNameL8"].ToString();
                vObjectModel.ObjectNameL9 = vDtData.Rows[0]["ObjectNameL9"].ToString();
                vObjectModel.ObjectNameL10 = vDtData.Rows[0]["ObjectNameL10"].ToString();
                vObjectModel.ObjectIconB = vDtData.Rows[0]["ObjectIconB"].ToString();
                vObjectModel.ObjectIconW = vDtData.Rows[0]["ObjectIconW"].ToString();
                vObjectModel.ObjectImage = vDtData.Rows[0]["ObjectImage"].ToString();
                vObjectModel.ObjectURL = vDtData.Rows[0]["ObjectURL"].ToString();
                vObjectModel.ObjectTypeId = Convert.ToInt32(vDtData.Rows[0]["ObjectTypeId"].ToString());
                vObjectModel.ObjectIsMainMenu = Convert.ToBoolean(vDtData.Rows[0]["ObjectIsMainMenu"].ToString());
                vObjectModel.ObjectIsActive = Convert.ToBoolean(vDtData.Rows[0]["ObjectIsActive"]);
            }

            // Return Result
            return View(vObjectModel);
        }

        [HttpPost]
        public ActionResult ObjectsDataModel(int? id = 0, ObjectsModel pObjectsModel = null, bool? pIsDelete = false, HttpPostedFileBase pFile = null)
        {
            // Icons Objects
            if (pFile != null)
            {
                pObjectsModel.ObjectIconW = clsFileSave.funFileSave(pFile, "/Image/DataImage/SYSSETT/Icons/White", pObjectsModel.ObjectIconW);
                pObjectsModel.ObjectIconB = clsFileSave.funFileSave(pFile, "/Image/DataImage/SYSSETT/Icons/BLack", pObjectsModel.ObjectIconB);

            }
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {

                // API Path
                string vPath = appAPIDirectory.vAPIObjects;
                string vParameters =
                     "?pObjectId=" + id +
                     "&pObjectSeq=" + pObjectsModel.ObjectSeq +
                     "&pObjectProName=" + pObjectsModel.ObjectProName +
                     "&pObjectCode=" + pObjectsModel.ObjectCode +
                     "&pObjectNameL1=" + pObjectsModel.ObjectNameL1 +
                     "&pObjectNameL2=" + pObjectsModel.ObjectNameL2 +
                     "&pObjectNameL3=" + pObjectsModel.ObjectNameL3 +
                     "&pObjectNameL4=" + pObjectsModel.ObjectNameL4 +
                     "&pObjectNameL5=" + pObjectsModel.ObjectNameL5 +
                     "&pObjectNameL6=" + pObjectsModel.ObjectNameL6 +
                     "&pObjectNameL7=" + pObjectsModel.ObjectNameL7 +
                     "&pObjectNameL8=" + pObjectsModel.ObjectNameL8 +
                     "&pObjectNameL9=" + pObjectsModel.ObjectNameL9 +
                     "&pObjectNameL10=" + pObjectsModel.ObjectNameL10 +
                     "&pObjectIconW=" + pObjectsModel.ObjectIconW +
                     "&pObjectIconB=" + pObjectsModel.ObjectIconB +
                     "&pObjectAction=" + pObjectsModel.ObjectAction +
                     "&pObjectImage=" + pObjectsModel.ObjectImage +
                     "&pObjectURL=" + pObjectsModel.ObjectURL +
                     "&pObjectIsMainMenu=" + pObjectsModel.ObjectIsMainMenu +
                     "&pObjectIsActive=" + pObjectsModel.ObjectIsActive +
                     "&pObjectTypeId=" + pObjectsModel.ObjectTypeId +
                     "&pIsDeleted=" + pIsDelete +
                     "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbObjects.vSQLResult = vDrwResult[0].ToString();
                _dbObjects.vSQLResultTypeId = vDrwResult[1].ToString();

                // Go To Index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }



        // GET: SystemMessage
        public ActionResult SystemMessage()
        {
            // API Path
            string vPath = appAPIDirectory.vAPISystemMessage;
            // Result
            DataTable vDtData = _clsAPI.funResultGet(vPath);
            // Return View
            if (Request.IsAjaxRequest())
            {
                return PartialView(vDtData);
            }
            return View(vDtData);


        }


        public ActionResult SystemMessageDataModel(int? id = 0)
        {
            // New Model
            SystemMessageModel vSystemMessageModel = new SystemMessageModel();
            if (id == 0)
            {
                ViewBag.vbcLanguageId = 0;
            }
            // Edit Case
            if (id > 0)
            {
                // API Path
                string vPath = appAPIDirectory.vAPISystemMessage;
                string vParameters = "?pSystemMessageId=" + id;
                // Result
                DataTable vDtData = _clsAPI.funResultGet(vPath + vParameters);
                ViewBag.vbcLanguageId = Convert.ToInt32(vDtData.Rows[0]["LanguageId"].ToString());
                // Set Model Data
                vSystemMessageModel.SystemMessageId = Convert.ToInt32(vDtData.Rows[0]["SystemMessageId"]);
                vSystemMessageModel.SystemMessageTypeId = Convert.ToInt32(vDtData.Rows[0]["SystemMessageId"]);
                vSystemMessageModel.SystemMessageText = vDtData.Rows[0]["SystemMessageText"].ToString();
                vSystemMessageModel.LanguageId = Convert.ToInt32(vDtData.Rows[0]["LanguageId"].ToString());

            }

            // Return Result
            return View(vSystemMessageModel);
        }

        [HttpPost]
        public ActionResult SystemMessageDataModel(int? id = 0, SystemMessageModel pSystemMessageModel = null, bool? pIsDelete = false)
        {
            // Check Operation
            int vQueryTypeId = clsQueryType.qInsert;
            if (id > 0) { vQueryTypeId = clsQueryType.qUpdate; }
            if (Convert.ToBoolean(pIsDelete)) { vQueryTypeId = clsQueryType.qDelete; }

            try
            {
                // API Path
                string vPath = appAPIDirectory.vAPISystemMessage;
                string vParameters =
                    "?pSystemMessageId=" + id +
                    "&pSystemMessageTypeId=" + pSystemMessageModel.SystemMessageTypeId +
                    "&pSystemMessageText=" + pSystemMessageModel.SystemMessageText +
                    "&pLanguageId=" + pSystemMessageModel.LanguageId +
                    "&pIsDeleted=" + pIsDelete +
                    "&pQueryTypeId=" + vQueryTypeId;

                // SQL Result
                DataRow vDrwResult = _clsAPI.funResultGet(vPath + vParameters).Rows[0];
                _dbSystemMessage.vSQLResult = vDrwResult[0].ToString();
                _dbSystemMessage.vSQLResultTypeId = Convert.ToInt32(vDrwResult[1]);

                // Go To Index
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }





        #region AdminSidebar

        // SideBar Content
        public ActionResult ViewSettingAdminSideBar()
        {
            // Get Objects
            string vObject = _dbUserObjectAction.funUserObjectActionGET(pObjectIsAdmin: true, pQueryTypeId: clsQueryType.qSelect);
            // JSON to DataTable
            DataTable vDtObject = JsonConvert.DeserializeObject<DataTable>(vObject);
            // ViewBag 
            ViewBag.vbObject = vDtObject;
            // Return Result
            return View();
        }

        #endregion AdminSidebar

    }
}