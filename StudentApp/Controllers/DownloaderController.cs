using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentApp.Controllers
{
    public class DownloaderController : Controller
    {
       public FileResult downloadFile()
      {
            var fileVirtualPath ="~/Files/TimeTable.png";
            return File(fileVirtualPath,"application/force- download",Path.GetFileName(fileVirtualPath));
      }
    }

}