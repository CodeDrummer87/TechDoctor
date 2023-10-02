using Data.Interfaces;
using Data.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DocContext _db = new DocContext();

        private PostRepository? _postRepository;
        private PersonRepository? _personRepository;
        private LocoSeriesRepository? _locoSeriesRepository;
        private LocomotiveTypeRepository? _locomotiveTypeRepository;
        private LocomotiveRepository? _locomotiveRepository;
        private EmployeeRepository? _employeeRepository;
        private CompanyRepository? _companyRepository;
        private MeasuringRepository? _measuringRepository;
        private MeasuringDataRepository? _measuringDataRepository;

        #region Репозитории
        
        public PostRepository Posts
        {
            get
            {
                if (_postRepository == null)
                    _postRepository = new(_db);
                return _postRepository;
            }
        }
        public PersonRepository Persons
        {
            get
            {
                if (_personRepository == null)
                    _personRepository = new(_db);
                return _personRepository;
            }
        }
        public LocoSeriesRepository LocoSeries
        {
            get
            {
                if (_locoSeriesRepository == null)
                    _locoSeriesRepository = new(_db);
                return _locoSeriesRepository;
            }
        }
        public LocomotiveTypeRepository LocomotiveTypes
        {
            get
            {
                if (_locomotiveTypeRepository == null)
                    _locomotiveTypeRepository = new(_db);
                return _locomotiveTypeRepository;
            }
        }
        public LocomotiveRepository Locomotives
        {
            get
            {
                if (_locomotiveRepository == null)
                    _locomotiveRepository = new(_db);
                return _locomotiveRepository;
            }
        }
        public EmployeeRepository Employees
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new(_db);
                return _employeeRepository;
            }
        }
        public CompanyRepository Companies
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new(_db);
                return _companyRepository;
            }
        }
        public MeasuringRepository Measurings
        {
            get
            {
                if (_measuringRepository == null)
                    _measuringRepository = new(_db);
                return _measuringRepository;
            }
        }
        public MeasuringDataRepository MeasuringsData
        {
            get
            {
                if (_measuringDataRepository == null)
                    _measuringDataRepository = new(_db);
                return _measuringDataRepository;
            }
        }

        #endregion


        public void Save() => _db.SaveChanges();

        private bool _disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public bool GetThemeValue() => _db.GetThemeValue();
        public async Task SetThemeValue(bool value) => await _db.SetThemeValue(value);
    }
}
