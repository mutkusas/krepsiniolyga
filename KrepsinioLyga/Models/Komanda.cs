//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KrepsinioLyga.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Komanda
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Komanda()
        {
            this.Rungtynės = new HashSet<Rungtynės>();
            this.Rungtynės1 = new HashSet<Rungtynės>();
            this.Žaidėjas = new HashSet<Žaidėjas>();
        }
    
        public int Id { get; set; }
        public string Miestas { get; set; }
        public string Pavadinimas { get; set; }
        public decimal Biudžetas { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rungtynės> Rungtynės { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rungtynės> Rungtynės1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Žaidėjas> Žaidėjas { get; set; }
    }
}
