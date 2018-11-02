namespace ProjetoDCPoint.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("funcao")]
    public partial class funcao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public funcao()
        {
            funcionario = new HashSet<funcionario>();
        }

        [Key]
        public int codFuncao { get; set; }

        public int nivelAcesso { get; set; }

        [Required]
        [StringLength(80)]
        public string nome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<funcionario> funcionario { get; set; }
    }
}
