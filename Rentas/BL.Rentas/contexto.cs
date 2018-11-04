﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
   public class contexto:DbContext
    {
        public contexto():base()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Producto> Productos{ get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
