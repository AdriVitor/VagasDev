using System.ComponentModel.DataAnnotations;

namespace DEVVagas.Models;

public class Person
{
    [Key()]
    public int Id { get; set; }
    [Required]
    [MinLength(10)]
    [MaxLength(120)]
    public string Email { get; set; }
    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string Password { get; set; }

    [Required]
    [StringLength(11)]
    [MinLength(11)]
    [MaxLength(11)]
    public string CPF { get; set; }
    [Required]
    public DateTime BirthDate { get; set; }
    [StringLength(500)]
    [MaxLength(500)]
    public string? Description { get; set; }

}