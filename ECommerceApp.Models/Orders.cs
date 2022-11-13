using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage ="Please Provide BillingName"),Column(TypeName ="nVarchar(25)")]
        public string BillingName { get; set; }

        DateTime _Date;
        public DateTime Date 
        {
            set
            {
                _Date = DateTime.Now;
            }
            get
            {
                return _Date;
            }
        }

        [Required(ErrorMessage ="Please Provide PaymentStatus"), Column(TypeName ="nVarchar(25)")]
        public string PaymentStatus { get; set; }

        [Required(ErrorMessage ="Please Provide Total Amount")]
        public double Total { get; set; }

        [Required(ErrorMessage ="Please mention PaymentMethod"),Column(TypeName ="nVarchar(25)")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage ="Please Provide OrderStatus"),Column(TypeName ="nVarchar(25)")]
        public string OrderStatus { get; set; }

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
