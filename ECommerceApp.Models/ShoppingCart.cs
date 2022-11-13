using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Please Provide Product Desc"),Column(TypeName ="nVarchar(25)")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage ="Please mention Price")]
        public int Price { get; set; }

        [Required(ErrorMessage ="Please Mention Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="Please Provide TotalPrice")]
        public int Total { get; set; }

        [Required(ErrorMessage ="Please field Notes"),Column(TypeName ="nVarchar(25)")]
        public string Notes { get; set; }

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
