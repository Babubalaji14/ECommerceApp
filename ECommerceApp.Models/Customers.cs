using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Please Provide customerName"), Column(TypeName = "nVarchar(25)")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage ="Please Provide PhoneNumber"), Column(TypeName = "nVarchar(25)")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Please mention the Balance")]
        public double Balance { get; set; }

        [Required(ErrorMessage ="Please Provide Orders Field")]
        public int Orders { get; set; } 

        DateTime _LastOder;
        public DateTime LastOrder
        {
            set
            {
                _LastOder = DateTime.Now;
            }
            get
            {
                return _LastOder;
            }
        }

        [Required(ErrorMessage ="Please Provide The Status"), Column(TypeName = "nVarchar(25)")]
        public string Status { get; set; }

        DateTime _createdDate;
        public DateTime CreatedDate
        {
            set
            {
                _createdDate = DateTime.Now;
            }
            get
            {
                return _createdDate;
            }
        }

        public DateTime UpdatedDate { get; set; }
    }
}
