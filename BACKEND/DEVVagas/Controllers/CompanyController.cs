using DEVVagas.Data;
using DEVVagas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Controllers;

[Route("api/v{version.apiVersion}/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public CompanyController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Company>> GetCompanyById([FromRoute] int id)
    {
        try
        {
            var company = await _dbContext.CompanyModels.FirstOrDefaultAsync(c => c.Id == id);
            if (company == null)
            {
                return NotFound(new { message = "Empresa não encontrada" });
            }
            return Ok(company);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostCompany([FromBody] Company company)
    {
        try
        {
            await _dbContext.AddAsync(company);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutCompany([FromRoute] int id, [FromBody] Company company)
    {
        try
        {
            var model = await _dbContext.CompanyModels.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                return NotFound(new { message = "Empresa não encontrada" });
            }

            model.SocialReason = company.SocialReason;
            model.ProfileEnterprise = company.ProfileEnterprise;
            model.Vacancies = company.Vacancies;

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