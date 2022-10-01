using DEVVagas.Data;
using DEVVagas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Controllers;

[Route("api/v{version.apiVersion}/[controller]")]
[ApiController]
public class VacancyController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public VacancyController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vacancy>> GetVacancyById([FromRoute] int id)
    {
        try
        {
            var vacancy = await _dbContext.VacancyModels.FirstOrDefaultAsync(c => c.Id == id);
            if (vacancy == null)
            {
                return NotFound(new { message = "Vaga não encontrada" });
            }
            return Ok(vacancy);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpGet("recruiter/{id}")]
    public async Task<ActionResult<Vacancy>> GetVacancyByIdRecruiter([FromRoute] int id)
    {
        try
        {
            var vacancy = await _dbContext.VacancyModels.Where(c => c.IdRecruiter == id).ToListAsync();
            if (vacancy == null)
            {
                return NotFound(new { message = "Vaga não encontrada" });
            }
            return Ok(vacancy);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostVacancy([FromBody] Vacancy vacancy)
    {
        try
        {
            await _dbContext.AddAsync(vacancy);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutVacancy([FromRoute] int id, [FromBody] Vacancy vacancy)
    {
        try
        {
            var model = await _dbContext.VacancyModels.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                return NotFound(new { message = "Vaga não encontrada" });
            }

            model.City = vacancy.City;
            model.Description = vacancy.Description;
            model.Seniority = vacancy.Seniority;
            model.Technologies = vacancy.Technologies;
            model.Remote = vacancy.Remote;
            model.Presential = vacancy.Presential;
            model.TypeContracts = vacancy.TypeContracts;

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
