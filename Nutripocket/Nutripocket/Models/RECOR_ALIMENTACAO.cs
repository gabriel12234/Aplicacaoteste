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
    
    public partial class RECOR_ALIMENTACAO
    {
        public int ID_PERIODO { get; set; }
        public string DESC_ALIMENTO { get; set; }
        public string QTD_ALIMENTO { get; set; }
        public string HORARIO { get; set; }
    
        public virtual PERIODICIDADE PERIODICIDADE { get; set; }
    }
}
