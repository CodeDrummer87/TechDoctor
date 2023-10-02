namespace Domain.LocomotiveData
{
    public class Locomotive
    {
        public int Id { get; set; }
        public int SeriesId { get; set; }
        public string? Number { get; set; }
        public int? CompanyId { get; set; }
    }
}
