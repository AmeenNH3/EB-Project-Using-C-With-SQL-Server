using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace BillAutomation         //DO NOT change the namespace name
{
    public class Program        //DO NOT change the class name
    {
        
        static void Main(string[] args)  //DO NOT change the 'Main' method signature
        {
            BillValidator billValidator = new BillValidator();
            ElectricityBoard electricityBoard = new ElectricityBoard();
            List<ElectricityBill> tempDisplayList = new List<ElectricityBill>();

            Console.WriteLine("Enter Number of Bills To Be Added:");
            int numberOfBills = int.Parse(Console.ReadLine());
            

            for(int i = 1; i<=numberOfBills; i++)
            {
                Console.WriteLine("Enter Consumer Number:");
                string consumerNumber = Console.ReadLine();
                if (Regex.IsMatch(consumerNumber, "EB[0-9]{5}") == false)
                {
                    throw new FormatException("Invalid Consumer Number");
                }
                Console.WriteLine("Enter Consumer Name:");
                string consumerName = Console.ReadLine();

                Console.WriteLine("Enter Units Consumed:");
                int unitsConsumed = int.Parse(Console.ReadLine());

                while (billValidator.ValidateUnitsConsumed(unitsConsumed) != "")
                {
                    Console.WriteLine(billValidator.ValidateUnitsConsumed(unitsConsumed));
                    Console.WriteLine("Enter Units Consumed:");
                    unitsConsumed = int.Parse(Console.ReadLine());
                }

                ElectricityBill electricityBill = new ElectricityBill(consumerNumber, consumerName, unitsConsumed);

                electricityBoard.CalculateBill(electricityBill);
                tempDisplayList.Add(electricityBill);
                electricityBoard.AddBill(electricityBill);

            }

            Console.WriteLine("Enter Last 'N' Number of Bills to Generate");
            int numberofBillsToGenerate = int.Parse(Console.ReadLine());



            foreach(ElectricityBill bill in tempDisplayList)
            {
                Console.WriteLine(bill.ConsumerNumber);
                Console.WriteLine(bill.ConsumerName);
                Console.WriteLine(bill.UnitsConsumed);
                Console.WriteLine("Bill Amount:" + bill.BillAmount);
                Console.WriteLine("");

            }


            List<ElectricityBill> dislpaylist = electricityBoard.Generate_N_BillDetails(numberofBillsToGenerate);
            Console.WriteLine("Details of last 'N' bills:");
            foreach(ElectricityBill bill in dislpaylist)
            {
                Console.WriteLine("EB Bill for " +bill.ConsumerName+ " is " +bill.BillAmount );
            }
            Console.ReadKey();

        }
    }
    
    public class BillValidator{//DO NOT change the class name
    
        public String ValidateUnitsConsumed(int UnitsConsumed)      //DO NOT change the method signature
        {
          if(UnitsConsumed < 0){
              return "Given units is invalid";
          }
            return "";
        }
    }
}
