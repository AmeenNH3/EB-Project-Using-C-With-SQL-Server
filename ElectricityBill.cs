using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BillAutomation    //DO NOT change the namespace name
{
    public class ElectricityBill         //DO NOT change the class name
    {
        private string consumerNumber;
        private string consumerName;
        private int unitsConsumed;
        private double billAmount;

        public string ConsumerNumber { get; set; }
        public string ConsumerName { get; set; }

        public int UnitsConsumed { get; set; }
        public double BillAmount { get; set; }

        public ElectricityBill(string consumerNumber, string consumerName, int unitsConsumed)
        {
            this.ConsumerNumber = consumerNumber;
            this.ConsumerName = consumerName;
            this.UnitsConsumed = unitsConsumed;
        }
        public ElectricityBill(string consumerNumber, string consumerName, int unitsConsumed, double billAmount)
        {
            this.ConsumerNumber = consumerNumber;
            this.ConsumerName = consumerName;
            this.UnitsConsumed = unitsConsumed;
            this.BillAmount = billAmount;
        }
    }
}
