namespace Domain.Models;

public class ExamResult
{
    public int Id { get; set; }
    public int Exam_Id { get; set; }
    public int Student_Id { get; set; }
    public int Course_Id { get; set; }
}
