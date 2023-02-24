using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppITInfo.Models
{
    public class DivReportViewModel
    {
        public string Stream { get; set; }
        public string DivCode { get; set; }
        public string DivNotAssignedPapers { get; set; }

        public string DivAssignedPapers { get; set; }
        public string DivCompletePapers { get; set; }

        public string DivIncompletePapers { get; set; }
        public string DivSkipPapers { get; set; }
    }
}