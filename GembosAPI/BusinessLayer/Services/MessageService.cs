using AutoMapper;
using GembosAPI.BusinessLayer.ServiceInterfaces;
using GembosAPI.DataAccessLayer.Contexts;
using GembosAPI.DataAccessLayer.RepositoryInterfaces;
using GembosAPI.EntityLayer.DTOs;
using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.BusinessLayer.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAesCryptographyService aesCryptographyService;

        public MessageService(IMessageRepository repository, IMapper mapper, IAesCryptographyService aesCryptographyService)
        {
            _repository = repository;
            _mapper = mapper;
            this.aesCryptographyService = aesCryptographyService;
        }
        public async Task DeleteMessageAsync(Guid id)
        {
            await _repository.DeleteMessageAsync(id);
        }

        public async Task<MessageDTO> GetMessageByIdAsync(Guid id)
        {
            var message = await _repository.GetMessageByIdAsync(id);
            message.Body = aesCryptographyService.Decrypt(message.Body);
            return _mapper.Map<MessageDTO>(message);
        }

        public async Task<IEnumerable<MessageDTO>> GetMessagesAsync(Guid senderId, Guid receiverId)
        {
            var messages = await _repository.GetMessagesAsync(senderId, receiverId);
            foreach (var message in messages) {
                message.Body = aesCryptographyService.Decrypt(message.Body);
            }
            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public async Task SendMessageAsync(CreateMessageDTO createMessageDTO)
        {
            var message = _mapper.Map<Message>(createMessageDTO);
            message.ID = Guid.NewGuid();
            message.TimeStamp = DateTime.UtcNow;
            message.Body = aesCryptographyService.Encrypt(message.Body);
            await _repository.SendMessageAsync(message);
        }

        public async Task UpdateMessageAsync(UpdateMessageDTO updateMessageDTO)
        {
            var message = await _repository.GetMessageByIdAsync(updateMessageDTO.ID);
            if (message != null)
            {
                message.Body = aesCryptographyService.Encrypt(updateMessageDTO.Body);
                await _repository.UpdateMessageAsync(message);
            }
        }
    }
}
