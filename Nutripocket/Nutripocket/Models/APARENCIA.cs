//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nutripocket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class APARENCIA
    {
        public APARENCIA()
        {
            this.PACIENTE_CONSULTA = new HashSet<PACIENTE_CONSULTA>();
        }
    
        public int ID_APARENCIA { get; set; }
        public int ID_PACIENTE { get; set; }
        public string AP_FACE { get; set; }
        public string AP_LABIOS { get; set; }
        public string AP_LINGUA { get; set; }
        public string AP_GENGIVA { get; set; }
        public string AP_PELE { get; set; }
        public string AP_CABELOS { get; set; }
        public string AP_MUSCULOS { get; set; }
        public string AP_TRONCO { get; set; }
        public string AP_MEMBROS { get; set; }
        public string AP_UNHAS { get; set; }
        public string AP_SIST_NERVOSO { get; set; }
        public string AP_PESCOCO { get; set; }
        public string Attribute145 { get; set; }
    
        public virtual PACIENTE PACIENTE { get; set; }
        public virtual ICollection<PACIENTE_CONSULTA> PACIENTE_CONSULTA { get; set; }
    }
}
