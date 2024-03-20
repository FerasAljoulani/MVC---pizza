using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizza.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Index_get()
        {
            ViewBag.vbn = "Your familly name";
            ViewBag.vbs = "Small";
            ViewBag.vbh = 100/10;
            return View();
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_post(string n,string s,int h,string btn)
        {
            ViewBag.vbn = n;
            ViewBag.vbs = s;
            ViewBag.vbh = h;
            if (btn.Equals("Order"))
            {
                ViewBag.vbp = getprice(s, h);
                return View("Information");
            }
            else if (btn.Equals("Show"))
            {
                ViewData["vdn"] = n;
                ViewData["vds"] = s;
                ViewData["vdh"] = h;
                return View();
            }
            else if (btn.Equals("Show WebMaster Page"))
            {
                return Content(
               "<h1>WebMaster Page</h1>" +
               "<h2>Your Name </h2>" +
               "<h2>Your Number </h2>" +
               "<h2><a href='/Pizza/Index/'>Back to order page</a> </h2>"
               );
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Information()
        {
            return View();
        }
        [NonAction]
        public double getprice(string s,int h)
        {
            if (s.Equals("Small"))
                return (h * 5);
            else
                return (h * 10);
        }
    }
}