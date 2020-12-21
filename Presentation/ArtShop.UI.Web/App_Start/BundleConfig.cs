using System.Web;
using System.Web.Optimization;

namespace ArtShop.UI.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js", "~/Scripts/respond.js", "~/Scripts/plugins.js", "~/Scripts/html5shiv.js", "~/Scripts/init.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/pre-icons.css",
                      "~/Content/animate.css",
                      "~/Content/style.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/Site.css",
                      "~/Content/prettyPhoto.css"));



            bundles.Add(new StyleBundle("~/Content/cssDashboard").Include(
                "~/Content/sb-admin-2.min.css",
                "~/Content/dataTables.bootstrap4.min.css",
                "~/Content/dataTables.bootstrap4.css"));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                "~/Scripts/dashboard/bootstrap.bundle.min.js",
                "~/Scripts/dashboard/jquery.easing.min.js",
                "~/Scripts/dashboard/sb-admin-2.min.js",
                "~/Scripts/dashboard/Chart.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Scripts/dashboard/jquery.dataTables.min.js",
                "~/Scripts/dashboard/datatables.bootstrap4.min.js"));
        }
    }
}
