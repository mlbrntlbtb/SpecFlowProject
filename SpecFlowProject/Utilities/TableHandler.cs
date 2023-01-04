using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject.Utilities
{
    public class TableHandler
    {
        public static Dictionary<string,string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string,string>();
            foreach(var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static DataTable ToDataTable(Table table)
        {
            var dataTable = new DataTable();

            //Set table headers
            foreach (var header in table.Header)
            {
                dataTable.Columns.Add(header, typeof(string));
            }

            //Set values per row
            foreach(var row in table.Rows)
            {
                //Create new row
                DataRow newRow = dataTable.NewRow();
                foreach (var header in table.Header)
                {
                    //Set values for the new row
                    newRow.SetField(header, row[header]);
                }
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }
    }
}
