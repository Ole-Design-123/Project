using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using AppITInfo.Models;
using System.Web.Security;
using System.Data.SqlClient;

namespace AppITInfo.Controllers
{
    public class CollegeController : Controller
    {
        SqlConnection con = new SqlConnection();
        // GET: College
        ITDb1Entities db = new ITDb1Entities();
        DataAccessLayer dataAccessLayer = new DataAccessLayer();
        
        public ActionResult College_Info()
        {
            tbl_Teacher appUser = new tbl_Teacher();
            Tbl_AllAns tbl_AllAns = new Tbl_AllAns();
            var IndexNo = this.User.Identity.Name;
            if (IndexNo == "")
            {
                return RedirectToAction("College_Login", "Home");
            }
            else
            {
                appUser = db.tbl_Teacher.Where(m => m.IndexNo == IndexNo).FirstOrDefault();
                Session["User_Name"] = appUser.Name;
                var TeacherReport = new CoordCollegeViewModel
                {
                    TID = IndexNo.ToString(),
                    TotalPapers = (from p in db.Tbl_AllAns where p.TID == IndexNo select p).Count().ToString(),
                    CompletePapers = (from p in db.Tbl_AllAns where p.TID == IndexNo && p.PStatus == "Complete" select p).Count().ToString(),
                    IncompletePapers = (from p in db.Tbl_AllAns where p.TID == IndexNo && p.PStatus == "Incomplete" select p).Count().ToString(),
                    SkipPapers = (from p in db.Tbl_AllAns where p.TID == IndexNo && p.PStatus == "Skip" select p).Count().ToString()

                };
                return View(TeacherReport);
            }
        }

