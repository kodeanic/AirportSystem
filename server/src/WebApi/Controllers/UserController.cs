using AutoMapper;
using Domain.Entities;
using Infrastructure.Dto;
using Infrastructure.Interfaces.IConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UserController(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _unitOfWork.Users.GetAll();
        return Ok(response.Select(user => _mapper.Map<UserDto>(user)));
    }

    [HttpGet("{login}")]
    public async Task<IActionResult> GetUsersByLogin(string login) =>
        Ok(_mapper.Map<UserDto>(await _unitOfWork.Users.GetByLogin(login)));

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        User user = _mapper.Map<User>(userDto);

        await _unitOfWork.Users.Create(user);
        await _unitOfWork.CompleteAsync();
        
        return Ok(user.Id);
    }

    [HttpDelete("{login}")]
    public async Task<IActionResult> DeleteUser(string login)
    {
        var user = await _unitOfWork.Users.GetByLogin(login);

        if (user == null)
        {
            return BadRequest();
        }

        await _unitOfWork.UserInformations.Delete(user.Id);

        user.Information = null;
        user.Tickets = null;
        await _unitOfWork.Users.Delete(user.Id);

        await _unitOfWork.CompleteAsync();

        return Ok();
    }
}
