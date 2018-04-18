using System.Web;
using System.Web.Optimization;

namespace ShowRoom
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                         "~/Scripts/assets/js/jquery/jquery-3.1.1.min.js",
                         "~/Scripts/assets/js/bootstrap/popper.min.js",
                         "~/Scripts/assets/js/bootstrap/bootstrap.min.js",
                         "~/Scripts/assets/js/bootstrap/mdb.min.js",
                         "~/Scripts/assets/plugins/velocity/velocity.min.js",
                         "~/Scripts/assets/plugins/velocity/velocity.ui.min.js",
                         "~/Scripts/assets/plugins/custom-scrollbar/jquery.mCustomScrollbar.concat.min.js",
                         "~/Scripts/assets/plugins/jquery_visible/jquery.visible.min.js",
                         "~/Scripts/assets/js/misc/ie10-viewport-bug-workaround.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/scriptsfim").Include(
                         "~/Scripts/assets/js/scripts.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                         "~/Scripts/assets/plugins/chartjs/chart.bundle.min.js",
                         "~/Scripts/assets/js/chart/gauge.min.js",
                         //   "~/Scripts/assets/plugins/jvmaps/jquery.vmap.min.js",
                         //    "~/Scripts/assets/plugins/jvmaps/maps/jquery.vmap.usa.js",
                         "~/Scripts/assets/js/misc/holder.min.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/fonts/batch-icons/css/batch-icons.css",
                        "~/Content/assets/css/bootstrap/bootstrap.min.css",
                        "~/Content/assets/css/bootstrap/mdb.min.css",
                        "~/Content/assets/plugins/custom-scrollbar/jquery.mCustomScrollbar.min.css",
                        "~/Content/assets/css/hamburgers/hamburgers.css",
                        "~/Content/assets/fonts/font-awesome/css/font-awesome.min.css",
                        "~/Content/assets/plugins/jvmaps/jqvmap.min.css",
                        "~/Content/assets/css/quillpro/quillpro.css"));

        }
    }
}
