using System;
using System.Collections.Generic;
using FriendZone.Interfaces;

namespace FriendZone.Models
{
  public class Profile : IRepoItem<string>
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Picture { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Likes { get; set; }

    public List<ProfilesFollowsViewModel> Followers { get; set; }
    public List<ProfilesFollowsViewModel> Following { get; set; }

  }
  public class ProfilesFollowsViewModel : Profile
  {
    public string FollowId { get; set; }
  }
}