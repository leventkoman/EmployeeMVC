using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EmployeeMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                "~/Scripts/custom.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/DataTables/css/dataTables.bootstrap.min.css",
                "~/Content/style.css"
            ));
        }
    }
}