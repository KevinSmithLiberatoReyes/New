//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class licencia
    {
        public int id_licecia { get; set; }
        public string codigo_empleado4 { get; set; }
        public string desde { get; set; }
        public string hasta { get; set; }
        public string motivo { get; set; }
        public string comentarios { get; set; }
    
        public virtual empleado empleado { get; set; }
    }
}
