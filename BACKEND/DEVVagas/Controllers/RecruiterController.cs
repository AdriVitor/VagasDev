using DEVVagas.Data;
using DEVVagas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Controllers;

[Route("api/[controller]")]
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
            var recruiter = await _dbContext.Recruiter.FirstOrDefaultAsync(c => c.Id == id);
            if (recruiter == null)
            {
                return NotFound(new { message = "Recrutador não encontrado" });
            }
            return Ok(recruiter);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost]
    public async Task<ActionResult<Recruiter>> PostRecruiter([FromBody] Recruiter recruiter)
    {
        try
        {
            await _dbContext.AddAsync(recruiter);
            await _dbContext.SaveChangesAsync();
            return Ok(recruiter);
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
            var model = await _dbContext.Recruiter.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                return NotFound(new { message = "Recrutador não encontrado" });
            }

            model.BirthDate = recruiter.BirthDate;
            model.CPF = recruiter.CPF;
            model.Description = recruiter.Description;
            model.PhoneNumber = recruiter.PhoneNumber;
            model.LinkedIn = recruiter.LinkedIn;

            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody] Recruiter model){
        try{
            
            var user = RecruiterRepository.Get(model);    
            var validacao = _dbContext.Recruiter.FirstOrDefault(x=>x.Email == model.Email && x.Password == model.Password);

            if((user.Email == null || user.Password == null) || (user.Email.ToLower() != validacao.Email.ToLower() || user.Password != validacao.Password)){
                return NotFound(new{message="Usuário ou senha inválidos"});
            }
            
            var token = TokenServiceRecruiter.GenerateToken(user);
            user.Id = validacao.Id;
            return new{
                user = user,
                token = token
            };
        }
        catch{
            return NotFound();
        }
    }
}