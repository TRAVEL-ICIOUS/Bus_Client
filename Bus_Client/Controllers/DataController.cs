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

        static List<SelectListItem> states = null;
        static List<SelectListItem> countries = null;

        static List<SelectListItem> Tos = null;
        static List<SelectListItem> Froms = null;
        static List<SelectListItem> Bookid = null;


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
                L.Add(new SelectListItem { Text = i.RouteFrom + "-" + i.RouteTo, Value=i.RouteID.ToString() });

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
            //As = 
            ViewBag.D2 = s1.getSecId();
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
            string []cy = s.GetCountry();
            countries = new List<SelectListItem>();
            for (int i = 0; i < cy.Length; i++)
            {
                countries.Add(new SelectListItem { Text = cy[i], Value = cy[i] });
            }
            ViewBag.D3 = countries;
            Session["Country"] = cy;


            //ServiceReference1.CS S = new ServiceReference1.CS();
            //ServiceReference1.Service1Client s1 = new ServiceReference1.Service1Client();
            // st= s1.GetState();
            //ViewBag.D4 = st;


            

            return View(Re);
                   
        }
        public ActionResult FetchData()
        {

            return View();
        }




        [HttpPost]
        public ActionResult CustReg(ServiceReference1.CustomerRegistration Cr)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
        

            ViewBag.D3 = countries;
           // ViewBag.D4 = states;
         
            ViewBag.msg = DbOperations.InsertCustomer(Cr);
            return View();
           
        }

        public ActionResult CancelTicket()
        {
           
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            //int Cid = Convert.ToInt32(Session["CustomerId"]);
            int Cid = 2021016169;
            ViewBag.Bookid = s.GetTicketId(Cid);
            return View();

        }
        

        public ActionResult  GetLoginC()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetLoginC(ServiceReference1.CustomerRegistration V)
        {
            //ServiceReference1.CustomerRegistration Re1 = new ServiceReference1.CustomerRegistration();
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            ViewBag.D4 = s.Userlogin(V.MobileNo, V.Password);

            string Username = Request.Form["MobileNo"];
            string Password = Request.Form["Password"];
            string CustomerId = Request.Form["CustomerId"];

            if (ViewBag.D4 != null)
            {
                Session["Username"] = ViewBag.D4.MobileNo;
                Session["CustomerId"] = ViewBag.D4.CustomerId;
                return View("CustomerHome");
            }
            else
            {
                ViewBag.msg = "Invalid credentials";
                return View("GetLoginC");
            }
           

            

         }




        public ActionResult CustomerHome()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Logout()
        {
            if (Session["Username"] != null)
            {
                Session.Abandon();
                Session.Clear();
            }
            return View("GetLoginC");
        }

        public JsonResult GetStateList(string Country)
        {

            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            string []st = s.GetState(Country);
            ViewBag.D3 = countries;
            states = new List<SelectListItem>();
            for (int i = 0; i < st.Length; i++)
            {
                states.Add(new SelectListItem { Text = st[i], Value = st[i] });
            }


            ViewBag.D4 = states;
            //Session["Country"] = cy;
            return Json(states,JsonRequestBehavior.AllowGet);
        }


        //Ticket booking

        public ActionResult Ticketbooking()
        {
            ServiceReference1.Insert_RouteInfo R = new ServiceReference1.Insert_RouteInfo();

            ServiceReference1.TicketBooking c = new ServiceReference1.TicketBooking();
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
        public ActionResult Ticketbooking(ServiceReference1.TicketBooking Tb)
        {
            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();


            List<ExtractBookingDetails> L = s.GetExtractBookings(Tb.RFrom, Tb.RTo, Tb.NoOfTicketBooked).ToList();

            ViewBag.TList = L;
            
            ViewBag.D6 = Froms;

            //// ViewBag.D4 = states;

            //ViewBag.msg = DbOperations.InsertTicketbooked(Tb);
            
            return View();

        }
        public ActionResult TicketInsert(int sid/*,int NOT*/)
        {
            return View();
        }


        public JsonResult GetToFetch(string RFrom)
        {

            ServiceReference1.Service1Client s = new ServiceReference1.Service1Client();
            string[] gt = s.GetTo(RFrom);
            ViewBag.D6 =Froms;
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