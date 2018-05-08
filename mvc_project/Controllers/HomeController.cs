using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_project.Models;
using log4net;
using System.IO;
using ViCore.Logging;

namespace mvc_project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViData.DMHelper.Instance.ExportMapping();
            ViCore.Logging.Logging4net.WriteInfo("this is mes");
            ViCore.Logging.Logging4net.WriteError(null, "this is error");
            var dt = ViData.DataHelper.Fill("select * from t_d_user limit 1");
            ViData.DataHelper.Fill("select * from t_d_user limit 33");
            Logging4net.WriteInfo(dt.Rows.Count +" hang");
            Logging4net.WriteInfo(ViData.DataHelper.SqlText);
                return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
