using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRestServer.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public decimal PayRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}