using appSERP.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using appSERP.Logger;
using appSERP.Models;
using appSERP.Models.RES;
using appSERP.Reports.POS;
using Newtonsoft.Json;
using System.Web.Mvc;
using appSERP.appCode.dbCode.RES.Abstract;

namespace appSERP.Controllers.DataController.RES
{
    public class MenuItemController : Controller
    {
        private ILog _ILog;
        private IdbMenuItem _dbMenuItem;
        private IdbSupplierMenu _dbSupplierMenu;
        public static DataTable AllPOSData;
        public static DataTable ReturnInsuranseData;
        public MenuItemController(ILog log, IdbMenuItem dbMenuItem, IdbSupplierMenu dbSupplierMenu)
        {
             this._ILog= log;
              this._dbMenuItem= dbMenuItem;
             this._dbSupplierMenu= dbSupplierMenu;
            this._ILog=log;
        }
        public ActionResult GetMenuItemBulk(int? id)

        {
            try
            {
                return Json(_dbMenuItem.funMenuItemGET(id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ActionResult GetSupplierMenuBulk(int? id)

        {
            try
            {
                return Json(_dbSupplierMenu.SupplierMenu(id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public JsonResult GetMenuItemBulk(ICollection<MenuItemModel> MenuItem, int? id)

        {
            try
            {
                return Json(_dbMenuItem.spMenuItemInsertBulk(MenuItem, id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public JsonResult InsertMenuItemBulk(ICollection<MenuItemModel> MenuItem,int ?id)

        {
            try
            {
                return Json(_dbMenuItem.spMenuItemInsertBulk(MenuItem,id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public JsonResult InsertSupplierMenuBulk(ICollection<SupplierMenuModel> SupplierMenuModel, int? id)

        {
            try
            {
                return Json(_dbSupplierMenu.spSupplierMenuInsertBulk(SupplierMenuModel, id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        // GET: MenuItem
        public ActionResult Index()
        {
            return View();
        }
    }
}