using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using FriendZone.Models;

namespace FriendZone.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    public List<Profile> GetAll()
    {
      string sql = "SELECT * FROM accounts;";
      return _db.Query<Profile>(sql).ToList();
    }

    public Profile GetById(int id)
    {
      throw new System.NotImplementedException();
    }
    internal List<ProfilesFollowsViewModel> GetProfileFollowers(string id)
    {
      string sql = @"
      SELECT
        a.*,
        f.id AS FollowId
      FROM follows f
      JOIN accounts a ON a.id = f.follower
      WHERE f.following = @id;
      ";
      return _db.Query<ProfilesFollowsViewModel>(sql, new { id }).ToList();
    }

    internal List<ProfilesFollowsViewModel> GetProfileFollowing(string id)
    {
      string sql = @"
      SELECT
        a.*,
        f.id AS FollowId
      FROM follows f
      JOIN accounts a ON a.id = f.following
      WHERE f.follower = @id;
      ";
      return _db.Query<ProfilesFollowsViewModel>(sql, new { id }).ToList();
    }

  }
}