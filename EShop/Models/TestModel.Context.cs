﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EShop.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Configuration;
    public partial class TestBaseEntities : DbContext
    {
        public TestBaseEntities()
            : base("name=TestBaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ListAnswerName> ListAnswerName { get; set; }
        public DbSet<QuestionName> QuestionName { get; set; }
        public DbSet<TestName> TestName { get; set; }
        public DbSet<UserAnswerTest> UserAnswerTest { get; set; }
        public DbSet<UserTest> UserTest { get; set; }
    }
}