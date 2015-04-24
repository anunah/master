﻿using System.Web;
using System.Web.Optimization;

namespace EShop
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                     "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap*"));
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/loginajax.js",
                        "~/Scripts/delajax.js",
                        "~/Scripts/script.js"));
            bundles.Add(new ScriptBundle("~/bundles/addanswer").Include(
                       "~/Scripts/addanswer.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                    .Include("~/Content/site.css")  /* не перепутайте порядок */
                    .Include("~/Content/bootstrap*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                     "~/Scripts/jquery-ui-1.*"));
            
            bundles.Add(new StyleBundle("~/Content/jqueryui")
                   .Include("~/Content/jquery-ui-1*"));
                               

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}