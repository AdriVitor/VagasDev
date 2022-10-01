using System.ComponentModel.DataAnnotations;

namespace DEVVagas.Models;

public class Contact {
    
    [Key()]
    public int Id { get; set; }
    public string? LinkedIn { get; set; }
    public string? Number1 { get; set; }
    public string? Number2 { get; set; }
}