using System;
using System.Collections.Generic;
using FriendZone.Models;
using FriendZone.Repositories;

namespace FriendZone.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _profilesRepository;

    public ProfilesService(ProfilesRepository profilesRepository)
    {
      _profilesRepository = profilesRepository;
    }

    public List<Profile> GetAll()
    {
      throw new NotImplementedException();
    }

    public Profile GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal List<ProfilesFollowsViewModel> GetProfileFollowers(string id)
    {
      throw new NotImplementedException();
    }

    internal List<ProfilesFollowsViewModel> GetProfileFollowing(string id)
    {
      throw new NotImplementedException();
    }
  }

}