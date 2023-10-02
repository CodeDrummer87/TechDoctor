namespace Domain.ElectricValues
{
    public class MeasuringData
    {
        public int Id { get; set; }
        public int LocomotiveId { get; set; }
        public int? EmployeeId { get; set; }
        public int MeasuringId { get; set; }
        public string? Denotement { get; set; }
        public string? SaveDate { get; set; }
    }
}
