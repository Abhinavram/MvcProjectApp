using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjectApp.Models
{
    [Table("Customer")]
    public class CustomerDetail
    {
        [Key]
        public int CustomerId { get; set; }

        public string CustorName { get; set; }

        public string Address { get; set; }
    }
}