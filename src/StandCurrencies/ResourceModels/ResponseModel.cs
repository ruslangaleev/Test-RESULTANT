using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StandCurrencies.ResourceModels
{
    public class ResponseModel
    {
        public Stock[] stock { get; set; }
    }

    public class Stock
    {
        public string name { get; set; }

        public Price price { get; set; }

        public int volume { get; set; }
    }

    public class Price
    {
        public double amount { get; set; }
    }
}

