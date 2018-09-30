using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalay.WindowApp.Entities
{
    public class Employee
    {
        public string Name { get; set; }

        public string CompanyName { get; set; }

        static int nextEmpId;
        int empId;

        public Employee()
        {
            empId = nextEmpId++;
        }

        public int GetEmpId()
        {
            return empId;
        }

        public static int GetNextEmpId()
        {
            return nextEmpId;
        }

        public static void SetNextEmpId(int value)
        {
            nextEmpId = value;
        }
    }
}
