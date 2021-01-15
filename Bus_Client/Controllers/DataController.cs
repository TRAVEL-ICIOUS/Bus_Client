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
        static Insert_ScheduleInfo[] As = null;
        static Insert_RouteInfo[] ri = null;
        static List<SelectListItem> L = new List<SelectListItem>();
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
            // ViewBag.D = Sc.Busid + " " + Sc.Routeid;
            ViewBag.D1 = L;
           ViewBag.D = bi;
            ViewBag.msg = DbOperations.InsertScheduleInfo(Sc);
            return View();
        }


        public ActionResult Availseats()
        {
            ServiceReference1.Insert_ScheduleInfo B = new ServiceReference1.Insert_ScheduleInfo();
            ServiceReference1.Service1Client s1 = new ServiceReference1.Service1Client();
            As = s1.GetScheduleid();
            ViewBag.D2 = As;
            ServiceReference1.Insert_availseats A1 = new ServiceReference1.Insert_availseats();
            return View(A1);



        }
        [HttpPost]
        public ActionResult Availseats(ServiceReference1.Insert_availseats Av)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            ViewBag.D2 = As;
            ViewBag.msg = DbOperations.InsertSeatsAvailInfo(Av);
            return View();
        }

        }
    }