using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Utils;

namespace WebAPI.Controllers
{
    public class ConversationController : Controller
    {
        private readonly IConversationService _converationService;

        public ConversationController(IConversationService converationService)
        {
            _converationService = converationService;
        }

        [Authorize]
        [HttpPost("send message")]
        public IActionResult SendMessage(string content, int secondUserId)
        {
            if(_converationService.SendMessage(content, secondUserId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                 return Ok("Wysłano pomyślnie.");
            return BadRequest("Nie udało się wysłać wiadomości.");
        }

        [Authorize]
        [HttpDelete("delete message")]
        public IActionResult DeleteMessage(int messageId)
        {
            if(_converationService.DeleteMessage(messageId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return Ok("Wiadomość została usunięta.");
            return BadRequest("Nie udało się usunąć wiadomości.");
        }
        
        [Authorize]
        [HttpDelete("delete conversation")]
        public IActionResult DeleteConversation(int conversationId)
        {
            if (_converationService.DeleteConversation(conversationId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return Ok("Konwersacja została usunięta.");
            return BadRequest("Nie udało się usunąć wiadomości.");
        }
    }
}
