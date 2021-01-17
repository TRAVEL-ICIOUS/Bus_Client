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
        static CS[] cy = null;
        static CS[] st = null;
        static CustomerRegistration[] U = null;
        static CustomerRegistration[] P = null;

        

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
            As = s1.GetScheduleId();
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


        public ActionResult CustReg()
        {
            ServiceReference1.CustomerRegistration Re = new ServiceReference1.CustomerRegistration();

            ServiceReference1.CS c = new ServiceReference1.CS();
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            cy = s.GetCountry();
            ViewBag.D3 = cy;
            Session["Country"] = cy;


            //ServiceReference1.CS S = new ServiceReference1.CS();
            //ServiceReference1.Service1Client s1 = new ServiceReference1.Service1Client();
            // st= s1.GetState();
            //ViewBag.D4 = st;


            

            return View(Re);
                   
        }
        [HttpPost]
        public ActionResult CustReg(ServiceReference1.CustomerRegistration Cr)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

            ViewBag.D3 = cy;
            ViewBag.D4 = st;
         
            ViewBag.msg = DbOperations.InsertCustomer(Cr);
            return View();
           
        }

       public ActionResult Login()
        {
            ServiceReference1.CustomerRegistration Re1 = new ServiceReference1.CustomerRegistration();

            ServiceReference1.CustomerRegistration c = new ServiceReference1.CustomerRegistration();
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            U = s.Getmobileno();
            ViewBag.D5 = U;

            ServiceReference1.CustomerRegistration c1 = new ServiceReference1.CustomerRegistration();
            ServiceReference1.Service1Client s1 = new ServiceReference1.Service1Client();
            P = s1.Getmobileno();
            ViewBag.D6 = P;
            return View(Re1);
        }
        [HttpPost]
        public ActionResult Login(ServiceReference1.CustomerRegistration L)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();

            string user = Request.Form["Username"];
            string pass = Request.Form["Password"];

            ViewBag.D3 = cy;
            ViewBag.D4 = st;

            //ViewBag.msg = DbOperations.InsertCustomer(Cr);
        
            return View();
        }


    }
    }