using System.Web;
using System.Web.Optimization;

namespace ModalTut.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/addons/datatables.min.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/styleLogin2.css"));

            bundles.UseCdn = true;

            bundles.Add(new StyleBundle("~/bundles/css2").Include(
            "~/Content/style.css",
            "~/Content/bootstrap.min.css",
            "~/Content/addons/datatables.min.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/all", "https://use.fontawesome.com/releases/v5.11.2/css/all.css").Include(
            "~/Style/all.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
          "~/Scripts/jquery-{version}.js",
          "~/Scripts/bootstrap.min.js",
          "~/Scripts/jquery.validate.min.js",
          "~/Scripts/jquery.validate.unobtrusive.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js2").Include(
          "~/Scripts/jquery-{version}.js",
          "~/Scripts/bootstrap.min.js",
          "~/Scripts/jquery.validate.min.js",
          "~/Scripts/jquery.validate.unobtrusive.min.js",
          "~/Scripts/addons/datatables.min.js"
          ));

            BundleTable.EnableOptimizations = true;


        }
    }
}