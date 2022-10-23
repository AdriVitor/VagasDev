using System.ComponentModel.DataAnnotations;
using DEVVagas.Models.Enum;

namespace DEVVagas.Models;

public class Company {
    [Key()]
    public int Id { get; set; }
    [Required]
    public string SocialReason { get; set; }
    [Required]
    [StringLength(14)]
    [MinLength(14)]
    [MaxLength(14)]
    public string CNPJ { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(120)]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string Password { get; set; }
    // public TypeUser TypeUser { get; set; } = TypeUser.Company;
    // public ProfileEnterprise ProfileEnterprise { get; set; }
    // public List<Vacancy>? Vacancies { get; set; }
}