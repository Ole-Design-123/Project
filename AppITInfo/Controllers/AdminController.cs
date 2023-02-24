using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppITInfo.Models;
using AppITInfo.Helper;
using Newtonsoft.Json;

namespace AppITInfo.Controllers
{
    public class AdminController : Controller
    {
        ITDb1Entities db = new ITDb1Entities();
        Common common = new Common();
        // GET: Admin
        public ActionResult Admin_Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin_Login(Tbl_Admin ss)
        {
            try
            {
                string IndexNo = "1111222";
                string Password = "ss";
                if (ss.Index_No == IndexNo && ss.Password == Password)
                {
                    return RedirectToAction("Get_Admin_Record", "Admin");

                }
                else
                {
                    TempData["Msg"] = "Incorrect ID or Password";
                    //return View();
                }

            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Something Went Wrong" + ex;

            }
            return View();
        }
        // GET: Admin
        public ActionResult Get_Admin_Record()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Get_Admin_Record(Tbl_Model_Ans_New ss)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(ss.PaperID.FileName);
                if (ss.PaperID != null)
                {
                    if (!db.Tbl_Model_Ans_New.Any(x => x.Paper_ID == filename))
                    {
                        string Filename = Path.GetFileNameWithoutExtension(ss.PaperID.FileName);
                        ss.Papers_Path = "~/Application_Uploads/Papers/" + Filename + ".txt";
                        ss.Paper_ID = Filename;
                        ss.PaperID.SaveAs(Path.Combine(Server.MapPath("~/Application_Uploads/Papers/"), Filename + ".txt"));
                        db.Tbl_Model_Ans_New.Attach(ss);
                        db.Entry(ss).Property(x => x.Papers_Path).IsModified = true;
                        db.Entry(ss).Property(x => x.Paper_ID).IsModified = true;

                        List<Question_Paper> question = new List<Question_Paper>();



                        using (StreamReader r = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Application_Uploads/Papers/" + Filename + ".txt")))
                        {
                            var json = r.ReadToEnd();
                            Question_Paper info = JsonConvert.DeserializeObject<Question_Paper>(json);

                            ss.Question_No = "1";
                            ss.Sub_Question = "1";
                            ss.Question = info.Question1.Q1Question1;

                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "1";
                            ss.Sub_Question = "2";
                            ss.Question = info.Question1.Q1Question2;

                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "1";
                            ss.Sub_Question = "3";
                            ss.Question = info.Question1.Q1Question3;

                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "1";
                            ss.Sub_Question = "4";
                            ss.Question = info.Question1.Q1Question4;

                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "1";
                            ss.Sub_Question = "5";
                            ss.Question = info.Question1.Q1Question5;

                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "1";
                            ss.Sub_Question = "6";
                            ss.Question = info.Question1.Q1Question6;

                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "1";
                            ss.Sub_Question = "7";
                            ss.Question = info.Question1.Q1Question7;

                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "1";
                            ss.Sub_Question = "8";
                            ss.Question = info.Question1.Q1Question8;

                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "1";
                            ss.Sub_Question = "9";
                            ss.Question = info.Question1.Q1Question9;

                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "1";
                            ss.Sub_Question = "10";
                            ss.Question = info.Question1.Q1Question10;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "7";
                            ss.Sub_Question = "1";
                            ss.Question = info.Question7.Q7Question1;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "7";
                            ss.Sub_Question = "2";
                            ss.Question = info.Question7.Q7Question2;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "7";
                            ss.Sub_Question = "3";
                            ss.Question = info.Question7.Q7Question3;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "7";
                            ss.Sub_Question = "4";
                            ss.Question = info.Question7.Q7Question4;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();


                            ss.Question_No = "7";
                            ss.Sub_Question = "5";
                            ss.Question = info.Question7.Q7Question5;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();
                            ss.Question_No = "7";
                            ss.Sub_Question = "6";
                            ss.Question = info.Question7.Q7Question6;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();
                            ss.Question_No = "7";
                            ss.Sub_Question = "7";
                            ss.Question = info.Question7.Q7Question7;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "7";
                            ss.Sub_Question = "8";
                            ss.Question = info.Question7.Q7Question8;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();

                            ss.Question_No = "8";
                            ss.Sub_Question = "1";
                            ss.Question = info.Question8.Q8Question1;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();
                            ss.Question_No = "8";
                            ss.Sub_Question = "2";
                            ss.Question = info.Question8.Q8Question2;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();
                            ss.Question_No = "8";
                            ss.Sub_Question = "3";
                            ss.Question = info.Question8.Q8Question3;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();
                            ss.Question_No = "8";
                            ss.Sub_Question = "4";
                            ss.Question = info.Question8.Q8Question4;
                            db.Tbl_Model_Ans_New.Add(ss);
                            db.SaveChanges();
                            question.Add(info);
                        }
                    }
                    else
                    {
                        return Json(new { Result = false, Response = "File Already Exists!" }, JsonRequestBehavior.AllowGet);
                    }

                    return Json(new { Result = true, Response = "file Suceessfully save" }, JsonRequestBehavior.AllowGet);

                }


                return Json(new { Result = true, Response = "file Suceessfully save" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { Result = false, Response = "Failed to save " + ex }, JsonRequestBehavior.AllowGet);
            }


        }

        [HttpGet]
        public ActionResult Get_ModelAns_Excel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Export_To_Excel(string paper)
        {
            string fileName = "";

            try
            {
                var record = db.Tbl_Model_Ans_New.Where(x => x.Paper_ID == paper && x.Question_No == "1").ToList();


                //return Json(new { Result = true, Response = record }, JsonRequestBehavior.AllowGet);
                //List<Tbl_Model_Ans_New> model = db.Database.SqlQuery<Tbl_Model_Ans_New>(Query).ToList();
                if (record != null)
                {
                    System.Data.DataTable dt = common.ToDataTable(record);
                    dt.TableName = "Question for model answer";
                    fileName = paper;
                    common.CreateExcelFile(dt, fileName);

                }
                return Json(new { Result = true, Response = record, FileName = fileName }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Response = "Fail To fetch Record" + ex }, JsonRequestBehavior.AllowGet);

            }
        }


    }

}
