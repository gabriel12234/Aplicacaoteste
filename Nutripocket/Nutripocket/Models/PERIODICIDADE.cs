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
    
    public partial class PERIODICIDADE
    {
        public PERIODICIDADE()
        {
            this.FREQ_ALIMENTAR = new HashSet<FREQ_ALIMENTAR>();
        }
    
        public int ID_PERIODO { get; set; }
        public string DESC_PERIODO { get; set; }
    
        public virtual ICollection<FREQ_ALIMENTAR> FREQ_ALIMENTAR { get; set; }
        public virtual RECOR_ALIMENTACAO RECOR_ALIMENTACAO { get; set; }
    }
}
