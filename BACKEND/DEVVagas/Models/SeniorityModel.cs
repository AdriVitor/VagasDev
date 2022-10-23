using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DEVVagas.Models.Enum;

namespace DEVVagas.Models;

public class SeniorityModel{
    [Key()]
    public int Id { get; set; }
    [ForeignKey("Candidate")]
    public int CandidateId { get; set; }
    public Seniority Seniority { get; set; }
}