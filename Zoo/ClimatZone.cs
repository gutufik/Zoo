//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoo
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClimatZone
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClimatZone()
        {
            this.Clerk_Zone = new HashSet<Clerk_Zone>();
            this.Zone_Animal = new HashSet<Zone_Animal>();
        }
    
        public int ZoneID { get; set; }
        public string ZoneName { get; set; }
        public string ZoneImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Clerk_Zone> Clerk_Zone { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zone_Animal> Zone_Animal { get; set; }
    }
}
