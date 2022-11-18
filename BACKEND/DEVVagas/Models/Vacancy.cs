using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DEVVagas.Models.Enum;

namespace DEVVagas.Models;

public class Vacancy {
    [Key()]
    public int Id { get; set; }
    [ForeignKey("Candidate")]
    public int? CandidateId { get; set; } = null;
    [ForeignKey("Recruiter")]
    public int RecruiterId { get; set; }
    [ForeignKey("Company")]
    public int? CompanyId { get; set; } = null;
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
    public bool Junior { get; set; }
    public bool Pleno { get; set; }
    public bool Senior { get; set; }
    // public List<Technologies>? Technologies { get; set; }

    [StringLength(4000)]
    [MaxLength(4000)]
    public string? Description { get; set; }
    [Required]
    public string City { get; set; }
    public bool Remote { get; set; }
    public bool Hibrid { get; set; }
    public bool Presential { get; set; }
    public bool CLT { get; set; }
    public bool PJ { get; set; }
    public bool Internship { get; set; }
    [StringLength(1000)]
    [MaxLength(1000)]
    public string? DescriptionCompany { get; set; }
    [StringLength(1000)]
    [MaxLength(1000)]
    public string? ActivitiesAndResponsibilities { get; set; }
    [StringLength(1000)]
    [MaxLength(1000)]
    public string? Requirements { get; set; }
    [StringLength(1000)]
    [MaxLength(1000)]
    public string? Benefits { get; set; }
}