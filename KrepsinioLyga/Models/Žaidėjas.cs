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
    
    public partial class Žaidėjas
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavardė { get; set; }
        public System.DateTime Gimė { get; set; }
        public int Ūgis { get; set; }
        public Nullable<int> Numeris { get; set; }
        public string Pozicija { get; set; }
        public Nullable<int> Atlyginimas { get; set; }
        public Nullable<int> Komanda { get; set; }
    
        public virtual Komanda Komanda1 { get; set; }
    }
}
