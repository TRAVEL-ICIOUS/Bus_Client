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
    }
}