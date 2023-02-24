using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppITInfo.Models
{
    public class CoordCollegeViewModel
    {
        public string TID { get; set; }
        public string TName { get; set; }
        public string TotalPapers { get; set; }
        public string stream { get; set; }

        public string Assigned { get; set; }
        public string CompletePapers { get; set; }

        public string IncompletePapers { get; set; }
        public string SkipPapers { get; set; }

        public string Stream { get; set; }
        public string Paper_ID { get; set; }
        public List<Tbl_Model_Ans_New> tbl_Model_Ans { get; set; }
        public List<Tbl_AllAns> allans { get; set; }
    }
}