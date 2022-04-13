using System;
using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
  public class FollowsService
  {
    private readonly FollowsRepository _followsRepository;

    public FollowsService(FollowsRepository followsRepository)
    {
      _followsRepository = followsRepository;
    }

    public Follow GetById(int id)
    {
      Follow found = _followsRepository.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Follow id");
      }
      return found;
    }
    public Follow Create(string userId, Follow data)
    {
      data.Follower = userId;
      return _followsRepository.Create(data);
    }

    public void Delete(string userId, int id)
    {
      Follow found = GetById(id);
      if (found.Follower != userId && found.Following != userId)
      {
        throw new Exception("You cannot delete this Follow");
      }
      _followsRepository.Delete(id);
    }
  }
}