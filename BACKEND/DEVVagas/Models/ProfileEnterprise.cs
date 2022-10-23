using System.ComponentModel.DataAnnotations;
using DEVVagas.Models.Enum;

namespace DEVVagas.Models;

public class ProfileEnterpriseModel{
    [Key()]
    public int Id { get; set; }
    public ProfileEnterprise ProfileEnterprise { get; set; }
}