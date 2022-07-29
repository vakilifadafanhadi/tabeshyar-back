namespace tabeshyar_back.Repositories
{
    public interface IRepositoryWrapper:IDisposable
    {
        bool IsDisposed { get; }
        ILatteryCodeRepository LatteryCodeRepository { get; }
        ISmsOutboxRepository SmsOutboxRepository { get; }
        ISmsInboxRepository SmsInboxRepository { get; }
        Task SaveAsync();
        void Save();
    }
}
