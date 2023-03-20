using CompanyShopApi.Models;
using CompanyShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConnectIntTypeController : ControllerBase
{
    private readonly ConnectionInterfaceTypeService _connectionInterfaceTypeService;

    public ConnectIntTypeController(ConnectionInterfaceTypeService connectionInterfaceTypeService) =>
        _connectionInterfaceTypeService = connectionInterfaceTypeService;

    [HttpGet]
    public async Task<List<ConnectionInterfaceType>> Get()
    {
        return await _connectionInterfaceTypeService.GetAsync();
    }
}
