using System.ComponentModel.DataAnnotations;
using DEVVagas.Models.Enum;

namespace DEVVagas.Models;

public class Recruiter : Person {
    public TypeUser TypeUser { get; set; } = TypeUser.Recruiter;
    public Contact Contact { get; set; }
    [Required]
    public Company Company { get; set;}
    public List<Vacancy>? Vacancies { get; set; }
}