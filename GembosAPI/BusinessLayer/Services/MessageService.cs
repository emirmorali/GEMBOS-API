using GembosAPI.BusinessLayer.Abstract;
using GembosAPI.DataAccessLayer.Abstract;
using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.BusinessLayer.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;

        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveMessageAsync(Message message)
        {
            await _repository.AddMessageAsync(message);
        }

        public async Task SaveMessagesAsync(List<Message> messages)
        {
            await _repository.AddMessagesAsync(messages);
        }
    }
}
