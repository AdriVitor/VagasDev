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
                                   GitHub = v.GitHub,
                                   Portfolio = v.Portfolio,
                                   Technologies = _dbContext.TechnologiesCandidates.Where(x => x.CandidateId == v.Id).ToList()
                               }).FirstOrDefaultAsync();

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

    [HttpPut("aboutyou/{id}")]
    public async Task<ActionResult<Candidate>> PutAboutYouCandidate(
        [FromRoute] int id, [FromBody] Candidate candidate)
    {
        try
        {
            var model = await _dbContext.Candidate.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                return NotFound(new { message = "Candidato não encontrado" });
            }

            model.Title = candidate.Title;
            model.LastName = candidate.LastName;
            model.PhoneNumber = candidate.PhoneNumber;
            model.City = candidate.City;

            _dbContext.Candidate.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPut("presentation/{id}")]
    public async Task<ActionResult<Candidate>> PutPresentationCandidate(
        [FromRoute] int id, [FromBody] Candidate candidate)
    {
        try
        {
            var model = await _dbContext.Candidate.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                return NotFound(new { message = "Candidato não encontrado" });
            }

            model.Title = candidate.Title;
            model.Description = candidate.Description;
            model.LinkedIn = candidate.LinkedIn;
            model.GitHub = candidate.GitHub;
            model.Portfolio = candidate.Portfolio;

            _dbContext.Candidate.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPut("seniority/{id}")]
    public async Task<ActionResult<Candidate>> PutSeniorityCandidate(
        [FromRoute] int id, [FromBody] Candidate candidate)
    {
        try
        {
            var model = await _dbContext.Candidate.FirstOrDefaultAsync(c => c.Id == id);
            if (model == null)
            {
                return NotFound(new { message = "Candidato não encontrado" });
            }

            model.Seniority = candidate.Seniority;

            _dbContext.Candidate.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {
            return NoContent();
        }
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult<dynamic>> Authenticate([FromBody] Candidate model){
        try{
            
            var user = CandidateRepository.Get(model);    
            var validacao = _dbContext.Candidate.FirstOrDefault(x=>x.Email == model.Email && x.Password == model.Password);

            if((user.Email == null || user.Password == null) || (user.Email.ToLower() != validacao.Email.ToLower() || user.Password != validacao.Password)){
                return NotFound(new{message="Usuário ou senha inválidos"});
            }
            
            var token = TokenServiceCandidate.GenerateToken(user);
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
