namespace ProjetoDCPoint.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("funcionario")]
    public partial class funcionario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public funcionario()
        {
            ponto = new HashSet<ponto>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int numRegistro { get; set; }

        [Required]
        [StringLength(80)]
        public string senha { get; set; }

        [Column(TypeName = "date")]
        public DateTime dataNascimento { get; set; }

        [Required]
        [StringLength(90)]
        public string nome { get; set; }

        [Required]
        [StringLength(14)]
        public string rg { get; set; }

        [Required]
        [StringLength(11)]
        public string cpf { get; set; }

        [Required]
        [StringLength(11)]
        public string cnh { get; set; }

        [Column(TypeName = "date")]
        public DateTime dataAdmissao { get; set; }

        [Required]
        [StringLength(20)]
        public string ctps { get; set; }

        public int codFuncao { get; set; }

        public int codSetor { get; set; }

        public virtual funcao funcao { get; set; }

        public virtual setor setor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ponto> ponto { get; set; }
    }
}
