using GembosAPI.EntityLayer.DTOs;

namespace GembosAPI.BusinessLayer.ServiceInterfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(CreateMessageDTO createMessageDTO);
        Task<MessageDTO> GetMessageByIdAsync(Guid id);
        Task<IEnumerable<MessageDTO>> GetMessagesAsync(string senderId, string receiverId);
        Task UpdateMessageAsync(UpdateMessageDTO updateMessageDTO);
        Task DeleteMessageAsync(Guid id);
    }
}
