using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderProject
{
    public class Orders : MenuItems
    {
        public string orderID { get; set; }
        public string orderStatus { get; set; }
        public string orderMod { get; set; }

        public Orders()
        {

        }
    }
}
