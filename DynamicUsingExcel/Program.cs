using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usingExcelWithoutInterop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type excelType = Type.GetTypeFromProgID("Excel.Application", true);
            dynamic excel=Activator.CreateInstance(excelType);
            excel.Visible = true;

            excel.Workbooks.Add();
            dynamic myWorkSheet = excel.ActiveSheet;
            myWorkSheet.Cells[1, "A"] = "Great Dynamic!";


            Console.ReadLine();
        }
    }
}
