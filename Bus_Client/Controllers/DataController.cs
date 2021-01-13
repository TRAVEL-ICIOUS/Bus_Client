using Bus_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus_Client.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
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
    }
}