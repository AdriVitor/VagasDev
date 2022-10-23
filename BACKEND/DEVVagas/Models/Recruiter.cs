using System.ComponentModel.DataAnnotations;
using DEVVagas.Models.Enum;

namespace DEVVagas.Models;

public class Recruiter{
    [Key()]
    public int Id { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(120)]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string Password { get; set; }

    [Required]
    [StringLength(11)]
    [MinLength(11)]
    [MaxLength(11)]
    public string CPF { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [StringLength(500)]
    [MaxLength(500)]
    public string? Description { get; set; }
    // public TypeUser TypeUser { get; set; } = TypeUser.Recruiter;
    // public Contact? Contact { get; set; }
    public string? LinkedIn { get; set; }
    public string? PhoneNumber { get; set; }
    // public Company? Company { get; set;}
    // public List<Vacancy>? Vacancies { get; set; }
}