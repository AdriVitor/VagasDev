using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEVVagas.Models;

public abstract class Technologies {
    [Key()]
    public int Id { get; set; }
    public bool JavaScript { get; set; } = false;
    public bool Python { get; set; } = false;
    public bool Java { get; set; } = false;
    public bool PHP { get; set; } = false;
    public bool CSharp { get; set; }
    public bool CMaisMais { get; set; }
    public bool TypeScript { get; set; }
    public bool Ruby { get; set; }
    public bool C { get; set; }
    public bool Swift { get; set; }
    public bool R { get; set; }
    public bool ObjectiveC { get; set; }
    // public bool Scala { get; set; }
    public bool Shell { get; set; }
    public bool Go { get; set; }
    public bool PowerShell { get; set; }
    public bool Kotlin { get; set; }
    public bool Rust { get; set; }
    public bool Dart { get; set; }
    public bool Angular { get; set; }
    public bool Vue { get; set; }
    public bool Emberjs { get; set; }
    public bool React { get; set; }
    public bool NodeJs { get; set; }
    public bool Express { get; set; }
    public bool AdonisJs { get; set; }
    public bool DOTNETFramework { get; set; }
    public bool DOTNETCore { get; set; }
    public bool ASPNET { get; set; }
    public bool ASPNETCore { get; set; }
    public bool Xamarim { get; set; }
    public bool EntityFramework { get; set; }
    public bool Dapper { get; set; }
    public bool ADONET { get; set; }
    public bool Bootstrap { get; set; }
    public bool UiKit { get; set; }
    public bool Laravel { get; set; }
    public bool CodeIgniter { get; set; }
    public bool Symfony { get; set; }
    public bool CakePHP { get; set; }
    public bool Spring { get; set; }
    public bool Django { get; set; }
    public bool RubyOnRails { get; set; }
    public bool Vuetify { get; set; }
    public bool Oracle { get; set; }
    public bool SQLServer { get; set; }
    public bool MySql { get; set; }
    public bool PostgreSQL { get; set; }
    public bool MongoDB { get; set; }
    public bool NoSQL { get; set; }
    public bool AWS { get; set; }
    public bool Azure { get; set; }
    public bool OracleCloud { get; set; }
    public bool GoogleCloud { get; set; }
    public bool IBMCloud { get; set; }
    public bool CloudStigma { get; set; }
    public bool Outros { get; set; }
}