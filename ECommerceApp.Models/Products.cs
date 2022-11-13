using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is Required"), Column(TypeName = "nVarchar(25)")]
        public string ProductName { get; set; }

        [Required(ErrorMessage ="Rating Field is Required")]
        public float Rating { get; set; }

        [Required(ErrorMessage ="Category Field is Required"), Column(TypeName = "nVarchar(25)")]
        public string Category { get; set; }

        DateTime _AddedDate;
        public DateTime AddedDate {
            set
            {
                _AddedDate = DateTime.Now;
            }
            get
            {
                return _AddedDate;
            }
        }

        [Required(ErrorMessage ="Please Mention Price Field")]
        public int Price { get; set; }

        [Required(ErrorMessage ="Please Mention Quantity Field")]
        public int Quantity { get; set; }

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
