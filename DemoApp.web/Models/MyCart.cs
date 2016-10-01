﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoApp.Domain;

namespace DemoApp.web.Models
{
    public class MyCart
    {
        public MyCart()
        {
            ComponentTypes = new List<ComponentType>();
           
        }
        //public Package Package { get; set; }
        public List<ComponentType> ComponentTypes { get; set; }
        public decimal PreviousCost { get; set; }
    }
}