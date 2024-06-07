using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appSERP.appCode.Setting.SYSSETT.Abstract
{
    public interface ISYSSETTSetting
    {
        string funFirstGl();
        string funLastGL();
        string funNextGL();
        string funPrevGL();
        string funFirstCashDeskTrans();
        string funLastCashDeskTrans();
        string funNextCashDeskTrans();
        string funPrevCashDeskTrans();

        int i { get; set; }
    }
}
