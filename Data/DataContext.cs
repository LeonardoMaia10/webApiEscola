using Microsoft.EntityFrameworkCore;
using escola.Models;

namespace escola.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }
        public DbSet<Turma> Turmas { get; set; }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
