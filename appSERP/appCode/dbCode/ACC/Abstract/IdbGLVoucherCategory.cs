using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.ACC.Abstract
{
    public interface IdbGLVoucherCategory
    {
        string funGLVoucherCategoryGET(
        int? pGLVoucherCategoryId = null,
        string pGLVoucherCategoryNameL1 = null,
        string pGLVoucherCategoryNameL2 = null,
        bool? pGLVoucherCategoryIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
