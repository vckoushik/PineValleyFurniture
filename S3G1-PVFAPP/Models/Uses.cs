//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S3G1_PVFAPP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uses
    {
        public int ProductID { get; set; }
        public string MaterialID { get; set; }
        public Nullable<int> GoesIntoQuantity { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
    }
}