using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.dbCode.INV.Abstract
{
    public interface IdbInvEquipment
    {
        string funInvEquipmentGET(
        int? pEquipmentId = null,
        string pEquipmentCode = null,
        string pEquipmentNameL1 = null,
        string pEquipmentNameL2 = null,
        string pNotes = null,
        bool? pEquipmentIsActive = null,
        bool? pIsDeleted = false,
        int? pQueryTypeId = null);

        string vSQLResult { get; set; }
        int vSQLResultTypeId { get; set; }
    }
}
