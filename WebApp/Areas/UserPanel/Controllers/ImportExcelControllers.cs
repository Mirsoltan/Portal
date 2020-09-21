using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApp.Areas.UserPanel.Controllers
{
    public class ImportExcelControllers : Controller
    {
        private IWebHostEnvironment Environment;
        private IConfiguration Configuration;
        public ImportExcelControllers(IWebHostEnvironment _environment, IConfiguration _configuration)
        {
            Environment = _environment;
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                //Create a Folder.
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Save the uploaded Excel file.
                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                //Read the connection string for the Excel file.
                string conString = this.Configuration.GetConnectionString("ExcelConString");
                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }

                //Insert the Data read from the Excel file to Database Table.
                conString = this.Configuration.GetConnectionString("SqlServer");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.rvu3";

                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("0", "part");
                        sqlBulkCopy.ColumnMappings.Add("1", "sarfasl");
                        sqlBulkCopy.ColumnMappings.Add("2", "grp");
                        sqlBulkCopy.ColumnMappings.Add("3", "attrib");
                        sqlBulkCopy.ColumnMappings.Add("4", "attr");
                        sqlBulkCopy.ColumnMappings.Add("5", "nationalcode");
                        sqlBulkCopy.ColumnMappings.Add("6", "descriptions");
                        sqlBulkCopy.ColumnMappings.Add("7", "Kol");
                        sqlBulkCopy.ColumnMappings.Add("8", "KP");
                        sqlBulkCopy.ColumnMappings.Add("9", "KT");
                        sqlBulkCopy.ColumnMappings.Add("10", "anes");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }

            return View();
        }
    }
}
