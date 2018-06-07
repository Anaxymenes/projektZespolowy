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

        
        public bool JoinToGroup(AccountHobby accountHobby)
        {
            try
            {
                if (_context.AccountHobby.Any(x => x.AccountId == accountHobby.AccountId && x.HobbyId == accountHobby.HobbyId))
                {
                    return false; 
                }
                else
                {
                    _context.Add(accountHobby);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool leaveGroup(AccountHobby accountHobby)
        {
            try
            {
                if (_context.AccountHobby.Any(x => x.AccountId == accountHobby.AccountId && x.HobbyId == accountHobby.HobbyId))
                {
                    var temp = _context.AccountHobby.First(x => x.HobbyId == accountHobby.HobbyId && x.AccountId == accountHobby.AccountId);
                    _context.Remove(temp);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
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
