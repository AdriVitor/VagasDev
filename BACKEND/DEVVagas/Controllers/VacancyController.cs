using DEVVagas.Data;
using DEVVagas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacancyController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public VacancyController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<Vacancy>> GetVacancyToList()
    {
        try
        {

            var query = await (from v in _dbContext.Vacancy
                        select new{
                            Name = v.Name,
                            Junior = v.Junior,
                            Pleno = v.Pleno,
                            Senior = v.Senior,
                            Description = v.Description,
                            City = v.City,
                            Remote = v.Remote,
                            Hibrid = v.Hibrid,
                            Presential = v.Presential,
                            CLT = v.CLT,
                            PJ = v.PJ,
                            Internship = v.Internship,
                            Technologies = _dbContext.TechnologiesVacancies.Where(x=>x.VacancyId == v.Id).ToList()
                        }).ToListAsync();

            if(query == null){
                return NotFound(new{Message = "Vaga não encontrada"});
            }
            return Ok(query);
        }
        catch(Exception ex)
        {
            return NotFound(new {message = ex.Message});
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vacancy>> GetVacancyById([FromRoute] int id)
    {
        try
        {
            var query = await (from v in _dbContext.Vacancy
                        join t in _dbContext.TechnologiesVacancies 
                        on v.Id equals t.VacancyId
                        where v.Id == id
                        select new{
                            Name = v.Name,
                            Junior = v.Junior,
                            Pleno = v.Pleno,
                            Senior = v.Senior,
                            Description = v.Description,
                            City = v.City,
                            Remote = v.Remote,
                            Hibrid = v.Hibrid,
                            Presential = v.Presential,
                            CLT = v.CLT,
                            PJ = v.PJ,
                            Internship = v.Internship,
                            Technologies = _dbContext.TechnologiesVacancies.Where(x=>x.VacancyId == v.Id).ToList()
                        }).FirstOrDefaultAsync();

            if(query == null){
                return NotFound(new{Message = "Vaga não encontrada"});
            }
            return Ok(query);
        }
        catch(Exception ex)
        {
            return NotFound(new {message = ex.Message});
        }
    }

    [HttpGet("recruiter/{id}")]
    public async Task<ActionResult<Vacancy>> GetVacancyByIdRecruiter([FromRoute] int id)
    {
        try
        {

            var query = await (from v in _dbContext.Vacancy
                        join r in _dbContext.Recruiter 
                        on v.RecruiterId equals r.Id
                        select new{
                            Name = v.Name,
                            Junior = v.Junior,
                            Pleno = v.Pleno,
                            Senior = v.Senior,
                            Description = v.Description,
                            City = v.City,
                            Remote = v.Remote,
                            Hibrid = v.Hibrid,
                            Presential = v.Presential,
                            CLT = v.CLT,
                            PJ = v.PJ,
                            Internship = v.Internship,
                            Technologies = _dbContext.TechnologiesVacancies.Where(x=>x.VacancyId == v.Id).ToList()
                        }).ToListAsync();

            if(query == null){
                return NotFound(new{Message = "Vaga não encontrada"});
            }
            return Ok(query);
        }
        catch(Exception ex)
        {
            return NotFound(new {message = ex.Message});
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
        catch(Exception ex)
        {
            return NotFound(new {message = ex.Message});
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutVacancy([FromRoute] int id, [FromBody] Vacancy vacancy)
    {
        try
        {
            var model = await _dbContext.Vacancy.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                return NotFound(new { message = "Vaga não encontrada" });
            }
            
            model.Name = vacancy.Name;
            model.Junior = vacancy.Junior;
            model.Pleno = vacancy.Pleno;
            model.Senior = vacancy.Senior;
            model.Description = vacancy.Description;
            model.City = vacancy.City;
            model.Remote = vacancy.Remote;
            model.Presential = vacancy.Presential;
            model.CLT = vacancy.CLT;
            model.PJ = vacancy.PJ;
            model.Internship = vacancy.Internship;            

            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch(Exception ex)
        {
            return NotFound(new {message = ex.Message});
        }

    }
}
