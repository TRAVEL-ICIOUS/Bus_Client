﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bus_Client.Models
{
    public class DbOperations
    {
        public static string InsertBusInfo(ServiceReference1.Insert_BusInfo B)
        {
            ServiceReference1.Service1Client S = new ServiceReference1.Service1Client();
            string s = S.InsertBusInfo(B);
            return s;

        }

        public static string InsertRouteInfo(ServiceReference1.Insert_RouteInfo R)
        {
            ServiceReference1.Service1Client S = new ServiceReference1.Service1Client();
            string s = S.InsertRouteInfo(R);
            return s;

        }

        public static string InsertScheduleInfo(ServiceReference1.Insert_ScheduleInfo Sc )
        {
            ServiceReference1.Service1Client S = new ServiceReference1.Service1Client();
            string s = S.InsertScheduleInfo(Sc);
            return s;

        }

        public static string InsertSeatsAvailInfo(ServiceReference1.Insert_availseats Av)
        {
            ServiceReference1.Service1Client S = new ServiceReference1.Service1Client();
            string s = S.InsertSeatsAvailInfo(Av);
            return s;

        }


        public static string InsertCustomer(ServiceReference1.CustomerRegistration Cr)
        {

            ServiceReference1.Service1Client S = new ServiceReference1.Service1Client();
            string s = S.InsertCustomer(Cr);
            return s;
        }

       
             public static string InsertTicketbooked(ServiceReference1.TicketBooking tb)
        {

            ServiceReference1.Service1Client S = new ServiceReference1.Service1Client();
            string s = S.InsertTicketbooked(tb);
            return s;
        }
    }
}