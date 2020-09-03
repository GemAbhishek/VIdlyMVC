﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyMVC.Models;

namespace VidlyMVC.ViewModels
{
    public class CustomerFromViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edit Customer";

                return "Add New Customer";
            }
        }
    }
}