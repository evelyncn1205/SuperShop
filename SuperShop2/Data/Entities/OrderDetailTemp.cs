using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace SuperShop2.Data.Entities
{
    public class OrderDetailTemp
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Product Product { get; set; }

        [DisplayFormat(DataFormatString ="{0:C2}")]
        public decimal Price { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Quantity { get; set; }


        public decimal Value => Price * (decimal)Quantity;


    }
}
