using Bus_Client.Models;
using Bus_Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus_Client.Controllers
{
    public class DataController : Controller
    {
        static Insert_BusInfo [] bi = null;
        static Insert_RouteInfo[] ri = null;
        // GET: Data
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult GetBusInfo()
        {
            ServiceReference1.Insert_BusInfo B = new ServiceReference1.Insert_BusInfo();

            return View(B);
        }

        [HttpPost]
        public ActionResult GetBusInfo(ServiceReference1.Insert_BusInfo B)
        {
            ViewBag.msg = DbOperations.InsertBusInfo(B);
            return View(B);
        }


        public ActionResult GetRouteInfo()
        {
            ServiceReference1.Insert_RouteInfo R = new ServiceReference1.Insert_RouteInfo();

            return View(R);
        }

        [HttpPost]
        public ActionResult GetRouteInfo(ServiceReference1.Insert_RouteInfo R)
        {
            ViewBag.msg = DbOperations.InsertRouteInfo(R);
            return View(R);
        }


        public ActionResult FetchBusid()
        {
            ServiceReference1.Insert_BusInfo B = new ServiceReference1.Insert_BusInfo();
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            bi = s.GetBusid();
            ViewBag.D = bi;

            ServiceReference1.Insert_RouteInfo R = new ServiceReference1.Insert_RouteInfo();
            ServiceReference1.Insert_ScheduleInfo R1 = new ServiceReference1.Insert_ScheduleInfo();
            ServiceReference1.Service1Client s1 = new ServiceReference1.Service1Client();
           
            ri = s1.GetRouteid();
            List<SelectListItem> L = new List<SelectListItem>();
            foreach(Insert_RouteInfo i in ri)
            {
                L.Add(new SelectListItem { Text = i.RouteFrom + "-" + i.RouteTo, Value =i.RouteID });

            }
           
            ViewBag.D1 = L;


            return View(R1);

        }
        [HttpPost]
        public ActionResult FetchBusid(ServiceReference1.Insert_ScheduleInfo Sc)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            ViewBag.Br = Sc.Busid + " " + Sc.Routeid;
            //ViewBag.D1 = Sc.Routeid;
            //ViewBag.D = Sc.Busid;
            ViewBag.msg = DbOperations.InsertScheduleInfo(Sc);
            return View();
        }

        }
    }