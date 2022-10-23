using DEVVagas.Data;
using DEVVagas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CandidateController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public CandidateController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Candidate>> GetCandidateById(
        [FromRoute] int id)
    {
        try
        {
            var query = await (from v in _dbContext.Candidate
                               join t in _dbContext.TechnologiesCandidates
                               on v.Id equals t.CandidateId
                               where v.Id == id
                               select new
                               {
                                   Email = v.Email,
                                   BirthDate = v.BirthDate,
                                   City = v.City,
                                   CPF = v.CPF,
                                   Description = v.Description,
                                   LinkedIn = v.LinkedIn,
                                   GitHubOrGitlabOrPortfolio = v.GitHubOrGitlabOrPortfolio,
                                   Technologies = _dbContext.TechnologiesCandidates.Where(x => x.CandidateId == v.Id).ToList()
                               }).FirstOrDefaultAsync();

            if (query == null)
            {
                return NotFound(new { Message = "Candidato não encontrado" });
            }
            return Ok(query);
        }
        catch
        {
            return NoContent();
        }


    }

    [HttpPost]
    public async Task<ActionResult<Candidate>> PostCandidate(
        [FromBody] Candidate candidate)
    {
        try
        {
        await _dbContext.AddAsync(candidate);
        await _dbContext.SaveChangesAsync();
        return Ok(candidate);
        }
        catch
        {
            return NoContent();
        }
    }

    /*[HttpPost("typeuser")]
    public async Task<ActionResult> PostCandidateTypeUser(
        [FromBody] TypeUserModel typeUserModel)
    {
        try
        {
        await _dbContext.AddAsync(typeUserModel);
        await _dbContext.SaveChangesAsync();
        return Ok();
        }
        catch
        {
            return NoContent();
        }
    }*/

    /*[HttpPost("seniority")]
    public async Task<ActionResult> PostCandidateSeniority(
        [FromBody] SeniorityModel seniorityModel)
    {
        try
        {
        await _dbContext.AddAsync(seniorityModel);
        await _dbContext.SaveChangesAsync();
        return Ok();
        }
        catch
        {
            return NoContent();
        }
    }*/

    [HttpPut("{id}")]
    public async Task<ActionResult<Candidate>> PutCandidate(
        [FromRoute] int id, [FromBody] Candidate candidate)
    {
        /*try
        {*/
        var model = await _dbContext.Candidate.FirstOrDefaultAsync(c => c.Id == id);
        if (model == null)
        {
            return NotFound(new { message = "Candidato não encontrado" });
        }

        // model.Contact = candidate.Contact;
        model.Email = candidate.Email;
        model.CPF = candidate.CPF;
        model.LinkedIn = candidate.LinkedIn;
        model.Description = candidate.Description;
        // model.Seniority = candidate.Seniority;
        model.GitHubOrGitlabOrPortfolio = candidate.GitHubOrGitlabOrPortfolio;
        // model.Technologies = candidate.Technologies;
        model.City = candidate.City;

        _dbContext.Candidate.Update(model);
        await _dbContext.SaveChangesAsync();
        return Ok(model);
        /*}
        catch
        {
            return NoContent();
        }*/

    }
}
