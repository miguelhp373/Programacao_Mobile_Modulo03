using System;
using System.Collections.Generic;
using System.Text;

namespace ConversorDeMoedas.Models
{
    class ExchangeRates
    {
        public string   disclaimer { get; set; }
        public string   license { get; set; }
        public int      timestamp { get; set; }
        public string   @base { get; set; }
        public Rates    rates { get; set; }
    }
}
