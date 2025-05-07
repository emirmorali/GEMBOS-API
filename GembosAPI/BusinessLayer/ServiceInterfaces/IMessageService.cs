using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.BusinessLayer.Abstract
{
    public interface IMessageService
    {
        Task SaveMessageAsync(Message message);
        Task SaveMessagesAsync(List<Message> messages);
    }
}
