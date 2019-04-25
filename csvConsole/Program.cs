using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Dynamic;
using System.IO;

namespace csvConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                using (var writer = new StreamWriter("test2.csv"))
                {
                    using (var csv = new CsvWriter(writer))
                    {
                        csv.WriteRecords(GetData());

                        //  writer.ToString().Dump();
                    }
                }

            }
            catch (Exception ex)
            {

            }
            Console.ReadLine();
        }
       

        private static List<dynamic> GetData()
        {
            List<dynamic> lstCustomersVerticalBar = new List<dynamic>();
            dynamic cvb = new ExpandoObject();
            cvb.DummyField = "aaa";
            cvb.ContactName = "test";
            cvb.CompanyName = "bbbb";
            lstCustomersVerticalBar.Add(cvb);

            dynamic cvb1 = new ExpandoObject();
            cvb1.DummyField = "aaa";
            cvb1.ContactName = "test";
            cvb1.CompanyName = "bbbb";
            lstCustomersVerticalBar.Add(cvb1);

            dynamic cvb2 = new ExpandoObject();
            cvb2.DummyField = "aaa";
            cvb2.ContactName = "test";
            cvb2.CompanyName = "bbbb";
            lstCustomersVerticalBar.Add(cvb2);

            return lstCustomersVerticalBar;
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }


    
    public class CustomersVerticalBar
    {
   
        public string DummyField { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
    
    }
}
