using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BillAutomation      //DO NOT change the namespace name
{
    public class DBHandler    //DO NOT change the class name
    {
        //Implement the methods as per the description
        public SqlConnection getConnection(){
            string connectionString = @"Data Source=AMEEN;Initial Catalog=ElectrictyBillDB;Integrated Security=True";
            Console.WriteLine("Db handler called");
            return new SqlConnection(connectionString);
        }
    }
}
