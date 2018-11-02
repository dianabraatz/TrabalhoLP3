namespace ProjetoDCPoint.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ponto")]
    public partial class ponto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ponto()
        {
            ocorrencia = new HashSet<ocorrencia>();
        }

        [Key]
        public int codPonto { get; set; }

        public DateTime? dh_ponto1 { get; set; }

        public DateTime? dh_ponto2 { get; set; }

        public DateTime? dh_ponto3 { get; set; }

        public DateTime? dh_ponto4 { get; set; }

        public int numRegistro { get; set; }

        public virtual funcionario funcionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ocorrencia> ocorrencia { get; set; }
    }
}
