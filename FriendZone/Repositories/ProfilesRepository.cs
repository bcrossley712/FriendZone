using System.Collections.Generic;
using System.Data;
using FriendZone.Interfaces;
using FriendZone.Models;

namespace FriendZone.Repositories
{
  public class ProfilesRepository : IRepository<Profile, int>
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Profile> GetAll()
    {
      throw new System.NotImplementedException();
    }

    public Profile GetById(int id)
    {
      throw new System.NotImplementedException();
    }
    public Profile Create(Profile data)
    {
      throw new System.NotImplementedException();
    }
    public void Update(Profile data)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new System.NotImplementedException();
    }

  }
}