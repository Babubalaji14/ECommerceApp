using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    public class Sellers
    {
        [Key]
        public int SellerId { get; set; }

        [Required(ErrorMessage = "SeellerName is Required"), Column(TypeName = "nVarchar(25)")]
        public string SellerName { get; set; }

        [Required(ErrorMessage = "Products is Required"), Column(TypeName = "nVarchar(25)")]
        public int Products { get; set; }

        [Required(ErrorMessage ="WalletBalance is Required")]
        public float WalletBalance { get; set; }

        [Required(ErrorMessage ="Revenue field is Required")]
        public float Revenue { get; set; }

        [Required(ErrorMessage ="Rating is Required")]
        public float Rating { get; set; }

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
