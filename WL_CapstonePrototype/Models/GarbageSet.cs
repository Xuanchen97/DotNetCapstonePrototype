//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WL_CapstonePrototype.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GarbageSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GarbageSet()
        {
            this.ScanSet = new HashSet<ScanSet>();
        }
    
        public int Id { get; set; }
        public string GarbageName { get; set; }
        public string GarbageDetails { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScanSet> ScanSet { get; set; }
    }
}
