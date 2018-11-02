namespace ProjetoDCPoint.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("statusOcorrencia")]
    public partial class statusOcorrencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public statusOcorrencia()
        {
            ocorrencia = new HashSet<ocorrencia>();
        }

        [Key]
        public int idStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string descricao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ocorrencia> ocorrencia { get; set; }
    }
}
