using System.ComponentModel.DataAnnotations.Schema;

namespace DEVVagas.Models;

public class TechnologiesVacancies : Technologies{
    [ForeignKey("Vacancy")]
    public int? VacancyId { get; set; }
}