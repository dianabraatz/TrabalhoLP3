namespace ProjetoDCPoint.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ocorrencia")]
    public partial class ocorrencia
    {
        [Key]
        [Column("codOcorrencia ")]
        public int codOcorrencia_ { get; set; }

        [Required]
        [StringLength(50)]
        public string justificativa { get; set; }

        public int status { get; set; }

        public int codPonto { get; set; }

        public virtual statusOcorrencia statusOcorrencia { get; set; }

        public virtual ponto ponto { get; set; }
    }
}
