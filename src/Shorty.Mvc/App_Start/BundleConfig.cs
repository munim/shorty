using System.Web;
using System.Web.Optimization;

namespace Shorty.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var scripts = new ScriptBundle("~/bundles/scripts").Include(
                "~/bower_components/jquery/dist/jquery.min.js",
                "~/bower_components/jquery-validate/dist/jquery.validate.min.js",
                "~/bower_components/bootstrap/dist/js/bootstrap.min.js"
                );
            scripts.Orderer = new AsIsBundleOrderer();
            bundles.Add(scripts);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/bower_components/modernizr-min/dist/modernizr.min.js",
                        "~/bower_components/respond/dest/respond.min.js"));

            var styles = new StyleBundle("~/bundles/css").Include(
                "~/bower_components/bootstrap/dist/css/bootstrap.min.css",
                "~/bower_components/bootstrap/dist/css/bootstrap-theme.min.css",
                "~/Content/Site.css");
            styles.Orderer = new AsIsBundleOrderer();
            bundles.Add(styles);

        }
    }
}