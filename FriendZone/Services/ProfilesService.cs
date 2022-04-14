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
      List<Profile> profiles = _profilesRepository.GetAll();
      profiles.ForEach(p =>
      {
        List<ProfilesFollowsViewModel> followers = GetProfileFollowers(p.Id);
        p.Followers = followers;
      });
      profiles.ForEach(p =>
      {
        List<ProfilesFollowsViewModel> following = GetProfileFollowing(p.Id);
        p.Following = following;
      });
      return profiles;
    }

    public Profile GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal List<ProfilesFollowsViewModel> GetProfileFollowers(string id)
    {
      List<ProfilesFollowsViewModel> followers = _profilesRepository.GetProfileFollowers(id);

      return followers;
    }

    internal List<ProfilesFollowsViewModel> GetProfileFollowing(string id)
    {
      return _profilesRepository.GetProfileFollowing(id);
    }
  }

}