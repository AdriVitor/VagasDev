using DEVVagas.Data;
using DEVVagas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Controllers;

[Route("api/v{version.apiVersion}/[controller]")]
[ApiController]
public class RecruiterController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public RecruiterController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Recruiter>> GetRecruiterById([FromRoute] int id)
    {
        try
        {
            var recruiter = await _dbContext.RecruiterModels.FirstOrDefaultAsync(c => c.Id == id);
            if (recruiter == null)
            {
                return NotFound(new { message = "Candidato não encontrado" });
            }
            return Ok(recruiter);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostRecruiter([FromBody] Recruiter recruiter)
    {
        try
        {
            await _dbContext.AddAsync(recruiter);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutRecruiter([FromRoute] int id, [FromBody] Recruiter recruiter)
    {
        try
        {
            var model = await _dbContext.RecruiterModels.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                return NotFound(new { message = "Candidato não encontrado" });
            }

            model.Contact = recruiter.Contact;
            model.Company = recruiter.Company;
            model.Vacancies = recruiter.Vacancies;

            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch
        {
            return NoContent();
        }
    }
}