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
    public class APIGLVoucherCategoryController : ApiController
    {
        private IdbGLVoucherCategory _dbGLVoucherCategory;
        public APIGLVoucherCategoryController(IdbGLVoucherCategory dbGLVoucherCategory)
        {
            _dbGLVoucherCategory = dbGLVoucherCategory;
        }

        [HttpGet]
        public string GLVoucherCategoryGET(
        int? pGLVoucherCategoryId = null,
        string pGLVoucherCategoryNameL1 = null,
        string pGLVoucherCategoryNameL2 = null,
        bool? pGLVoucherCategoryIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = clsQueryType.qSelect)
        {
            // GET Data 
            string vData = _dbGLVoucherCategory.funGLVoucherCategoryGET(
            pGLVoucherCategoryId: pGLVoucherCategoryId,
            pGLVoucherCategoryNameL1: pGLVoucherCategoryNameL1,
            pGLVoucherCategoryNameL2: pGLVoucherCategoryNameL2,
            pGLVoucherCategoryIsActive: pGLVoucherCategoryIsActive,
            pIsDeleted: pIsDeleted,
            pQueryTypeId: pQueryTypeId
             );

            // Result
            return vData;
        }
    }
}
