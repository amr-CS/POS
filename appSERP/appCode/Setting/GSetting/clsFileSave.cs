using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace appSERP.appCode.Setting.GSetting
{
    public static class clsFileSave
    {
        // File Save
        public static string funFileSave(HttpPostedFileBase pFile, string pFolder, string pOldFile)
        {
            // Get File Name Full
            var vFileNameFull = Path.GetFileName(pFile.FileName);
            // Get File Extension
            var vExtension = Path.GetExtension(pFile.FileName);
            // Get File Name Without Extension
            string vFileName = Path.GetFileNameWithoutExtension(vFileNameFull);
            // Generate New GUID
            string vGUID = Guid.NewGuid().ToString();
            // File [With GUID]
            string vFile = vFileName + "_" + vGUID + vExtension;
            // File Full Path
            string vFileFullPath = System.Web.Hosting.HostingEnvironment.MapPath(pFolder) + @"\" + vFile;

            // Check If There Is Old File [In Edit]
            if (!string.IsNullOrEmpty(pOldFile))
            {
                // Old File Full Path
                string vOldFileFullPath = System.Web.Hosting.HostingEnvironment.MapPath(pOldFile);
                if (File.Exists(vOldFileFullPath))
                {
                    // Delete Old File
                    File.Delete(vOldFileFullPath);
                }
            }

            // Save File to Folder
            pFile.SaveAs(vFileFullPath);

            // Return [Path] to Save
            return pFolder + "/" + vFile;
        }
    }
}