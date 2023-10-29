﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class FinancialData
    {
        public FinancialData(DateTime date, double high, double open, double close, double low)
        {
            Date = date;
            High = high;
            Open = open;
            Close = close;
            Low = low;
        }

        public DateTime Date { get; set; }
        public double High { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Low { get; set; }
    }
}
