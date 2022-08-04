using AutoMapper;

namespace tabeshyar_back.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private TabeshyarDb _repositoryContext;
        public readonly IMapper mapper;
        private ILatteryCodeRepository? _latteryCodeRepository;
        private ISmsOutboxRepository? _smsOutboxRepository;
        private ISmsInboxRepository? _smsInboxRepository;
        public bool IsDisposed { get; protected set; }
        public ILatteryCodeRepository LatteryCodeRepository
        {
            get
            {
                return _latteryCodeRepository ?? new LatteryCodeRepository(_repositoryContext, mapper);
            }
        }
        public ISmsOutboxRepository SmsOutboxRepository
        {
            get
            {
                return _smsOutboxRepository ?? new SmsOutboxRepository(_repositoryContext, mapper);
            }
        }
        public ISmsInboxRepository SmsInboxRepository
        {
            get
            {
                return _smsInboxRepository ?? new SmsInboxRepository(_repositoryContext, mapper);
            }
        }
        public RepositoryWrapper(TabeshyarDb repositoryContext, IMapper _mapper)
        {
            _repositoryContext = repositoryContext;
            mapper = _mapper;
        }
        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;
            if (disposing)
            {
                _repositoryContext!.Dispose();
                _repositoryContext = null!;
            }
        }
    }
}
