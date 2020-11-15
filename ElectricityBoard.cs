using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillAutomation      //DO NOT change the namespace name
{
    public class ElectricityBoard  //DO NOT change the class name
    {
        DBHandler dbhandler = new DBHandler();
        public SqlConnection SqlCon { get; set; }
        
        //Implement the property as per the description

        //Implement the methods as per the description
        public void AddBill(ElectricityBill ebill)
        {
            SqlCon = dbhandler.getConnection();
            SqlCon.Open();
            string query = "INSERT INTO ElectricityBill (consumer_number, consumer_name, units_consumed, bill_amount)";
            query += " VALUES (@consumer_number, @consumer_name, @units_consumed, @bill_amount)";
            SqlCommand myCommand = new SqlCommand(query, SqlCon );
            myCommand.Parameters.AddWithValue("@consumer_number", ebill.ConsumerNumber);
            myCommand.Parameters.AddWithValue("@consumer_name", ebill.ConsumerName);
            myCommand.Parameters.AddWithValue("@units_consumed", ebill.UnitsConsumed);
            myCommand.Parameters.AddWithValue("@bill_amount", ebill.BillAmount);
            myCommand.ExecuteNonQuery();
            SqlCon.Close();
        }
        
        
        
        
        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount;

            if (units <= 100)
            {
                amount = 0;
            }
            else if (units > 100 && units <= 300)
            {
                amount = 100 * 0 + (units-100) *1.50 ;
            }
            else if (units > 300 && units <= 600)
            {
                amount = 100 * 0 + (200 * 1.50) + (units - 300) * 3.50;
            }
            else if (units > 600 && units <= 1000)
            {
                amount = 100 * 0 + (200 * 1.50) + (300 * 3.50) + (units-600) * 5.50;

            }
            else 
            {
                amount = 100 * 0 + (200 * 1.50) + (300 * 3.50) +  (600 * 5.50) + (units-1000) * 7.50;
            }

            ebill.BillAmount = amount;

        }
        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            List<ElectricityBill> EBillList = new List<ElectricityBill>();
            string query = "select TOP " +num+ " * FROM ElectricityBill order by consumer_number desc";
            SqlCon = dbhandler.getConnection();
            SqlCon.Open();
            SqlCommand myCommand = new SqlCommand(query, SqlCon);
            SqlDataReader sqlDataReader = myCommand.ExecuteReader();

           while (sqlDataReader.Read())
            {
                ElectricityBill ebil = new ElectricityBill(sqlDataReader["consumer_number"].ToString(), sqlDataReader["consumer_name"].ToString(), int.Parse(sqlDataReader["units_consumed"].ToString()), double.Parse(sqlDataReader["bill_amount"].ToString()));
                EBillList.Add(ebil);

            }
            return EBillList;

        }
    }
}
