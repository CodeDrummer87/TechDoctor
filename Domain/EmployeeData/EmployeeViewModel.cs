namespace Domain.EmployeeData
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string? PersonnelNumber { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public string? Lastname { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Post { get; set; }
        public byte IsActive { get; set; }
    }
}
