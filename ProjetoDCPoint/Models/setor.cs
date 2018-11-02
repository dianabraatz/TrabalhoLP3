namespace ProjetoDCPoint.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("setor")]
    public partial class setor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public setor()
        {
            funcionario = new HashSet<funcionario>();
        }

        [Key]
        public int codSetor { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<funcionario> funcionario { get; set; }
    }
}
