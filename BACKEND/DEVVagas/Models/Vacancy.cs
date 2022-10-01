using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DEVVagas.Models.Enum;

namespace DEVVagas.Models;

public class Vacancy {
    [Key()]
    public int Id { get; set; }
    [ForeignKey("Recruiter")]
    public int IdRecruiter { get; set; }
    [ForeignKey("Company")]
    public int IdCompany { get; set; }
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
    [Required]
    public Seniority Seniority { get; set; }
    public List<Technologies>? Technologies { get; set; }
    [StringLength(8000)]
    [MaxLength(8000)]
    public string? Description { get; set; }
    [Required]
    public string City { get; set; }
    public bool Remote { get; set; }
    public bool Presential { get; set; }
    public List<Candidate>? Candidates { get; set; }
    public TypeContract TypeContracts { get; set; }

}