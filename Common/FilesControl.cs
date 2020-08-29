using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{

    /// <summary>
    /// کلاس نمایش یا دانلود فایلها
    /// </summary>
    public class FilesControl
    {
        private IWebHostEnvironment _env;
        public FilesControl(IWebHostEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// فایل استریم را در مرورگر نمایش میدهد
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="strMimeType"></param>
        /// <returns></returns>
        public IActionResult ShowFile(string strFilePath, string strMimeType)
        {
            //string Path1 = @"c:\Class.pdf";
            //string Path = _env.ContentRootPath + @"\Files\Class.pdf";
            string Path = _env.ContentRootPath + @strFilePath;
           
            var Filestream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            
            try
            {
                return new FileStreamResult(Filestream, MimeTypeHelper(strMimeType));
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// فایل استریم را دانلود میکند
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="strMimeType"></param>
        /// <returns></returns>
        public IActionResult Download(string strFilePath, string strMimeType)
        {
            //string Path = _env.ContentRootPath + @"\Files\Class.pdf";
            string Path = _env.ContentRootPath + @strFilePath;           
            try
            {
                byte[] FileBytes = System.IO.File.ReadAllBytes(Path);
                return new FileContentResult(FileBytes, MimeTypeHelper(strMimeType));
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// انواع تعریف شده : zip rar pdf , jpg jpeg gif png , txt htm html css  
        /// </summary>
        /// <param name="strMimeType"></param>
        /// <returns></returns>
        public string MimeTypeHelper(string strMimeType)
        {
            string mimetype="";
            switch (strMimeType)
            {
                case "pdf":
                case "zip":
                case "css":
                case "html":
                case "htm":
                case "xml":
                    mimetype = "application/" + strMimeType;
                    break;

                case "txt":
                    mimetype = "text/plain";
                    break;

                case "jpg":
                case "png":
                case "gif":
                case "jpeg":
                    mimetype = "image/" + strMimeType;
                    break;

                case "rar":
                    mimetype = "application/x-rar-compressed";
                    break;

                case "mp4":
                    mimetype = "video/vnd.uvvu.mp4";
                    break;

                default:
                    break;
            }

            return mimetype;
        }
    }
}
