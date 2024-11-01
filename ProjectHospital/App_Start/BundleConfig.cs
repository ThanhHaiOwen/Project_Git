using System.Web;
using System.Web.Optimization;

namespace ProjectHospital
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			//bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
			//			"~/Scripts/jquery-{version}.js"));

			//bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
			//			"~/Scripts/jquery.validate*"));

			//// Use the development version of Modernizr to develop with and learn from. Then, when you're
			//// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			//bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
			//			"~/Scripts/modernizr-*"));

			//bundles.Add(new Bundle("~/bundles/bootstrap").Include(
			//		  "~/Scripts/bootstrap.js"));

			//bundles.Add(new StyleBundle("~/Content/css").Include(
			//		  "~/Content/bootstrap.css",
			//		  "~/Content/site.css"));


			//bundles.Add(new ScriptBundle("~/jsa").Include("~/js/jquery-1.11.1.min.js"));
			//bundles.Add(new ScriptBundle("~/jsb").Include("~/lib/easing/easing.min.js"));
			//bundles.Add(new ScriptBundle("~/jsc").Include("~/lib/waypoints/waypoints.min.js"));
			//bundles.Add(new ScriptBundle("~/jsd").Include("~/lib/owlcarousel/owl.carousel.min.js"));
			//bundles.Add(new ScriptBundle("~/jse").Include("~/js/main.js"));

			bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/js/jquery-1.11.1.min.js"));   // jQuery chính

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/js/bootstrap.min.js"));       // Bootstrap

			bundles.Add(new ScriptBundle("~/bundles/custom").Include(
					"~/js/wow.js",                   // Wow Script
					"~/js/jquery.bxslider.min.js",   // bxSlider
					"~/js/jquery.countTo.js",        // countTo
					"~/js/owl.carousel.min.js",      // Owl Carousel
					"~/js/validation.js",            // Validation
					"~/js/jquery.mixitup.min.js",    // Mixitup
					"~/js/jquery.easing.min.js",     // Easing
					"~/js/gmaps.js",                 // Gmap helper
					"~/js/map-helper.js",            // Map helper
					"~/js/jquery.fancybox.pack.js",  // Fancybox
					"~/js/jquery.appear.js",         // Appear
					"~/js/isotope.js",               // Isotope
					"~/js/jquery.prettyPhoto.js",    // PrettyPhoto
					"~/js/jquery.bootstrap-touchspin.js", // Bootstrap touchspin
					"~/js/custom.js"                 // Custom script

			));

            bundles.Add(new ScriptBundle("~/Areas/Admin/jsa").Include("~/Areas/Admin/js/modernizr.min.js"));
            bundles.Add(new ScriptBundle("~/Areas/Admin/jsb").Include("~/Areas/Admin/js/jquery-3.2.1.min.js"));
            bundles.Add(new ScriptBundle("~/Areas/Admin/jsc").Include("~/Areas/Admin/js/popper.min.js"));
            bundles.Add(new ScriptBundle("~/Areas/Admin/jsd").Include("~/Areas/Admin/js/bootstrap.min.js"));
            bundles.Add(new ScriptBundle("~/Areas/Admin/jse").Include("~/Areas/Admin/charts/js/raphael-min.js"));
            bundles.Add(new ScriptBundle("~/Areas/Admin/jsf").Include("~/Areas/Admin/charts/js/morris.min.js"));
            bundles.Add(new ScriptBundle("~/Areas/Admin/jsg").Include("~/Areas/Admin/js/custom-morris.js"));
            bundles.Add(new ScriptBundle("~/Areas/Admin/jsh").Include("~/Areas/Admin/js/custom.js"));


            // Bundle cho các file JavaScript đặc biệt khác
            bundles.Add(new ScriptBundle("~/bundles/revolution").Include(
						"~/assets/revolution/js/jquery.themepunch.tools.min.js",
						"~/assets/revolution/js/jquery.themepunch.revolution.min.js",
						 "~/assets/revolution/js/extensions/revolution.extension.actions.min.js",

						 "~/assets/revolution/js/extensions/revolution.extension.carousel.min.js",

						 "~/assets/revolution/js/extensions/revolution.extension.kenburn.min.js",

						 "~/assets/revolution/js/extensions/revolution.extension.layeranimation.min.js",

						 "~/assets/revolution/js/extensions/revolution.extension.migration.min.js",

						 "~/assets/revolution/js/extensions/revolution.extension.navigation.min.js",
						 "~/assets/revolution/js/extensions/revolution.extension.parallax.min.js",
						"~/assets/revolution/js/extensions/revolution.extension.slideanims.min.js",
						 "~/assets/revolution/js/extensions/revolution.extension.video.min.js",
							"~/assets/html5lightbox/html5lightbox.js",
							"~/assets/language-switcher/jquery.polyglot.language.switcher.js",
							"~/assets/bootstrap-sl-1.12.1/bootstrap-select.js",
							"~/assets/timepicker/timePicker.js"
						));

			bundles.Add(new StyleBundle("~/cssa").Include("~/css/style.css"));
			bundles.Add(new StyleBundle("~/cssb").Include("~/css/responsive.css"));
            //bundles.Add(new StyleBundle("~/cssc").Include("~/css/bootstrap.min.css"));
            //bundles.Add(new StyleBundle("~/cssd").Include("~/css/style.css"));

            // Bật tối ưu hóa nếu đang ở chế độ Release

            // Của Admin

            bundles.Add(new StyleBundle("~/Areas/Admin/cssc").Include("~/Areas/Admin/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Areas/Admin/cssd").Include("~/Areas/Admin/css/themify-icons.css"));
            bundles.Add(new StyleBundle("~/Areas/Admin/csse").Include("~/Areas/Admin/css/animate.css"));
            bundles.Add(new StyleBundle("~/Areas/Admin/cssf").Include("~/Areas/Admin/css/styles.css"));
            bundles.Add(new StyleBundle("~/Areas/Admin/cssg").Include("~/Areas/Admin/css/red.css"));
            bundles.Add(new StyleBundle("~/Areas/Admin/cssh").Include("~/Areas/Admin/css/responsive.css"));
            bundles.Add(new StyleBundle("~/Areas/Admin/cssi").Include("~/Areas/Admin/css/morris.css"));
            bundles.Add(new StyleBundle("~/Areas/Admin/cssj").Include("~/Areas/Admin/css/jquery-jvectormap.css"));


			

        }
    }
}
