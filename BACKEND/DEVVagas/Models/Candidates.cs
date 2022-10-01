using DEVVagas.Models.Enum;

namespace DEVVagas.Models;

public class Candidate : Person{
    public TypeUser TypeUser { get; set; } = TypeUser.Candidate;
    public Contact? Contact  { get; set; }
    public string? GitHubOrGitlabOrPortfolio { get; set; }
    public string? City { get; set; }
    public Seniority? Seniority { get; set; }
    public List<Technologies>? Technologies { get; set; }
    public List<Vacancy>? Vacancies { get; set; }
}