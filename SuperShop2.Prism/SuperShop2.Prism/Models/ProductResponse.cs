using System;
using System.Collections.Generic;
using System.Text;

namespace SuperShop2.Prism.Models
{
    public class ProductResponse
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

                
        public float Price { get; set; }


        public string ImageId { get; set; }

               
        public object LastPurchase { get; set; }

              
        public object LastSale { get; set; }

             
        public bool IsAvailable { get; set; }

               
        public double Stock { get; set; }


        public UserResponse User { get; set; }

        public string ImageFullPath { get; set; }
    }
}
