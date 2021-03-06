﻿using System.Web;
using System.Web.Optimization;

namespace Project
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/Js/jquery-{version}.js",
                        "~/Scripts/Js/react-15.0.1.js",
                        "~/Scripts/Js/react-dom-15.0.1.js",
                        "~/Scripts/Js/lodash.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/Css/*.css"));

            bundles.Add(new Bundle("~/bundles/jsx", new JsMinify()).Include(
                        "~/Scripts/Jsx/*.jsx"));
        }
    }
}