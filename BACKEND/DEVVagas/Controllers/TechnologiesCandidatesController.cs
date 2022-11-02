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
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TechnologiesVacancies>> GetTechnologiesVacanciesById(
        [FromRoute] int id
    ){
        try{
            var query = await (from t in _dbContext.TechnologiesCandidates
                        join v in _dbContext.Vacancy
                        on t.CandidateId equals v.Id
                        where t.CandidateId == id
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

    [HttpPut("{id}")]
    public async Task<ActionResult> PostTechnologiesCandidatesById(
        [FromBody] TechnologiesCandidates technologiesCandidates,
        [FromRoute] int id
    ){
        try{
            var model = await _dbContext.TechnologiesCandidates.FirstOrDefaultAsync(x=>x.CandidateId == id);
            if(model == null){
                return NotFound(new{message = "Candidato não encontrado"});
            }
            model.JavaScript = technologiesCandidates.JavaScript;
            model.Python = technologiesCandidates.Python;
            model.Java = technologiesCandidates.Java;
            model.PHP = technologiesCandidates.PHP;
            model.CSharp = technologiesCandidates.CSharp;
            model.CMaisMais = technologiesCandidates.CMaisMais;
            model.TypeScript = technologiesCandidates.TypeScript;
            model.Ruby = technologiesCandidates.Ruby;
            model.C = technologiesCandidates.C;
            model.Swift = technologiesCandidates.Swift;
            model.R = technologiesCandidates.R;
            model.ObjectiveC = technologiesCandidates.ObjectiveC;
            model.Shell = technologiesCandidates.Shell;
            model.Go = technologiesCandidates.Go;
            model.PowerShell = technologiesCandidates.PowerShell;
            model.Kotlin = technologiesCandidates.Kotlin;
            model.Rust = technologiesCandidates.Rust;
            model.Dart = technologiesCandidates.Dart;
            model.Angular = technologiesCandidates.Angular;
            model.Vue = technologiesCandidates.Vue;
            model.Emberjs = technologiesCandidates.Emberjs;
            model.React = technologiesCandidates.React;
            model.NodeJs = technologiesCandidates.NodeJs;
            model.Express = technologiesCandidates.Express;
            model.AdonisJs = technologiesCandidates.AdonisJs;
            model.DOTNETFramework = technologiesCandidates.DOTNETFramework;
            model.DOTNETCore = technologiesCandidates.DOTNETCore;
            model.ASPNET = technologiesCandidates.ASPNET;
            model.ASPNETCore = technologiesCandidates.ASPNETCore;
            model.Xamarim = technologiesCandidates.Xamarim;
            model.EntityFramework = technologiesCandidates.EntityFramework;
            model.Dapper = technologiesCandidates.Dapper;
            model.ADONET = technologiesCandidates.ADONET;
            model.Bootstrap = technologiesCandidates.Bootstrap;
            model.UiKit = technologiesCandidates.UiKit;
            model.Laravel = technologiesCandidates.Laravel;
            model.CodeIgniter = technologiesCandidates.CodeIgniter;
            model.Symfony = technologiesCandidates.Symfony;
            model.CakePHP = technologiesCandidates.CakePHP;
            model.Spring = technologiesCandidates.Spring;
            model.Django = technologiesCandidates.Django;
            model.RubyOnRails = technologiesCandidates.RubyOnRails;
            model.Vuetify = technologiesCandidates.Vuetify;
            model.Oracle = technologiesCandidates.Oracle;
            model.SQLServer = technologiesCandidates.SQLServer;
            model.MySql = technologiesCandidates.MySql;
            model.PostgreSQL = technologiesCandidates.PostgreSQL;
            model.MongoDB = technologiesCandidates.MongoDB;
            model.NoSQL = technologiesCandidates.NoSQL;
            model.AWS = technologiesCandidates.AWS;
            model.Azure = technologiesCandidates.Azure;
            model.OracleCloud = technologiesCandidates.OracleCloud;
            model.IBMCloud = technologiesCandidates.IBMCloud;
            model.CloudStigma = technologiesCandidates.CloudStigma;
            model.Outros = technologiesCandidates.Outros;

            _dbContext.Update(model);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch(Exception ex){
            return NotFound(new {message = ex.Message});
        }
    }
}