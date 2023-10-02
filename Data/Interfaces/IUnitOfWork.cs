using Data.Repositories;

namespace Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public bool GetThemeValue();
        public Task SetThemeValue(bool value);

        public PostRepository Posts { get; }
        public PersonRepository Persons { get; }
        public LocoSeriesRepository LocoSeries { get; }
        public LocomotiveTypeRepository LocomotiveTypes { get; }
        public LocomotiveRepository Locomotives { get; }
        public EmployeeRepository Employees { get; }
        public CompanyRepository Companies { get; }
        public MeasuringRepository Measurings { get; }
        public MeasuringDataRepository MeasuringsData { get; }

        public void Save();
    }
}
