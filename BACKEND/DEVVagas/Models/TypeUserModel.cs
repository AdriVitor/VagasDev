using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DEVVagas.Models.Enum;

namespace DEVVagas.Models;

public class TypeUserModel{
    [Key()]
    public int Id { get; set; }
    [ForeignKey("Candidate")]
    public int CandidateId { get; set; }
    public TypeUser TypeUser { get; set; }
}