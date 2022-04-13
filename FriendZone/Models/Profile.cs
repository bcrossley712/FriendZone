using System;
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


  }
  public class ProfilesFollowsViewModel : Profile
  {
    public string FollowId { get; set; }
  }
}