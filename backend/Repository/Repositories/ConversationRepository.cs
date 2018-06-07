using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly DatabaseContext _context;

        public ConversationRepository(DatabaseContext context)
        {
            _context = context;
        }
    }
}
