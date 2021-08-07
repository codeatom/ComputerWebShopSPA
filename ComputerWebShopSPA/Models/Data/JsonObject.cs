using ComputerWebShopSPA.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerWebShopSPA.Models.Data
{
    public class JsonObject
    {
        public List<int> ComputerIdList { get; set; }

        public CreateOrder CreateOrder { get; set; }
    }
}
