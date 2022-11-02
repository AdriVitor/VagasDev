using DEVVagas.Data;
using DEVVagas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVVagas.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TechnologiesVacanciesController : ControllerBase{

    private readonly AppDbContext _dbContext;

    public TechnologiesVacanciesController(AppDbContext dbContext){
        _dbContext = dbContext;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TechnologiesVacancies>> GetTechnologiesVacanciesById(
        [FromRoute] int id
    ){
        try{
            var query = await (from t in _dbContext.TechnologiesVacancies
                        join v in _dbContext.Vacancy
                        on t.VacancyId equals v.Id
                        where t.VacancyId == id
                        select new{
                            JavaScript = t.JavaScript,
                            Python = t.Python,
                            Java = t.Java,
                            PHP = t.PHP,
                            CSharp = t.CSharp,
                            CMaisMais = t.CMaisMais,
                            TypeScript = t.TypeScript,
                            Ruby = t.Ruby,
                            C = t.C,
                            Swift = t.Swift,
                            R = t.R,
                            ObjectiveC = t.ObjectiveC,
                            Shell = t.Shell,
                            Go = t.Go,
                            PowerShell = t.PowerShell,
                            Kotlin = t.Kotlin,
                            Rust = t.Rust,
                            Dart = t.Dart,
                            Angular = t.Angular,
                            Vue = t.Vue,
                            Emberjs = t.Emberjs,
                            React = t.React,
                            NodeJs = t.NodeJs,
                            Express = t.Express,
                            AdonisJs = t.AdonisJs,
                            DOTNETFramework = t.DOTNETFramework,
                            DOTNETCore = t.DOTNETCore,
                            ASPNET = t.ASPNET,
                            ASPNETCore = t.ASPNETCore,
                            Xamarim = t.Xamarim,
                            EntityFramework = t.EntityFramework,
                            Dapper = t.Dapper,
                            ADONET = t.ADONET,
                            Bootstrap = t.Bootstrap,
                            UiKit = t.UiKit,
                            Laravel = t.Laravel,
                            CodeIgniter = t.CodeIgniter,
                            Symfony = t.Symfony,
                            CakePHP = t.CakePHP,
                            Spring = t.Spring,
                            Django = t.Django,
                            RubyOnRails = t.RubyOnRails,
                            Vuetify = t.Vuetify,
                            Oracle = t.Oracle,
                            SQLServer = t.SQLServer,
                            MySql = t.MySql,
                            PostgreSQL = t.PostgreSQL,
                            MongoDB = t.MongoDB,
                            NoSQL = t.NoSQL,
                            AWS = t.AWS,
                            Azure = t.Azure,
                            OracleCloud = t.OracleCloud,
                            IBMCloud = t.IBMCloud,
                            CloudStigma = t.CloudStigma,
                            Outros = t.Outros
                        }).FirstOrDefaultAsync();

            if(query == null){
                return NotFound(new{message = "A vaga não foi encontrada"});
            }
            return Ok(query);
        }
        catch(Exception ex){
            return NotFound(new {message = ex.Message});
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostTechnologiesVacanciesById(
        [FromBody] TechnologiesVacancies technologiesVacancies
    ){
        try{
            await _dbContext.AddAsync(technologiesVacancies);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch(Exception ex){
            return NotFound(new {message = ex.Message});
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PostTechnologiesCandidatesById(
        [FromBody] TechnologiesVacancies technologiesVacancies,
        [FromRoute] int id
    ){
        try{
            var model = await _dbContext.TechnologiesVacancies.FirstOrDefaultAsync(x=>x.VacancyId == id);
            if(model == null){
                return NotFound(new{message = "Candidato não encontrado"});
            }
            model.JavaScript = technologiesVacancies.JavaScript;
            model.Python = technologiesVacancies.Python;
            model.Java = technologiesVacancies.Java;
            model.PHP = technologiesVacancies.PHP;
            model.CSharp = technologiesVacancies.CSharp;
            model.CMaisMais = technologiesVacancies.CMaisMais;
            model.TypeScript = technologiesVacancies.TypeScript;
            model.Ruby = technologiesVacancies.Ruby;
            model.C = technologiesVacancies.C;
            model.Swift = technologiesVacancies.Swift;
            model.R = technologiesVacancies.R;
            model.ObjectiveC = technologiesVacancies.ObjectiveC;
            model.Shell = technologiesVacancies.Shell;
            model.Go = technologiesVacancies.Go;
            model.PowerShell = technologiesVacancies.PowerShell;
            model.Kotlin = technologiesVacancies.Kotlin;
            model.Rust = technologiesVacancies.Rust;
            model.Dart = technologiesVacancies.Dart;
            model.Angular = technologiesVacancies.Angular;
            model.Vue = technologiesVacancies.Vue;
            model.Emberjs = technologiesVacancies.Emberjs;
            model.React = technologiesVacancies.React;
            model.NodeJs = technologiesVacancies.NodeJs;
            model.Express = technologiesVacancies.Express;
            model.AdonisJs = technologiesVacancies.AdonisJs;
            model.DOTNETFramework = technologiesVacancies.DOTNETFramework;
            model.DOTNETCore = technologiesVacancies.DOTNETCore;
            model.ASPNET = technologiesVacancies.ASPNET;
            model.ASPNETCore = technologiesVacancies.ASPNETCore;
            model.Xamarim = technologiesVacancies.Xamarim;
            model.EntityFramework = technologiesVacancies.EntityFramework;
            model.Dapper = technologiesVacancies.Dapper;
            model.ADONET = technologiesVacancies.ADONET;
            model.Bootstrap = technologiesVacancies.Bootstrap;
            model.UiKit = technologiesVacancies.UiKit;
            model.Laravel = technologiesVacancies.Laravel;
            model.CodeIgniter = technologiesVacancies.CodeIgniter;
            model.Symfony = technologiesVacancies.Symfony;
            model.CakePHP = technologiesVacancies.CakePHP;
            model.Spring = technologiesVacancies.Spring;
            model.Django = technologiesVacancies.Django;
            model.RubyOnRails = technologiesVacancies.RubyOnRails;
            model.Vuetify = technologiesVacancies.Vuetify;
            model.Oracle = technologiesVacancies.Oracle;
            model.SQLServer = technologiesVacancies.SQLServer;
            model.MySql = technologiesVacancies.MySql;
            model.PostgreSQL = technologiesVacancies.PostgreSQL;
            model.MongoDB = technologiesVacancies.MongoDB;
            model.NoSQL = technologiesVacancies.NoSQL;
            model.AWS = technologiesVacancies.AWS;
            model.Azure = technologiesVacancies.Azure;
            model.OracleCloud = technologiesVacancies.OracleCloud;
            model.IBMCloud = technologiesVacancies.IBMCloud;
            model.CloudStigma = technologiesVacancies.CloudStigma;
            model.Outros = technologiesVacancies.Outros;

            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch(Exception ex){
            return NotFound(new {message = ex.Message});
        }
    }
}