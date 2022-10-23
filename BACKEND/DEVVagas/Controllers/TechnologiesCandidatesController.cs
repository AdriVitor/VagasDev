using DEVVagas.Data;
using DEVVagas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TechnologiesCandidatesController : ControllerBase{

    private readonly AppDbContext _dbContext;

    public TechnologiesCandidatesController(AppDbContext dbContext){
        _dbContext = dbContext;
    }
    
    // [HttpGet("{id}")]
    // public async Task<ActionResult<TechnologiesVacancies>> GetTechnologiesVacanciesById(
    //     [FromRoute] int id
    // ){
    //     try{
    //         var model = await _dbContext.TechnologiesVacancies.FirstOrDefaultAsync(x=>x.VacancyId == id);
    //         if(model == null){
    //             return NotFound(new{Message = "Vaga não encontrada"});
    //         }
    //         return Ok(model);
    //     }
    //     catch(Exception ex){
    //         return NotFound(new {message = ex.Message});
    //     }
    // }

    [HttpPost]
    public async Task<ActionResult> PostTechnologiesCandidatesById(
        [FromBody] TechnologiesCandidates technologiesCandidates
    ){
        try{
            await _dbContext.AddAsync(technologiesCandidates);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch(Exception ex){
            return NotFound(new {message = ex.Message});
        }
    }
}