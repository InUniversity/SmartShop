//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartItem
    {
        public string ID { get; set; }
        public string CartID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
    
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
