﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResumeManager.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbResumeManagerEntities1 : DbContext
    {
        public dbResumeManagerEntities1()
            : base("name=dbResumeManagerEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_education> tbl_education { get; set; }
        public virtual DbSet<tbl_extra_info> tbl_extra_info { get; set; }
        public virtual DbSet<tbl_users> tbl_users { get; set; }
        public virtual DbSet<tbl_work_history> tbl_work_history { get; set; }
    }
}
