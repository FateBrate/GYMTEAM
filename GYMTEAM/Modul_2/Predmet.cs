using System.ComponentModel.DataAnnotations;
public class Predmet
{
    [Key]
    public int Id { get; set; }
    public string naziv { get; set; }
    public string sifra { get; set; }
    public int ECTS { get; set; }
}
    