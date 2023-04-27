namespace HahnEmployeesAPI.DTOs.EmployeeDTOs
{
    public class EmployeeGetDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string RoleTitle { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime DateHired { get; set; }
    }
}
