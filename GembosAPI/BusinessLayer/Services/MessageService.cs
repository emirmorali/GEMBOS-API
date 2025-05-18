using GembosAPI.BusinessLayer.Abstract;
using GembosAPI.DataAccessLayer.Abstract;
using GembosAPI.EntityLayer.DTOs;
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

        public async Task SaveMessagesAsync(MessageDTO dto)
        {

            var message = new Message
            {
                Sender = dto.Sender,
                Body = dto.Body,
                Date = dto.Date,
                IsSynced = true
            };
            await _repository.AddMessagesAsync(message);
        }
    }
}
