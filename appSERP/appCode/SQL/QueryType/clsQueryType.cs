using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace appSERP.appCode.SQL.QueryType
{
    public static class clsQueryType
    {
        // Insert
        public const int qInsert = 100;

        // Update
        public const int qUpdate = 200;
        public const int qDocIssued = 201;
        public const int qDocWait = 202;
        public const int qDocPosted = 203;
        public const int qDocCancel = 204;
        // Update User Language
        public const int qUpdateUserLanguage = 250;

        // Delete
        public const int qDelete = 300;

        // Select
        public const int qSelect = 400;
        public const int qSelectBH = 412;
        public const int qSelectExtra = 401;

        // Select 500
        public const int qSelectLogin = 500;

        // Select 600
        public const int qSelectExtraData = 600;

        // Select 500
        public const int qSelectAdvance = 500;

    }
}