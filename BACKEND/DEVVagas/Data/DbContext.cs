using DEVVagas.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Data;

public class AppDbContext : DbContext{
    public DbSet<Candidate> CandidateModels { get; set; }
    public DbSet<Company> CompanyModels { get; set; }
    public DbSet<Contact> ContactModels { get; set; }
    public DbSet<Person> PersonModels { get; set; }
    public DbSet<Recruiter> RecruiterModels { get; set; }
    public DbSet<Technologies> TechnologiesModels { get; set; }
    public DbSet<Vacancy> VacancyModels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlServer(@"Server=DESKTOP-H7797U1\SQLEXPRESS;
                             Database=DEVVagas;
                             Integrated Security=True;
                             Encrypt=False");
    }

    protected void OnModelConfiguring(ModelBuilder builder){
            builder.Entity<Candidate>().ToTable("Candidate");
            builder.Entity<Company>().ToTable("Company");
            builder.Entity<Contact>().ToTable("Contact");
            builder.Entity<Person>().ToTable("Person");
            builder.Entity<Recruiter>().ToTable("Recruiter");
            builder.Entity<Technologies>().ToTable("Technologies");
            builder.Entity<Vacancy>().ToTable("Vacancy");
    }
}