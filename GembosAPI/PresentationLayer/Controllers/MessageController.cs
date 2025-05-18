using GembosAPI.BusinessLayer.Abstract;
using GembosAPI.EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GembosAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("SyncMultipleMessage")]
        public async Task<IActionResult> AddMessages([FromBody] List<MessageDTO> messages)
        {

            foreach (var dto in messages)
            {
               await _messageService.SaveMessagesAsync(dto);
               
            }
            return Ok();
        }

        [HttpGet("ping")]
        [AllowAnonymous]
        public IActionResult Ping()
        {
            return Ok("API çalışıyor");
        }
    }
}
