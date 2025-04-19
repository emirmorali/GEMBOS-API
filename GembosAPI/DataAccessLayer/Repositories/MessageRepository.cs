using GembosAPI.DataAccessLayer.Contexts;
using GembosAPI.DataAccessLayer.RepositoryInterfaces;
using GembosAPI.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GembosAPI.DataAccessLayer.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbcontext _context;

        public MessageRepository(AppDbcontext context)
        {
            _context = context;
        }
        public async Task DeleteMessageAsync(Guid id)
        {
            var message = await GetMessageByIdAsync(id);
            if (message != null)
            {
                _context.Set<Message>().Remove(message);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Message> GetMessageByIdAsync(Guid id)
        {
            return await _context.Set<Message>().FindAsync(id);
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync(String senderId, String receiverId)
        {
            return await _context.Set<Message>()
                .Where(m => (m.SenderID == senderId && m.ReceiverID == receiverId) ||
                      (m.SenderID == receiverId && m.ReceiverID == senderId))
                .OrderBy(m => m.TimeStamp)
                .ToListAsync();
        }

        public async Task SendMessageAsync(Message message)
        {
            await _context.Set<Message>().AddAsync(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMessageAsync(Message message)
        {
            _context.Set<Message>().Update(message);
            await _context.SaveChangesAsync();
        }
    }
}