        public JsonResult getTeacherInfo()
        {

            var IndexNo = this.User.Identity.Name;
            var tbl = db.tbl_Teacher.Where(a => a.IndexNo == IndexNo).FirstOrDefault();
            return Json(tbl, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditDetails(tbl_Teacher tbl_teacher)
        {
            var IndexNo = this.User.Identity.Name;
            if (IndexNo == null || IndexNo == "")
            {
                return RedirectToAction("College_Login", "Home");
            }
            var tbl = db.tbl_Teacher.Where(a => a.IndexNo == IndexNo).FirstOrDefault();
            return View(tbl);
        }

        [HttpPost]
        public ActionResult College_update(tbl_Teacher tbl_teacher)
        {
            var IndexNo = this.User.Identity.Name;
            if (IndexNo == "" || IndexNo == null)
            {
                return Json(new { Result = "Submitted", Message = "../College_Login" });
            }
            var olddata = (from a in db.tbl_Teacher where a.IndexNo == IndexNo select a).ToList();
            String strIndexNo = tbl_teacher.IndexNo;
            bool isNonDigits = false;
            foreach (char c in strIndexNo)
            {
                if (!char.IsDigit(c))
                {
                    if (c == ' ')
                    {
                        continue;
                    }
                    isNonDigits = true;
                    break;
                }
            }
            if (tbl_teacher.IndexNo == null || tbl_teacher.IndexNo == "" || tbl_teacher.IndexNo.Length < 7)
            {
                //return Json(new { success = false, message = "Please enter valid Index no" });
                TempData["msg"] = "Please enter valid Index no";

                return RedirectToAction("EditDetails", "College");

            }
            if (tbl_teacher.Name == null || tbl_teacher.Name == "")
            {
                //return Json(new { success = false, message = "Please enter name" });
                TempData["msg1"] = "Please enter Name";

                return RedirectToAction("EditDetails", "College");
            }
            String strName = tbl_teacher.Name.ToString().Trim();
            bool containsNonAlphabets = false;
            foreach (char c in strName)
            {
                if (!Char.IsLetter(c))
                {
                    if (c == ' ')
                    {
                        continue;
                    }
                    containsNonAlphabets = true;
                    break;
                }
            }
            if (containsNonAlphabets)
            {
                //return Json(new { success = false, message = "Enter only alphabets for Name" }, JsonRequestBehavior.AllowGet);
                TempData["msg2"] = "Please Enter only alphabets for Name";

                return RedirectToAction("EditDetails", "College");
            }
            if (tbl_teacher.Subject == null)
            {
                return Json(new { success = false, message = "Please select stream" });
            }
            var SubList = tbl_teacher.Subject.ToList();
            var SubCount = SubList.Count;
            if (SubCount == 1)
            {
                tbl_teacher.Subject = SubList[0].ToString();
            }
            if (SubCount == 2)
            {
                tbl_teacher.Subject = SubList[0].ToString() + "; " + SubList[1].ToString();
            }
            if (SubCount == 3)
            {
                tbl_teacher.Subject = SubList[0].ToString() + "; " + SubList[1].ToString() + "; " + SubList[2].ToString();
            }
            if (tbl_teacher.MobileNo == null || tbl_teacher.MobileNo == "" || tbl_teacher.MobileNo.Length != 10)
            {
                return Json(new { success = false, message = "Please enter valid mobile number" });
            }
            var disCode = tbl_teacher.IndexNo.Substring(0, 2);
            var DivCode = db.Tbl_Code_Master.Where(x => x.district_code == disCode).FirstOrDefault().division_code;
            if (IndexNo != tbl_teacher.IndexNo)
            {
                DataTable isExist = dataAccessLayer.ReturnDataTable(@"select IndexNo from [ITDb1].[dbo].[tbl_Teacher] where IndexNo = '" + tbl_teacher.IndexNo + "'");
                if (isExist.Rows.Count > 0)
                {
                    return Json(new { success = false, message = "Index no already in use" });
                }
            }
            foreach (var i in olddata)
            {
                i.IndexNo = tbl_teacher.IndexNo;
                i.DivisionCode = DivCode;
                i.Name = tbl_teacher.Name;
                i.Subject = tbl_teacher.Subject;
                i.MobileNo = tbl_teacher.MobileNo;
                db.SaveChanges();
            }
            FormsAuthentication.SetAuthCookie(tbl_teacher.IndexNo, false);
            return Json(new { success = true, message = "Your profile is updated", Result = "Submitted", Message = "../College_Info" });
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public JsonResult College_Pass_Update(tbl_Teacher tbl_teacher)
        {
            var IndexNo = this.User.Identity.Name;
            if (IndexNo == "" || IndexNo == null)
            {
                return Json(new { Result = "Submitted", Message = "../Home/College_Login" });
            }
            var teacherData = db.tbl_Teacher.Where(x => x.IndexNo == IndexNo).FirstOrDefault();
            if (tbl_teacher.Password == "" || tbl_teacher.Password == null)
            {
                return Json(new { success = false, message = "Please Enter old password" });
            }
            if (tbl_teacher.Password != teacherData.Password)
            {
                return Json(new { success = false, message = "Old password do not matched" });
            }
            if (tbl_teacher.Password == "" || tbl_teacher.Password == null)
            {
                return Json(new { success = false, message = "Please Enter new password" });
            }
            if (tbl_teacher.Password == "" || tbl_teacher.Password == null || tbl_teacher.Password != tbl_teacher.Password)
            {
                return Json(new { success = false, message = "New password and confirm password do not matched" });
            }
            teacherData.Password = tbl_teacher.Password;
            db.SaveChanges();
            Session.Abandon();
            Session.Clear();
            FormsAuthentication.SignOut();
            return Json(new { Result = "Submitted", message = "Your password has been changed successfully ! please login again !", Message = "../Home/College_Login" });
        }

        [HttpGet]
        public ActionResult college_data()
        {
            tbl_Teacher appUser = new tbl_Teacher();
            Tbl_AllAns tbl_AllAns = new Tbl_AllAns();
            Tbl_Model_Ans_New man = new Tbl_Model_Ans_New();
            var IndexNo = this.User.Identity.Name;
            if (IndexNo == "")
            {
                return RedirectToAction("College_Login", "Home");
            }
            else
            {
                appUser = db.tbl_Teacher.Where(m => m.IndexNo == IndexNo).FirstOrDefault();
                Session["User_Name"] = appUser.Name;
                
                CoordCollegeViewModel c=new CoordCollegeViewModel();
                c.TID = IndexNo.ToString();
                c.TName = appUser.Name;
                c.stream = appUser.Subject;
                //Assigned=(from p in db.Tbl_AllAns where p.TID == IndexNo select p).Count().ToString(),
                c.TotalPapers = (from p in db.Tbl_AllAns where p.TID == IndexNo select p).Count().ToString();
                c.CompletePapers = (from p in db.Tbl_AllAns where p.TID == IndexNo && p.PStatus == "Complete" select p).Count().ToString();
                c.IncompletePapers = (from p in db.Tbl_AllAns where p.TID == IndexNo && p.PStatus == "Incomplete" select p).Count().ToString();
                c.SkipPapers = (from p in db.Tbl_AllAns where p.TID == IndexNo && p.PStatus == "Skip" select p).Count().ToString();
                var paper_id = db.Tbl_AllAns.Where(x => x.TID == c.TID).Select(a=>a.Paper_ID).FirstOrDefault();
                c.tbl_Model_Ans = db.Tbl_Model_Ans_New.Where(x => x.Paper_ID == paper_id).ToList();
                c.allans = db.Tbl_AllAns.Where(x => x.TID == c.TID && x.PStatus == "Incomplete").Take(1).ToList();
                
                
                return View(c);


            }
        }

        [HttpPost]
        public void AddMrks(CoordCollegeViewModel cv)
        {
            Tbl_AllAns an = new Tbl_AllAns();
           
        }


    }
}








// https://www.compilemode.com/2021/04/post-data-to-controller-using-jquery-ajax-in-asp-net-mvc.html