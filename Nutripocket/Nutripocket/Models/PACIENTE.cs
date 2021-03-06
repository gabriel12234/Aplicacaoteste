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
    
    public partial class PACIENTE
    {
        public PACIENTE()
        {
            this.ANM_CLINICA = new HashSet<ANM_CLINICA>();
            this.ANM_DADOSGERAIS = new HashSet<ANM_DADOSGERAIS>();
            this.ANTECEDENTES_FAMILIARES = new HashSet<ANTECEDENTES_FAMILIARES>();
            this.ANTROPOMETRIA = new HashSet<ANTROPOMETRIA>();
            this.APARENCIA = new HashSet<APARENCIA>();
            this.EX_LABORA = new HashSet<EX_LABORA>();
            this.FREQ_ALIMENTAR = new HashSet<FREQ_ALIMENTAR>();
            this.PACIENTE_CONSULTA = new HashSet<PACIENTE_CONSULTA>();
            this.RECEITAS = new HashSet<RECEITAS>();
        }
    
        public int ID_PACIENTE { get; set; }
        public string NOME { get; set; }
        public string SEXO { get; set; }
        public Nullable<System.DateTime> DT_NASC { get; set; }
        public string EST_CIVIL { get; set; }
        public string PROFISSAO { get; set; }
        public string ENDERECO { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
    
        public virtual ICollection<ANM_CLINICA> ANM_CLINICA { get; set; }
        public virtual ICollection<ANM_DADOSGERAIS> ANM_DADOSGERAIS { get; set; }
        public virtual ICollection<ANTECEDENTES_FAMILIARES> ANTECEDENTES_FAMILIARES { get; set; }
        public virtual ICollection<ANTROPOMETRIA> ANTROPOMETRIA { get; set; }
        public virtual ICollection<APARENCIA> APARENCIA { get; set; }
        public virtual ICollection<EX_LABORA> EX_LABORA { get; set; }
        public virtual ICollection<FREQ_ALIMENTAR> FREQ_ALIMENTAR { get; set; }
        public virtual ICollection<PACIENTE_CONSULTA> PACIENTE_CONSULTA { get; set; }
        public virtual ICollection<RECEITAS> RECEITAS { get; set; }
    }
}
