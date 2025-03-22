using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptMobile.Retailer.Models
{
    public class AdditionalCharge
    {
        public string LoadingText { get; set; } = "Loading";
        public string Amount { get; set; } = "50";
        public string TaxRate { get; set; } = "GST 290%";
        public string TotalAmount { get; set; } = "Amount incl of tax - ₹ 188.0";
        public bool IsVisible { get; set; } = true;
    }
}
