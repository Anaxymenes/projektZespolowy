using Data.DBModel;
using Data.DTO;
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
        [HttpGet("showConversation")]
        public List<MessageDTO> ShowConversation(int secondUserId)
        {
            var result = _converationService.ShowConversation(secondUserId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims));
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }

        [Authorize]
        [HttpGet("myConversations")]
        public List<ConversationDTO> ShowConversationsList()
        {
            var result = _converationService.ShowConversationsList(ClaimsMethods.GetClaimsList(HttpContext.User.Claims));
            if (result != null)
            {
                return result;
            }
            else
                return null;
        }
        
        [Authorize]
        [HttpPost("sendMessage")]
        public IActionResult SendMessage(string content, int secondUserId)
        {
            if(_converationService.SendMessage(content, secondUserId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                 return Ok("Wysłano pomyślnie.");
            return BadRequest("Nie udało się wysłać wiadomości.");
        }

        [Authorize]
        [HttpPut("renameConversation")]
        public IActionResult RenameConversation(string newName, int conversationId)
        {
            if (_converationService.RenameConversation(newName, conversationId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return Ok("Nazwa grupy została zmieniona.");
            return BadRequest("Nazwa grupy nie została zmieniona.");
        }
        
        [Authorize]
        [HttpDelete("deleteMessage")]
        public IActionResult DeleteMessage(int messageId)
        {
            if (_converationService.DeleteMessage(messageId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return Ok("Wiadomość została usunięta.");
            return BadRequest("Nie udało się usunąć wiadomości.");
        }

        [Authorize]
        [HttpDelete("deleteConversation")]
        public IActionResult DeleteConversation(int conversationId)
        {
            if (_converationService.DeleteConversation(conversationId, ClaimsMethods.GetClaimsList(HttpContext.User.Claims)))
                return Ok("Konwersacja została usunięta.");
            return BadRequest("Nie udało się usunąć konwersacji.");
        }
    }
}
