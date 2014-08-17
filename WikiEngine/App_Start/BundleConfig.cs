using System.Web;
using System.Web.Optimization;

namespace WikiEngine
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                "~/bower_components/jquery/dist/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/angular").Include(
                "~/bower_components/angular/angular.js",
                "~/bower_components/angular-sanitize/angular-sanitize.js",
                "~/bower_components/angular-resource/angular-resource.js",
                "~/bower_components/angular-route/angular-route.js",
                "~/bower_components/angular-ui-utils/ui-utils.js",
                "~/bower_components/angular-bootstrap/ui-bootstrap-tpls.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js/editor").Include(
                "~/bower_components/codemirror/lib/codemirror.js",
                "~/bower_components/codemirror/mode/markdown/markdown.js",
                "~/bower_components/codemirror/addon/mode/overlay.js",
                "~/bower_components/codemirror/mode/xml/xml.js",
                "~/bower_components/codemirror/mode/gfm/gfm.js",
                "~/bower_components/marked/lib/marked.js",
                "~/bower_components/angular-ui-codemirror/ui-codemirror.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js/app")
                .IncludeDirectory("~/app", "*.js")
                .IncludeDirectory("~/app/settings", "*.js")
                .IncludeDirectory("~/app/views/page", "*.js")
                );

            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                    "~/bower_components/fontawesome/css/font-awesome.css",
                    "~/bower_components/bootstrap/dist/css/bootstrap.css",
                    "~/bower_components/bootstrap/dist/css/bootstrap-theme.css",
                    "~/bower_components/codemirror/lib/codemirror.css"
                )
                .IncludeDirectory("~/Content", "*.css"));
        }
    }
}
