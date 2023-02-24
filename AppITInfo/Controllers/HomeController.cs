using AppITInfo.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppITInfo.Controllers
{
    public class HomeController : Controller
    {

        ITDb1Entities db = new ITDb1Entities();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["CID"] != null)
            {
                return RedirectToAction("Coordinator_Info", "Coordinator");
            }
            return View();
        }
        //
        public ActionResult College_Reg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult College_Reg(tbl_Teacher teacherModel)
        {
            try
            {
                teacherModel.IndexNo = teacherModel.IndexNo.Trim();
                String strIndexNo = teacherModel.IndexNo.Trim();
                bool isNonDigits = false;
                foreach (char c in strIndexNo)
                {
                    if (!Char.IsDigit(c))
                    {
                        if (c == ' ')
                        {
                            continue;
                        }
                        isNonDigits = true;
                        break;
                    }
                }
                if (teacherModel.IndexNo == null || teacherModel.IndexNo == "" || teacherModel.IndexNo.Length < 7)
                {
                    //return Json(new { success = false, message = "Please enter valid Index no" });
                    TempData["Index"] = "Please enter valid Index no";
                    return RedirectToAction("College_Reg", "Home");
                }


                if (teacherModel.Name == null || teacherModel.Name == "")
                {
                    //return Json(new { success = false, message = "Please enter name" });
                    TempData["name"] = "Please enter name";
                    return RedirectToAction("College_Reg", "Home");
                }
                String strName = teacherModel.Name.ToString().Trim();
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
                    TempData["alphabets"] = "Enter only alphabets for Name";
                    return RedirectToAction("College_Reg", "Home");

                }
                if (teacherModel.SUB == null)
                {
                    //return Json(new { success = false, message = "Please select subject" });
                    TempData["subject"] = "Please select subject";
                    return RedirectToAction("College_Reg", "Home");

                }
                if (teacherModel.MobileNo == null || teacherModel.MobileNo == "" || teacherModel.MobileNo.Trim().Length != 10)
                {
                    //return Json(new { success = false, message = "Please enter valid mobile number" });
                    TempData["MobileNo"] = "Please enter valid mobile number";
                    return RedirectToAction("College_Reg", "Home");

                }
                if (teacherModel.Password == null || teacherModel.Password == "")
                {
                    //return Json(new { success = false, message = "Please Enter password" });
                    TempData["Password"] = "Please Enter password";
                    return RedirectToAction("College_Reg", "Home");
                }
                if (teacherModel.ConfirmPassword == null || teacherModel.ConfirmPassword == "" || teacherModel.Password != teacherModel.ConfirmPassword)
                {
                    //return Json(new { success = false, message = "Passwords do not matched !" });
                    TempData["ConfirmPassword"] = "Passwords do not matched";
                    return RedirectToAction("College_Reg", "Home");
                }
                var AlreadyRegister = db.tbl_Teacher.Where(x => x.IndexNo == teacherModel.IndexNo.Trim()).FirstOrDefault();
                if (AlreadyRegister != null)
                {
                    //return Json(new { success = false, message = "You have already registered with this Index Number.please use _1 after Index No(eg.1111222_1) !" }, JsonRequestBehavior.AllowGet);

                    TempData["message"] = "You have already registered with this Index Number.please use _1 after Index No(eg.1111222_1";
                    return RedirectToAction("College_Reg", "Home");

                }
                var IndexNo = teacherModel.IndexNo.Trim();
                var disCode = IndexNo.Substring(0, 2);
                var DivCode = db.Tbl_Code_Master.Where(x => x.district_code == disCode).FirstOrDefault().division_code;
                var SubList = teacherModel.SUB.ToList();
                var SubCount = SubList.Count;
                if (SubCount == 1)
                {
                    teacherModel.Subject = SubList[0].ToString();
                }



                if (SubCount == 2)
                {
                    teacherModel.Subject = SubList[0].ToString() + "; " + SubList[1].ToString();
                }
                if (SubCount == 3)
                {
                    teacherModel.Subject = SubList[0].ToString() + "; " + SubList[1].ToString() + "; " + SubList[2].ToString();
                }
                teacherModel.DivisionCode = DivCode;
                db.tbl_Teacher.Add(teacherModel);
                db.SaveChanges();
                //return Json(new { success = true, message = "Your Registration is successful ! You may login now !" });
                TempData["successful"] = "You have already registered with this Index Number.please use _1 after Index No(eg.1111222_1";
                return RedirectToAction("College_Reg", "Home");

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Your Registration is failed !" });
                throw ex;
            }
        }

        public ActionResult Coordinator_Reg()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Coordinator_Reg(Tbl_Coordinator coordinator)
        {
            try
            {
                coordinator.IndexNo = coordinator.IndexNo.Trim();
                String strIndexNo = coordinator.IndexNo;
                bool isNonDigits = false;
                foreach (char c in strIndexNo)
                {
                    if (!Char.IsDigit(c))
                    {
                        if (c == ' ')
                        {
                            continue;
                        }
                        isNonDigits = true;
                        break;
                    }
                }
                if (coordinator.IndexNo == "" || coordinator.IndexNo == null || coordinator.IndexNo.Length != 7 || isNonDigits)
                {
                    return Json(new { success = false, message = "Please Enter valid Index No" }, JsonRequestBehavior.AllowGet);
                }
                if (coordinator.MobileNo == "" || coordinator.MobileNo == null || coordinator.MobileNo.Trim().Length != 10)
                {
                    return Json(new { success = false, message = "Please Enter valid Mobile number" }, JsonRequestBehavior.AllowGet);
                }
                if (coordinator.Name == "" || coordinator.Name == null)
                {
                    return Json(new { success = false, message = "Please Enter Name" }, JsonRequestBehavior.AllowGet);
                }
                String strName = coordinator.Name.ToString().Trim();
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
                    return Json(new { success = false, message = "Enter only alphabets for Name" }, JsonRequestBehavior.AllowGet);
                if (coordinator.Password == "" || coordinator.Password == null)
                {
                    return Json(new { success = false, message = "Please Enter password" }, JsonRequestBehavior.AllowGet);
                }
                if (coordinator.ConfirmPassword == "" || coordinator.ConfirmPassword == null || coordinator.Password != coordinator.ConfirmPassword)
                {
                    return Json(new { success = false, message = "Passwords do not matched" }, JsonRequestBehavior.AllowGet);
                }
                var AlreadyRegister = db.Tbl_Coordinator.Where(x => x.IndexNo == coordinator.IndexNo).FirstOrDefault();
                if (AlreadyRegister != null)
                {
                    return Json(new { success = false, message = "You have already registered ! You may login now !" }, JsonRequestBehavior.AllowGet);
                }
                db.Tbl_Coordinator.Add(coordinator);
                db.SaveChanges();
                return Json(new { success = true, message = "Your Registration is successful ! You may login now !" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Your Registration is failed !" });
                throw ex;
            }
        }
        public ActionResult College_Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult College_Login(tbl_Teacher tbl_teacher)
        {

            try
            {
                var IsValid = db.tbl_Teacher.Where(c => c.IndexNo == tbl_teacher.IndexNo && c.Password == tbl_teacher.Password).FirstOrDefault();
                if (IsValid != null)
                {
                    Session["TID"] = IsValid.IndexNo;
                    Session["User_Name"] = IsValid.Name;
                    FormsAuthentication.SetAuthCookie(tbl_teacher.IndexNo, false);
                    return RedirectToAction("college_data", "College");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Details.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public ActionResult Coordinator_Login()
        {
            try
            {
                if (Session["User_Name"] != null)
                {

                    return RedirectToAction("Coordinator_Info", "Coordinator");
                }

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Coordinator_Login(Tbl_Coordinator tbl_Coordinator)
        {

            try
            {
                var IsValid = db.Tbl_Coordinator.Where(c => c.IndexNo == tbl_Coordinator.IndexNo && c.Password == tbl_Coordinator.Password).FirstOrDefault();
                if (IsValid != null)
                {
                    Session["CID"] = IsValid.CID;
                    Session["User_Name"] = IsValid.Name;
                    FormsAuthentication.SetAuthCookie(tbl_Coordinator.IndexNo, false);
                    return RedirectToAction("Coordinator_Info", "Coordinator");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Details.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Logout()
        {
            try
            {
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int LogoutCheck()
        {
            if (Session["User_Name"] == null)
            {
                return 1;
            }
            return 0;
        }
        public ActionResult Moderator_Reg()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Moderator_Reg(Tbl_Moderator Model)
        {
            try
            {
                Model.IndexNo = Model.IndexNo.Trim();
                String strIndexNo = Model.IndexNo.Trim();
                bool isNonDigits = false;
                foreach (char c in strIndexNo)
                {
                    if (!Char.IsDigit(c))
                    {
                        if (c == ' ')
                        {
                            continue;
                        }
                        isNonDigits = true;
                        break;
                    }
                }
                if (Model.IndexNo == null || Model.IndexNo == "" || Model.IndexNo.Length != 7 || isNonDigits)
                {
                    return Json(new { success = false, message = "Please enter valid Index no" });
                }
                if (Model.Name == null || Model.Name == "")
                {
                    return Json(new { success = false, message = "Please enter name" });
                }
                String strName = Model.Name.ToString().Trim();
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
                    return Json(new { success = false, message = "Enter only alphabets for Name" }, JsonRequestBehavior.AllowGet);
                if (Model.SUB == null)
                {
                    return Json(new { success = false, message = "Please select subject" });
                }
                if (Model.MobileNo == null || Model.MobileNo == "" || Model.MobileNo.Trim().Length != 10)
                {
                    return Json(new { success = false, message = "Please enter valid mobile number" });
                }
                if (Model.Password == null || Model.Password == "")
                {
                    return Json(new { success = false, message = "Please Enter password" });
                }
                if (Model.ConfirmPassword == null || Model.ConfirmPassword == "" || Model.Password != Model.ConfirmPassword)
                {
                    return Json(new { success = false, message = "Passwords do not matched !" });
                }
                var AlreadyRegister = db.Tbl_Moderator.Where(x => x.IndexNo == Model.IndexNo.Trim()).FirstOrDefault();
                if (AlreadyRegister != null)
                {
                    return Json(new { success = false, message = "You have already registered ! You may login now !" }, JsonRequestBehavior.AllowGet);
                }
                var IndexNo = Model.IndexNo.Trim();
                var disCode = IndexNo.Substring(0, 2);
                var DivCode = db.Tbl_Code_Master.Where(x => x.district_code == disCode).FirstOrDefault().division_code;
                var SubList = Model.SUB.ToList();
                var SubCount = SubList.Count;
                if (SubCount == 1)
                {
                    Model.Subject = SubList[0].ToString();
                }
                if (SubCount == 2)
                {
                    Model.Subject = SubList[0].ToString() + "; " + SubList[1].ToString();
                }
                if (SubCount == 3)
                {
                    Model.Subject = SubList[0].ToString() + "; " + SubList[1].ToString() + "; " + SubList[2].ToString();
                }
                Model.DivisionCode = DivCode;
                db.Tbl_Moderator.Add(Model);
                db.SaveChanges();
                return Json(new { success = true, message = "Your Registration is successful ! You may login now !" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Your Registration is failed !" });
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult Moderator_Login()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Moderator_Login(Tbl_Moderator Moderator)
        {

            try
            {
                var IsValid = db.Tbl_Moderator.Where(c => c.IndexNo == Moderator.IndexNo && c.Password == Moderator.Password).FirstOrDefault();
                if (IsValid != null)
                {
                    Session["TID"] = IsValid.IndexNo;
                    Session["User_Name"] = IsValid.Name;
                    FormsAuthentication.SetAuthCookie(Moderator.IndexNo, false);
                    return RedirectToAction("Moderator_Info", "Moderator");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Details.");
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
