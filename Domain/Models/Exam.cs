namespace Domain.Models;

public class Exam
{
    public int Id { get; set; }
    public int Examtype_Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
}
