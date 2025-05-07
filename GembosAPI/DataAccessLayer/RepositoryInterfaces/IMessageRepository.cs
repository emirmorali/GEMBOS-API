using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.DataAccessLayer.Abstract
{
    public interface IMessageRepository
    {
        Task AddMessageAsync(Message message);
        Task AddMessagesAsync(List<Message> messages);
    }
}
