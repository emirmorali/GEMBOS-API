using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.DataAccessLayer.RepositoryInterfaces
{
    public interface IMessageRepository
    {
        Task SendMessageAsync(Message message);
        Task<Message> GetMessageByIdAsync(Guid id);
        Task<IEnumerable<Message>> GetMessagesAsync(String senderId, String receiverId);
        Task UpdateMessageAsync(Message message);
        Task DeleteMessageAsync(Guid id);
    }
}
