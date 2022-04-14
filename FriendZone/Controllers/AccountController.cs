using System;
using System.Threading.Tasks;
using FriendZone.Models;
using FriendZone.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
  [ApiController]
  [Authorize]
  [Route("[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
      _accountService = accountService;
    }

    [HttpGet]
    public async Task<ActionResult<Account>> Get()
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        return Ok(_accountService.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut]
    [Authorize]
    public async Task<ActionResult<Account>> Update([FromBody] Account updateData, string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        updateData.Id = id;
        Account update = _accountService.Edit(updateData, userInfo);
        return Created($"api/account/{update.Id}", update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }


}