//------------------------------------------------------------------------------
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nutripocket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FREQ_ALIMENTAR
    {
        public string ID_FREQUENCIA { get; set; }
        public int ID_PERIODO { get; set; }
        public int ID_PACIENTE { get; set; }
        public string DESC_ALIMENTO { get; set; }
        public string QTD_ALIMENTO { get; set; }
    
        public virtual PERIODICIDADE PERIODICIDADE { get; set; }
        public virtual PACIENTE PACIENTE { get; set; }
    }
}
