using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppITInfo.Models;

namespace AppITInfo.Controllers
{

    public class ModeratorController : Controller
    {
        ITDb1Entities db = new ITDb1Entities();
        DataAccessLayer dataAccessLayer = new DataAccessLayer();
        // GET: Moderator
        public ActionResult Moderator_Info()
        {
            db.Configuration.ProxyCreationEnabled = false;
            Tbl_Moderator appUser = new Tbl_Moderator();
            Tbl_AllAns tbl_AllAns = new Tbl_AllAns();
            var IndexNo = this.User.Identity.Name;
            if (IndexNo == null || IndexNo == "")
            {
                return RedirectToAction("Moderator_Login", "Home");
            }
            else
            {
                appUser = db.Tbl_Moderator.Where(m => m.IndexNo == IndexNo).FirstOrDefault();
                Session["User_Name"] = appUser.Name;
                string distcode = appUser.IndexNo.Substring(0, 2);
                var divcode = db.Tbl_Code_Master.Where(m => m.district_code == distcode).FirstOrDefault().division_code;
                DataTable TotalData = dataAccessLayer.ReturnDataTable(@"select count(A.ID) total from Tbl_Marks A, Tbl_AllAns B where A.Seat_No = B.Seat_No and B.DivisionCode = '"+divcode+"'");
                var ModeratorReport = new ModeratorModel
                {
                    MID = IndexNo.ToString(),
                    MName=appUser.Name,
                    TotalPapers = TotalData.Rows[0]["total"].ToString(),
                    CompletePapers = (from p in db.Tbl_Moderator_Marks where p.Moderator_Index_No == IndexNo select p).Count().ToString(),
                };
                return View(ModeratorReport);
            }
        }
        //return View();
    }
}