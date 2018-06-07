using Data.DBModel;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class AccountHobbyRepository : IAccountHobbyRepository
    {
        private readonly DatabaseContext _context;

        public AccountHobbyRepository(DatabaseContext context)
        {
            _context = context;
        }

        
        public AccountHobby JoinToGroup(AccountHobby accountHobby)
        {
            try
            {
                _context.Add(accountHobby);
                _context.SaveChanges();
                return _context.AccountHobby.Last();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccountHobby Add(AccountHobby entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public AccountHobby Edit(AccountHobby entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AccountHobby> GetAll()
        {
            throw new NotImplementedException();
        }
        
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
