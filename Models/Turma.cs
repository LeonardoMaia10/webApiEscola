using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace escola.Models

{

    public class Turma
    {
        [Key]
        [ForeignKey("Aluno")]
        public int Id { get; set; }



        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre e 3 60 caracteres")]
        public string tituloDaTurma { get; set; }
        public int qtdDeAlunos { get; set; }

        public int idadeMedia { get; set; }
    }
}