﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecursosFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RecursosFinalEntities : DbContext
    {
        public RecursosFinalEntities()
            : base("name=RecursosFinalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cargo> cargo { get; set; }
        public virtual DbSet<departamento> departamento { get; set; }
        public virtual DbSet<empleado> empleado { get; set; }
        public virtual DbSet<licencia> licencia { get; set; }
        public virtual DbSet<nomina> nomina { get; set; }
        public virtual DbSet<permiso> permiso { get; set; }
        public virtual DbSet<salida_empleado> salida_empleado { get; set; }
        public virtual DbSet<vacaciones> vacaciones { get; set; }
    }
}