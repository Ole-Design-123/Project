using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AppITInfo.Models;
using Newtonsoft.Json;
using OfficeOpenXml;

namespace AppITInfo.Helper
{
    public class Common
    {
        ITDb1Entities db = new ITDb1Entities();     

        

        public void CreateExcelFile(DataTable dt_list, string filename)
        {
            try
            {
                DataSet ds1 = new DataSet();
                ds1.Tables.Add(dt_list);
                using (DataSet ds = ds1)
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        string rootFolder = HttpContext.Current.Server.MapPath("~/Excel_Files").ToString();
                        string fileName = @"" + filename + ".xlsx";

                        System.IO.FileInfo file = new System.IO.FileInfo(Path.Combine(rootFolder, fileName));
                        using (ExcelPackage xp = new ExcelPackage(file))
                        {
                            foreach (DataTable dt in ds.Tables)
                            {
                                ExcelWorksheet ws = xp.Workbook.Worksheets.Add(dt.TableName);
                                int rowstart = 1;
                                int colstart = 1;
                                int rowend = rowstart;
                                int colend = colstart + dt.Columns.Count;
                                rowend = rowstart + dt.Rows.Count;
                                ws.Cells[rowstart, colstart].LoadFromDataTable(dt, true);
                                int i = 1;
                                foreach (DataColumn dc in dt.Columns)
                                {
                                    i++;
                                    if (dc.DataType == typeof(decimal))
                                        ws.Column(i).Style.Numberformat.Format = "#0.00";
                                }
                                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                                ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Top.Style =
                                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Bottom.Style =
                                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Left.Style =
                                   ws.Cells[rowstart, colstart, rowend, colend].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                            }
                            xp.Save();
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public List<SelectListItem> BindPaper()         
               
        
        {
            var paper = db.bindPapers.ToList();
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "Select paper ID", Value = "0" });

            foreach (var m in paper)
            {
                li.Add(new SelectListItem { Text = m.Paper_Id, Value = m.Paper_Id.ToString() });

            }
            return li;
        }     
    }
}