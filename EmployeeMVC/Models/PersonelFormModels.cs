using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeMVC.DAL;

namespace EmployeeMVC.Models
{
    public class PersonelFormModels
    {
        public IEnumerable<Departman> departmanlar { get; set; }
        public Personel personel { get; set; }
    }
}