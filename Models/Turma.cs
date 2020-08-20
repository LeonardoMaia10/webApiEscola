using System.ComponentModel.DataAnnotations;

namespace escola.Models

{

    public class Turma
    {
        [Key]
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre e 3 60 caracteres")]
        public string titulo_da_turma { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
    

        public int qtd_de_alunos { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
       

        public int idade_media {get; set;}
}
}