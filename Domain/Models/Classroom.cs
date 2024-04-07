namespace Domain.Models;

public class Classroom
{
    public int Id { get; set; }
    public int Grade_Id { get; set; }
    public required string Section { get; set; }
    public int Teacher_Id { get; set; }

}
