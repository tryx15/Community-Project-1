﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proj_BOL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_Models : DbContext
    {
        public DB_Models()
            : base("name=DB_Models")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<OPPOR_HAS_CATEGORY> OPPOR_HAS_CATEGORY { get; set; }
        public virtual DbSet<OPPOR_HAS_VOLUN> OPPOR_HAS_VOLUN { get; set; }
        public virtual DbSet<tbl_Category> tbl_Category { get; set; }
        public virtual DbSet<tbl_Opportunity> tbl_Opportunity { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }
        public virtual DbSet<tbl_Volunteer> tbl_Volunteer { get; set; }
    }
}
