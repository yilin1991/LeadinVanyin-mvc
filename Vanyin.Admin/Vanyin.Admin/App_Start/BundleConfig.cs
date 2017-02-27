using System.Web;
using System.Web.Optimization;



namespace Vanyin.Admin.App_Start
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/Login").Include(
                     "~/Content/login.css"));
            bundles.Add(new StyleBundle("~/Content/Style").Include(
                     "~/Content/font-awesome.min.css",
                     "~/Content/style.css"));
            bundles.Add(new StyleBundle("~/Content/Edit").Include(
                     "~/Content/edit.css"));
            bundles.Add(new StyleBundle("~/Content/List").Include(
                     "~/Content/list.css"));


            bundles.Add(new ScriptBundle("~/Scripts/jQuery").Include("~/Scripts/jquery-1.11.1.min.js", "~/Scripts/jquery.public.js"));

        }
    }
}