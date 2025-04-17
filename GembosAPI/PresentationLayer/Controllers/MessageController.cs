using GembosAPI.BusinessLayer.ServiceInterfaces;
using GembosAPI.EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GembosAPI.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {
            await _service.SendMessageAsync(createMessageDTO);
            return Ok();
        }

        [HttpGet("GetMessageByID")]
        public async Task<IActionResult> GetMessage(Guid id)
        {
            var message = await _service.GetMessageByIdAsync(id);
            if (message == null) return NotFound();
            return Ok(message);
        }

        [HttpGet("GetAllMessages")]
        public async Task<IActionResult> GetMessages(string senderId, string receiverId)
        {
            var messages = await _service.GetMessagesAsync(senderId, receiverId);
            return Ok(messages);
        }

        [HttpPut("UpdateMessage")]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            await _service.UpdateMessageAsync(updateMessageDTO);
            return Ok();
        }

        [HttpDelete("DeleteMessage")]
        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            await _service.DeleteMessageAsync(id);
            return Ok();
        }
    }
}

