namespace Domain.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
        public DateTime DOB { get; set; }

    public string Phone { get; set; }
    public int Parent_Id { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
}
