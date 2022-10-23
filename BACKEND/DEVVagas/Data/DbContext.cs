using DEVVagas.Models;
using DEVVagas.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Data;

public class AppDbContext : DbContext{
    public DbSet<Candidate> Candidate { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<Contact> ContactModels { get; set; }
    public DbSet<Recruiter> Recruiter { get; set; }
    public DbSet<Vacancy> Vacancy { get; set; }
    public DbSet<ProfileEnterpriseModel> ProfileEnterprise { get; set; }
    public DbSet<SeniorityModel> Seniority { get; set; }
    public DbSet<TypeUserModel> TypeUser { get; set; }
    public DbSet<TechnologiesCandidates> TechnologiesCandidates { get; set; }
    public DbSet<TechnologiesVacancies> TechnologiesVacancies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options){
        options.UseSqlServer(@"Server=DESKTOP-H7797U1\SQLEXPRESS;
                             Database=DEVVagasTCC;
                             Integrated Security=True;
                             Encrypt=False");
    }

    protected void OnModelConfiguring(ModelBuilder builder){
            builder.Entity<Candidate>().ToTable("Candidate");
            builder.Entity<Company>().ToTable("Company");
            builder.Entity<Recruiter>().ToTable("Recruiter");
            builder.Entity<Vacancy>().ToTable("Vacancy");
            builder.Entity<ProfileEnterpriseModel>().ToTable("ProfileEnterprise");
            builder.Entity<SeniorityModel>().ToTable("Seniority");
            builder.Entity<TypeUserModel>().ToTable("TypeUser");
            builder.Entity<TechnologiesCandidates>().ToTable("TechnologiesCandidates");
            builder.Entity<TechnologiesVacancies>().ToTable("TechnologiesVacancies");
    }
}