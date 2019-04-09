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
    
    public partial class empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleado()
        {
            this.salida_empleado = new HashSet<salida_empleado>();
            this.vacaciones = new HashSet<vacaciones>();
            this.permiso = new HashSet<permiso>();
            this.licencia = new HashSet<licencia>();
        }
    
        public int id_empleado { get; set; }
        public string codigo_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string teléfono { get; set; }
        public Nullable<int> id_departamento { get; set; }
        public Nullable<int> id_cargo { get; set; }
        public string fecha_ingreso { get; set; }
        public Nullable<decimal> salario { get; set; }
        public string estatus { get; set; }
    
        public virtual cargo cargo { get; set; }
        public virtual departamento departamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<salida_empleado> salida_empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vacaciones> vacaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permiso> permiso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<licencia> licencia { get; set; }
    }
}