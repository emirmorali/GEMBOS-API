using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.DataAccessLayer.Abstract
{
    public interface IMessageRepository
    {
        Task AddMessagesAsync(Message message);
    }
}
