﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfTest1.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class СonsultantEntities : DbContext
    {
        private static СonsultantEntities _context;
        public СonsultantEntities()
            : base("name= СonsultantEntities")
        {
        }

        public static СonsultantEntities GetContext()
        {
            if (_context == null)
                _context = new СonsultantEntities();
            return _context;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<LoginHistory> LoginHistory { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
