using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class FollowsController : ControllerBase
  {
    private readonly FollowsService _followsService;

    public FollowsController(FollowsService followsService)
    {
      _followsService = followsService;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Follow>> Create([FromBody] Follow followData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Follow follow = _followsService.Create(userInfo.Id, followData);
        return Created($"api/follows/{follow.Id}", follow);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        _followsService.Delete(userInfo.Id, id);
        return Ok("Deleted");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}