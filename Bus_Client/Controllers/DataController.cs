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

            //ServiceReference1.Insert_RouteInfo R = new ServiceReference1.Insert_RouteInfo();
            //ServiceReference1.Service1Client s1 = new ServiceReference1.Service1Client();
            //ri = s1.GetRouteid();
            //ViewBag.D = ri;


            return View(B/*+" "+R*/);

        }
        [HttpPost]
        public ActionResult FetchBusid(ServiceReference1.Insert_ScheduleInfo Sc)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            ViewBag.D = bi;/*+ "" + ri;*/
            ViewBag.msg = DbOperations.InsertScheduleInfo(Sc);
            return View();
        }

        }
    }