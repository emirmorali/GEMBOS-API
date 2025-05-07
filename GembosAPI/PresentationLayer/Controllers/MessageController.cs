using GembosAPI.BusinessLayer.Abstract;
using GembosAPI.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GembosAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("SyncMessage")]
        public async Task<IActionResult> AddMessage([FromBody] Message message)
        {
            await _messageService.SaveMessageAsync(message);
            return Ok();
        }

        [HttpPost("SyncMultipleMessage")]
        public async Task<IActionResult> AddMessages([FromBody] List<Message> messages)
        {
            await _messageService.SaveMessagesAsync(messages);
            return Ok();
        }
    }
}
