using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeMVC.Models
{
    public class MesajFormModel
    {
        public bool Status { get; set; }
        public string Mesaj { get; set; }
        public string Url { get; set; }
        public string LinkText { get; set; }
    }
}