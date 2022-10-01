using DEVVagas.Data;
using DEVVagas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Controllers;
[ApiController]
public class CandidateController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public CandidateController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Candidate>> GetCandidateById([FromRoute] int id)
    {
        try
        {
            var candidate = await _dbContext.CandidateModels.FirstOrDefaultAsync(c => c.Id == id);
            if (candidate == null)
            {
                return NotFound(new { message = "Candidato não encontrado" });
            }
            return Ok(candidate);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpGet("vacancys/{id}")]
    public async Task<ActionResult<Vacancy>> GetVacancyByCandidate([FromRoute] int id)
    {
        try
        {
            var vacancy = await _dbContext.CandidateModels.Where(c=>c.Id == id).Select(c=>c.Vacancies).ToListAsync();
            if (vacancy == null)
            {
                return NotFound(new { message = "Vagas não encontrada" });
            }
            return Ok(vacancy);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostCandidate([FromBody] Candidate candidate)
    {
        try
        {
            await _dbContext.AddAsync(candidate);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutCandidate([FromRoute] int id, [FromBody] Candidate candidate)
    {
        try
        {
            var model = await _dbContext.CandidateModels.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                return NotFound(new { message = "Candidato não encontrado" });
            }

            model.Contact = candidate.Contact;
            model.Description = candidate.Description;
            model.Seniority = candidate.Seniority;
            model.GitHubOrGitlabOrPortfolio = candidate.GitHubOrGitlabOrPortfolio;
            model.Technologies = candidate.Technologies;
            model.City = candidate.City;
            model.Vacancies = candidate.Vacancies;

            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch{
            return NoContent();
        }

    }
}
