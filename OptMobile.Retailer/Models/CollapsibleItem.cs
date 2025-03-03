using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptMobile.Retailer.Models
{
    public class CollapsibleItem
    {
        public string Header { get; set; }
        public List<string> SubItems { get; set; }

        public CollapsibleItem(string header, List<string> subItems)
        {
            Header = header;
            SubItems = subItems;
        }
    }
}
