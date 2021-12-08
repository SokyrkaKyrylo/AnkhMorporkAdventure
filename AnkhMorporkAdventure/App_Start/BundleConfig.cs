﻿using System.Web.Optimization;

namespace AnkhMorporkAdventure
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {         
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css"));
        }
    }
}
