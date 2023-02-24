using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppITInfo.Models;
using AppITInfo.Helper;

namespace AppITInfo.Controllers
{
    public class CoordinatorController : Controller
    {
        // GET: Coordinator

        ITDb1Entities db = new ITDb1Entities();
        DataAccessLayer dataAccessLayer = new DataAccessLayer();
        Tbl_Coordinator appUser = new Tbl_Coordinator();
        Common common = new Common();

        public ActionResult Coordinator_Info()
        {
            var IndexNo = this.User.Identity.Name;
            if (IndexNo == "")
            {
                return RedirectToAction("Coordinator_Login", "Home");
            }
            else
            {
                int Index_No = int.Parse(IndexNo);
              
                appUser = db.Tbl_Coordinator.Where(m => m.IndexNo == IndexNo).FirstOrDefault();
                Session["User_Name"] = appUser.Name;
                var disCode = IndexNo.Substring(0, 2);
                var DivCode = db.Tbl_Code_Master.Where(x => x.district_code == disCode).FirstOrDefault().division_code;
                List<CoordCollegeViewModel> coordViewModel = new List<CoordCollegeViewModel>();
                //DataTable dt = dataAccessLayer.ReturnDataTable(@"select * FROM(select distinct(PStatus) PStatus, TID, count(TID) TCONT " +
                //                                                "from (select * from Tbl_AllAns union all select * from Tbl_AllAns_bk1) Z where divisionCode = " + DivCode + " and TID is not null" +
                //                                                " group by TID, PStatus) Z PIVOT (SUM(TCONT) for [PStatus] in ([Complete],[Incomplete],[Skip])) AS X ORDER BY TID");
                DataTable dt = dataAccessLayer.ReturnDataTable(@"select * FROM(select distinct(PStatus) PStatus, TID, count(TID) TCONT " +
                                                                "from Tbl_AllAns where divisionCode = " + DivCode + " and TID is not null" +
                                                                " group by TID, PStatus) Z PIVOT (SUM(TCONT) for [PStatus] in ([Complete],[Incomplete],[Skip])) AS X");

                foreach (DataRow drow in dt.Rows)
                {
                    CoordCollegeViewModel teacherList = new CoordCollegeViewModel();
                    teacherList.TID = drow["TID"].ToString();
                    string streams = db.tbl_Teacher.Where(x => x.IndexNo == teacherList.TID).FirstOrDefault().Subject;
                    teacherList.CompletePapers = drow["Complete"].ToString() == "" ? "0" : drow["Complete"].ToString();
                    teacherList.IncompletePapers = drow["Incomplete"].ToString() == "" ? "0" : drow["Incomplete"].ToString();
                    teacherList.SkipPapers = drow["Skip"].ToString() == "" ? "0" : drow["Skip"].ToString();
                    var total = Int32.Parse(teacherList.CompletePapers) + Int32.Parse(teacherList.IncompletePapers) + Int32.Parse(teacherList.SkipPapers);
                    teacherList.stream = streams;
                    teacherList.TotalPapers = total.ToString();
                    coordViewModel.Add(teacherList);
                }
                return View(coordViewModel);
            }
        }
        public JsonResult getSearchingData(string SearchValue)
        {
            SearchValue = SearchValue.Trim();
            bool isNonDigits = false;
            foreach (char c in SearchValue)
            {
                if (!Char.IsDigit(c))
                {
                    isNonDigits = true;
                    break;
                }
            }
            if (SearchValue == "" || SearchValue == null || SearchValue.Length < 7 )
            {
                return Json(new { success = false, message = "Please Enter valid Index No" }, JsonRequestBehavior.AllowGet);
            }
            List<CoordCollegeViewModel> TeacherList = new List<CoordCollegeViewModel>();
            CoordCollegeViewModel TeacherRow = new CoordCollegeViewModel();
            var IndexNo = this.User.Identity.Name;
            var disCode = IndexNo.Substring(0, 2);
            var DivCode = db.Tbl_Code_Master.Where(x => x.district_code == disCode).FirstOrDefault().division_code;
            var searchDisCode = SearchValue.Substring(0, 2);
            var searchDivCode = db.Tbl_Code_Master.Where(x => x.district_code == searchDisCode).FirstOrDefault().division_code;
            if (DivCode != searchDivCode)
            {
                return Json(new { success = false, message = "Invalid Index No" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var completecnt = (from p in db.Tbl_AllAns where p.TID == SearchValue && p.PStatus == "Complete" && p.DivisionCode == DivCode select p).Count();
                var incompletecnt = (from p in db.Tbl_AllAns where p.TID == SearchValue && p.PStatus == "Incomplete" && p.DivisionCode == DivCode select p).Count();
                var skipcnt = (from p in db.Tbl_AllAns where p.TID == SearchValue && p.PStatus == "Skip" && p.DivisionCode == DivCode select p).Count();
                var totpapers = completecnt + incompletecnt + skipcnt;
                TeacherRow.TID = SearchValue;
                TeacherRow.TotalPapers = totpapers.ToString();
                TeacherRow.IncompletePapers = incompletecnt.ToString();
                TeacherRow.CompletePapers = completecnt.ToString();
                TeacherRow.SkipPapers = skipcnt.ToString();
                TeacherList.Add(TeacherRow);
                return Json(TeacherList, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult getDivReport()
        {
            var IndexNo = this.User.Identity.Name;
            var disCode = IndexNo.Substring(0, 2);
            var DivCode = db.Tbl_Code_Master.Where(x => x.district_code == disCode).FirstOrDefault().division_code;
            List<DivReportViewModel> Reportlist = new List<DivReportViewModel>();
            //DataTable dt1 = dataAccessLayer.ReturnDataTable(@"select X.*,(X.Complete+X.Incomplete+X.Skip) Assigned FROM(select  isnull(PStatus,'Not_Assign') PStatus,Stream 
            //                                                from (select * from Tbl_AllAns union all select * from Tbl_AllAns_bk1) Z where divisionCode = '" + DivCode + "') Z PIVOT(count(PStatus) for [PStatus] in ([Not_Assign],[Complete],[Incomplete],[Skip])) AS X");
            DataTable dt1 = dataAccessLayer.ReturnDataTable(@"select X.*,(X.Complete+X.Incomplete+X.Skip) Assigned FROM(select  isnull(PStatus,'Not_Assign') PStatus,Stream 
                                                            from Tbl_AllAns where divisionCode = '" + DivCode + "') Z PIVOT(count(PStatus) for [PStatus] in ([Not_Assign],[Complete],[Incomplete],[Skip])) AS X");
            foreach (DataRow drow in dt1.Rows)
            {
                DivReportViewModel DivRow = new DivReportViewModel();
                DivRow.Stream = drow["Stream"].ToString();
                DivRow.DivCompletePapers = drow["Complete"].ToString();
                DivRow.DivIncompletePapers = drow["Incomplete"].ToString();
                DivRow.DivNotAssignedPapers = drow["Not_Assign"].ToString();
                DivRow.DivSkipPapers = drow["Skip"].ToString();
                DivRow.DivAssignedPapers = drow["Assigned"].ToString();
                Reportlist.Add(DivRow);
            }
            return Json(Reportlist, JsonRequestBehavior.AllowGet);
        }
        public JsonResult paperAssign(string PaperCount, string TID, string Stream)
        {

            TID = TID.Trim();        
                 
             PaperCount = PaperCount.Trim();
            if (TID == "" || TID == null || TID.Length < 7)
            {
                return Json(new { success = false, message = "Please Enter valid Index No" }, JsonRequestBehavior.AllowGet);
            }
            //if (PaperCount == "" || PaperCount == null || Int32.Parse(TID) < 1 || isNonDigits(PaperCount))
            if (PaperCount == "" || PaperCount == null ||  isNonDigits(PaperCount))
            {
                return Json(new { success = false, message = "Please Enter valid no of papers" }, JsonRequestBehavior.AllowGet);
            }
            if (Stream == null)
            {
                return Json(new { success = false, message = "Please select stream" }, JsonRequestBehavior.AllowGet);
            }
            bool ContainStream = isContainStream(Stream);
            if (!ContainStream)
            {
                return Json(new { success = false, message = "Paper allotment failed !" }, JsonRequestBehavior.AllowGet);
            }
            bool isContainStream(string Subject)
            {
                int found = 0;
                DataTable streamcell = dataAccessLayer.ReturnDataTable(@"SELECT Subject FROM tbl_Teacher where IndexNo = '" + TID + "'");
                if (streamcell.Rows.Count > 0)
                {
                    string[] IndexStreams = streamcell.Rows[0]["Subject"].ToString().Split(';');
                    for (int j = 0; j < IndexStreams.Length; j++)
                    {
                        if (Stream == IndexStreams[j].Trim())
                            found++;
                    }
                    if (found > 0)
                        return true;
                }
                return false;
            }
            bool isNonDigits(string str)
            {
                int flag = 0;
                foreach (char c in str)
                {
                    if (!Char.IsDigit(c))
                    {
                        flag++;
                        break;
                    }
                }
                if (flag > 0)
                    return true;
                else
                    return false;
            }

            string[] streamlist = Stream.Split(';');
            int allotpaper = 0;
            var IndexNo = this.User.Identity.Name;
            var disCode = IndexNo.Substring(0, 2);
            var CordDivCode = db.Tbl_Code_Master.Where(x => x.district_code == disCode).FirstOrDefault().division_code;
            var assignDisCode = TID.Substring(0, 2);
            var assignDivCode = db.Tbl_Code_Master.Where(x => x.district_code == assignDisCode).FirstOrDefault().division_code;

            //if(assignDivCode == "9")
            //{
            DataTable dt1 = dataAccessLayer.ReturnDataTable(@"select X.*,(X.Complete+X.Incomplete+X.Skip) Assigned FROM(select  isnull(PStatus,'Not_Assign') PStatus,Stream 
                                                            from Tbl_AllAns where divisionCode = '" + CordDivCode + "') Z PIVOT(count(PStatus) for [PStatus] in ([Not_Assign],[Complete],[Incomplete],[Skip])) AS X");
            int artcnt = 0, commcnt = 0, scicnt = 0;
            if (dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    if (dt1.Rows[i]["Stream"].ToString() == "Arts")
                    {
                        artcnt = Int32.Parse(dt1.Rows[i]["Not_Assign"].ToString());
                    }
                    if (dt1.Rows[i]["Stream"].ToString() == "Commerce")
                    {
                        commcnt = Int32.Parse(dt1.Rows[i]["Not_Assign"].ToString());
                    }
                    if (dt1.Rows[i]["Stream"].ToString() == "Science")
                    {
                        scicnt = Int32.Parse(dt1.Rows[i]["Not_Assign"].ToString());
                    }
                }
            }

            switch (Stream)
            {
                case "Arts":
                    if (artcnt < Int32.Parse(PaperCount))
                        return Json(new { Result = "Failed", Message = "Sorry, Cannot assign more than existing number of papers of Arts !" }, JsonRequestBehavior.AllowGet);
                    break;

                case "Commerce":
                    if (commcnt < Int32.Parse(PaperCount))
                        return Json(new { Result = "Failed", Message = "Sorry, Cannot assign more than existing number of papers of Commerce !" }, JsonRequestBehavior.AllowGet);
                    break;

                case "Science":
                    if (scicnt < Int32.Parse(PaperCount))
                        return Json(new { Result = "Failed", Message = "Sorry, Cannot assign more than existing number of papers of Science !" }, JsonRequestBehavior.AllowGet);
                    break;
            }
            allotpaper = dataAccessLayer.ExecuteNonQuery("update top(" + PaperCount + ") Tbl_AllAns set tid ='" + TID + "', Pstatus = 'Incomplete' where tid is null and Stream ='" + Stream + "' and DivisionCode = '" + CordDivCode + "' ");

            if (allotpaper > 0)
                return Json(new { Result = "Updated", Message = "Papers alloted successfully !" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Result = "Failed", Message = "Papers allotement failed !" }, JsonRequestBehavior.AllowGet);

            //}
            //else if (assignDivCode != CordDivCode)
            //{
            //    return Json(new { success = false, message = "Invalid Index No" });
            //}

            return Json(new { success = false, message = "Invalid Index No" });
        }
        public JsonResult clearSkipPaper(string IndexNo)
        {
            int clearskip = dataAccessLayer.ExecuteNonQuery(@"Update Tbl_AllAns set TID = null, PStatus = null, DateTime = null where TID = '" + IndexNo + "' and PStatus = 'Skip'");
            if (clearskip > 0)
            {
                return Json(new { Result = "Cleared", Message = "'Skipped' rack of Index no " + IndexNo + " is cleared successfully !" });
            }
            else
                return Json(new { Result = "Failed", Message = "Clear operation for " + IndexNo + " is failed !" });
        }
        [HttpGet]
        public ActionResult teacherData(tbl_Teacher tbl_teacher)
        {
            var IndexNo = this.User.Identity.Name;
            if (IndexNo == "" || IndexNo == null)
            {
                return RedirectToAction("Coordinator_Login", "Home");
            }
            var disCode = IndexNo.Substring(0, 2);
            var CordDivCode = db.Tbl_Code_Master.Where(x => x.district_code == disCode).FirstOrDefault().division_code;
            List<tbl_Teacher> teacherList = new List<tbl_Teacher>();
            teacherList = db.tbl_Teacher.Where(x => x.DivisionCode == CordDivCode).OrderBy(x => x.IndexNo).ToList();
            return View(teacherList);
        }

        [HttpGet]
        public ActionResult Model_Ans_Paper()
        {


            try
            {
                List<SelectListItem> li = common.BindPaper();
                ViewBag.paper = li;

                return View();
            }
            catch (Exception e)
            {

            }

            return View();
        }
        [HttpPost]
        public JsonResult Get_Data(String paper_id)
        {
            try
            {

                var tbl = db.Tbl_Model_Ans_New.Where(m => m.Paper_ID == paper_id && m.Question_No == "1").ToList();

       
                    return Json(new { Result = true, Response = tbl }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exe)
            {
                return Json(new { Result = false, Response = "Fail To Save Record" }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]

      
        public JsonResult Tbl_Update(List<Tbl_Model_Ans_New> paper)
        {
            try
            {
                int insertedRecords = 0;


                if (paper == null)
                {
                    paper = new List<Tbl_Model_Ans_New>();
                }
                foreach (Tbl_Model_Ans_New data in paper)
                {
                  var oldrecord = db.Tbl_Model_Ans_New.Where(x => x.ID == data.ID).FirstOrDefault();

                    oldrecord.Model_Ans = data.Model_Ans;
               
                 db.Tbl_Model_Ans_New.Attach(oldrecord);

                    db.Entry(oldrecord).Property(x => x.Model_Ans).IsModified = true;
                  

                    db.SaveChanges();
                    insertedRecords++;
                }
                return Json(new { Result = true, Response = "Record Successfully Updated!!!!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(new { Result = false, Response = "Fail to update record" }, JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);

        }



    }
}