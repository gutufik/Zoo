//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zone_Animal
    {
        public int ZA_ID { get; set; }
        public int ZoneID { get; set; }
        public int AnimalID { get; set; }
    
        public virtual Animal Animal { get; set; }
        public virtual ClimatZone ClimatZone { get; set; }
    }
}