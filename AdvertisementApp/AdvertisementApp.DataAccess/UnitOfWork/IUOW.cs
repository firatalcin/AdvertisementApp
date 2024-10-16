using AdvertisementApp.DataAccess.Interfaces;
using AdvertisementApp.Entities;

namespace AdvertisementApp.DataAccess.UnitOfWork
{
    public interface IUOW
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
