using GembosAPI.EntityLayer.DTOs;
using GembosAPI.EntityLayer.Entities;

namespace GembosAPI.BusinessLayer.Abstract
{
    public interface IMessageService
    {
        Task SaveMessagesAsync(MessageDTO dto);
    }
}
