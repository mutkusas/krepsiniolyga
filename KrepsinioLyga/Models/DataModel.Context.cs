﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LygaEntities : DbContext
    {
        public LygaEntities()
            : base("name=LygaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Arena> Arena { get; set; }
        public virtual DbSet<Komanda> Komanda { get; set; }
        public virtual DbSet<Rungtynės> Rungtynės { get; set; }
        public virtual DbSet<Žaidėjas> Žaidėjas { get; set; }
    }
}
