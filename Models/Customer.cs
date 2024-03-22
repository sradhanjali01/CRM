using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string phone_call { get; set; }
        public string email_answer { get; set; }
        public string call_timing { get; set; }
        public string oprn_issue { get; set; }
        public string communication_chhanel { get; set; }
        public string total_sale { get; set; }
        public string return_cancellation { get; set; }
    }
}