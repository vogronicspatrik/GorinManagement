using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using GorinManagement.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace GorinManagement.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            string FilePath = string.Empty;
            //SqlConnection conSql = new SqlConnection(GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
            FilePath = Path.GetFullPath(file.FileName);
            var fileLocation = new FileInfo(FilePath);
            var lol = new FileInfo(file.FileName);
            using (FileStream fs = System.IO.File.Create(FilePath))
            {
                file.CopyTo(fs);
            }

            //    using (var package = new ExcelPackage(fileLocation))
            //    {
            //        ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
            //        int totalRows = workSheet.Dimension.Rows;
            //        DataTable tblcustomers = new DataTable();
            //        tblcustomers.Columns.Add("customerId", typeof(int));
            //        tblcustomers.Columns.Add("FirstName");
            //        tblcustomers.Columns.Add("LastName");
            //        tblcustomers.Columns.Add("Role");
            //        tblcustomers.Columns.Add("Gender");
            //        for (int i = 2; i <= totalRows; i++)
            //        {
            //            DataRow dr = tblcustomers.NewRow();
            //            dr["customerId"] = workSheet.Cells[i, 1].Value.ToString();
            //            dr["FirstName"] = workSheet.Cells[i, 2].Value.ToString();
            //            dr["LastName"] = workSheet.Cells[i, 3].Value.ToString();
            //            dr["Role"] = workSheet.Cells[i, 4].Value.ToString();
            //            dr["Gender"] = workSheet.Cells[i, 5].Value.ToString();
            //            tblcustomers.Rows.Add(dr);
            //        }
            //        //SqlBulkCopy objbulk = new SqlBulkCopy(conSql);
            //        //objbulk.DestinationTableName = "Customers";
            //        //objbulk.ColumnMappings.Add("FirstName", "FirstName");
            //        //objbulk.ColumnMappings.Add("LastName", "LastName");
            //        //objbulk.ColumnMappings.Add("Role", "Role");
            //        //objbulk.ColumnMappings.Add("Gender", "Gender");
            //        //conSql.Open();
            //        //objbulk.WriteToServer(tblcustomers);
            //        //conSql.Close();
            //    }

            //using (TextReader reader = new StreamReader(FilePath))
            //{
            //    var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            //    csv.Configuration.Delimiter = ";";
            //    var records = csv.GetRecords<Account>();

            //}

            using (var reader = new StreamReader(FilePath, Encoding.GetEncoding("iso-8859-1")))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";

                csv.Read();
                csv.ReadHeader();
                string[] headerRow = csv.Context.HeaderRecord;


                var records = csv.GetRecords<Account>();
            }



            return Redirect("/Payments");
        }

        //public static string ConvertXLS_XLSX(FileInfo file)
        //{
        //    var app = new Microsoft.Office.Interop.Excel.Application();
        //    var xlsFile = file.FullName;
        //    var wb = app.Workbooks.Open(xlsFile);
        //    var xlsxFile = xlsFile + "x";
        //    wb.SaveAs(Filename: xlsxFile, FileFormat: Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook);
        //    wb.Close();
        //    app.Quit();
        //    return xlsxFile;
        //}
    }
}
