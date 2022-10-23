using System.ComponentModel.DataAnnotations.Schema;

namespace DEVVagas.Models;

public class TechnologiesCandidates : Technologies{
    [ForeignKey("Candidate")]
    public int? CandidateId { get; set; }
}