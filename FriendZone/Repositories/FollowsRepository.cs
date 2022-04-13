using System.Data;
using Dapper;
using FriendZone.Models;

namespace FriendZone.Repositories
{
  public class FollowsRepository
  {
    private readonly IDbConnection _db;

    public FollowsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Follow GetById(int id)
    {
      string sql = @"
      SELECT *
      FROM follows
      WHERE id = @id;
      ";
      return _db.QueryFirstOrDefault<Follow>(sql, new { id });
    }
    public Follow Create(Follow data)
    {
      string sql = @"
      INSERT INTO follows
      (follower, following)
      VALUES
      (@Follower, @Following);
      SELECT LAST_INSERT_ID();
        ";
      int id = _db.ExecuteScalar<int>(sql, data);
      data.Id = id;
      return data;
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM follows WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }
  }
}