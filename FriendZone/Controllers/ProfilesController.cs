using System;
using System.Collections.Generic;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _profilesService;

    public ProfilesController(ProfilesService profilesService)
    {
      _profilesService = profilesService;
    }
    [HttpGet]
    public ActionResult<List<Profile>> GetAll()
    {
      try
      {
        List<Profile> profiles = _profilesService.GetAll();
        return Ok(profiles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}")]
    public ActionResult<Profile> GetById(int id)
    {
      try
      {
        Profile profile = _profilesService.GetById(id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/followers")]
    public ActionResult<List<ProfilesFollowsViewModel>> GetProfileFollowers(string id)
    {
      try
      {
        List<ProfilesFollowsViewModel> followers = _profilesService.GetProfileFollowers(id);
        return Ok(followers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/following")]
    public ActionResult<List<ProfilesFollowsViewModel>> GetProfileFollowing(string id)
    {
      try
      {
        List<ProfilesFollowsViewModel> followers = _profilesService.GetProfileFollowing(id);
        return Ok(followers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}