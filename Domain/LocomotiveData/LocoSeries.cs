namespace Domain.LocomotiveData
{
    public class LocoSeries
    {
        public int Id { get; set; }
        public string? Series { get; set; }
        public int LocoTypeId { get; set; }
        public string? TranslitMatching { get; set; }
    }
}
