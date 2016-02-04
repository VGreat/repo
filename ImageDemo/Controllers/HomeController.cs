using ImageResizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult ImageTest()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ImageUploader()
        {
            return View();
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file!=null)
            {
                var versions = new Dictionary<string, string>();
                var path = Server.MapPath("~/Images/");

                 //Define the versions to generate
                versions.Add("_small", "maxwidth=600&maxheight=600&format=jpg");
                versions.Add("_medium", "maxwidth=900&maxheight=900&format=jpg");
                versions.Add("_large", "maxwidth=1200&maxheight=1200&format=jpg");
 
                //Generate each version
                foreach (var suffix in versions.Keys)
                {
                    file.InputStream.Seek(0, SeekOrigin.Begin);
 
                    //Let the image builder add the correct extension based on the output file type
                    ImageBuilder.Current.Build(
                        new ImageJob(
                            file.InputStream,
                            path + file.FileName + suffix,
                            new Instructions(versions[suffix]),
                            false,
                            true));
                }
            }
 
            return RedirectToAction("ImageUploader");

        }
    }
}