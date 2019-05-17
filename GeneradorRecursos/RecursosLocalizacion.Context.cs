﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeneradorRecursos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RecursosEntities : DbContext
    {
        public RecursosEntities()
            : base("name=RecursosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Localizacion> Localizacion { get; set; }
        public virtual DbSet<Constantes> Constantes { get; set; }
    
        public virtual int CreaActualizaLocalizacion(string nombre, string mensajeES, string mensajeEN, string comentario)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var mensajeESParameter = mensajeES != null ?
                new ObjectParameter("MensajeES", mensajeES) :
                new ObjectParameter("MensajeES", typeof(string));
    
            var mensajeENParameter = mensajeEN != null ?
                new ObjectParameter("MensajeEN", mensajeEN) :
                new ObjectParameter("MensajeEN", typeof(string));
    
            var comentarioParameter = comentario != null ?
                new ObjectParameter("Comentario", comentario) :
                new ObjectParameter("Comentario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreaActualizaLocalizacion", nombreParameter, mensajeESParameter, mensajeENParameter, comentarioParameter);
        }
    
        public virtual int CrearConstante(string nombre, string valor, string tipo)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var valorParameter = valor != null ?
                new ObjectParameter("Valor", valor) :
                new ObjectParameter("Valor", typeof(string));
    
            var tipoParameter = tipo != null ?
                new ObjectParameter("Tipo", tipo) :
                new ObjectParameter("Tipo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CrearConstante", nombreParameter, valorParameter, tipoParameter);
        }
    }
}
