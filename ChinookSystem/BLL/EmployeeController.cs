using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class EmployeeController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<EmployeeClients> Employee_GetClientList()
        {
            //our access to the DB is via the context class
            using (var context = new ChinookContext())
            {
                var results = from x in context.Employees
                              where x.Title.Contains("Support")
                              orderby x.LastName, x.FirstName
                              select new EmployeeClients
                              {
                                  Name = x.LastName + ", " + x.FirstName,
                                  ClientCount = x.Customers.Count(),
                                  Clients = from y in x.Customers
                                            orderby y.LastName, x.FirstName
                                            select new ClientInfo
                                            {
                                                Client = y.LastName + ", " + y.FirstName,
                                                Phone = y.Phone
                                            }
                                  //Title = x.Title
                              };
                return results.ToList();
            }
        }

        public Employee Employee_Get(int employeeid)
        {
            using (var context = new ChinookContext())
            {
                return context.Employees.Find(employeeid);
            }
        }
    }
}
