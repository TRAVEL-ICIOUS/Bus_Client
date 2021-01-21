using Bus_Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus_Client.Controllers
{
    public class RetrivalController : Controller
    {
        static Insert_BusInfo[] bi = null;
        static Insert_ScheduleInfo[] As = null;
        static Insert_RouteInfo[] ri = null;
        static List<SelectListItem> L = new List<SelectListItem>();

        static List<SelectListItem> states = null;
        static List<SelectListItem> countries = null;

        static List<SelectListItem> Tos = null;
        static List<SelectListItem> Froms = null;
        static List<SelectListItem> Bookid = null;


        static CustomerRegistration[] U = null;
        static CustomerRegistration[] P = null;

        // GET: Retrival
        public ActionResult Index()
        {
            ServiceReference1.Insert_RouteInfo R = new ServiceReference1.Insert_RouteInfo();

            List<ServiceReference1.ExtractBookingDetails> c = new List<ServiceReference1.ExtractBookingDetails>();
          ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            string[] gf = s.GetFrom();
            Froms = new List<SelectListItem>();
            for (int i = 0; i < gf.Length; i++)
            {
                Froms.Add(new SelectListItem { Text = gf[i], Value = gf[i] });
            }
            ViewBag.D6 = Froms;
            Session["Froms"] = gf;
            return View(c);

        }
        [HttpPost]
        public ActionResult Index(string ScheduleID)
        {
            ServiceReference1.Insert_RouteInfo R = new ServiceReference1.Insert_RouteInfo();

            List<ServiceReference1.ExtractBookingDetails> c = new List<ServiceReference1.ExtractBookingDetails>();
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            string[] gf = s.GetFrom();
            Froms = new List<SelectListItem>();
            for (int i = 0; i < gf.Length; i++)
            {
                Froms.Add(new SelectListItem { Text = gf[i], Value = gf[i] });
            }
            ViewBag.D6 = Froms;
            Session["Froms"] = gf;
            return View(c);

        }
        public JsonResult GetToFetch(string RFrom)
        {

            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            string[] gt = s.GetTo(RFrom);
            ViewBag.D6 = Froms;
            Tos = new List<SelectListItem>();
            for (int i = 0; i < gt.Length; i++)
            {
                Tos.Add(new SelectListItem { Text = gt[i], Value = gt[i] });
            }


            ViewBag.D7 = Tos;
            //Session["Country"] = cy;
            return Json(Tos, JsonRequestBehavior.AllowGet);
        }




    }
}