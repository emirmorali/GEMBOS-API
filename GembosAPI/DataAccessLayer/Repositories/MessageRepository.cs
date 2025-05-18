using GembosAPI.DataAccessLayer.Abstract;
using GembosAPI.DataAccessLayer.Contexts;
using GembosAPI.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GembosAPI.DataAccessLayer.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbcontext _context;

        public MessageRepository(AppDbcontext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(Message message)
        {
            message.IsSynced = true;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task AddMessagesAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
}
