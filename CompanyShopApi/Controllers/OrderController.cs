using CompanyShopApi.Models;
using CompanyShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;
    private readonly HardDriveService _hardDriveService;

    public OrderController(OrderService orderService, HardDriveService hardDriveService)
    {
        _orderService = orderService;
        _hardDriveService = hardDriveService;
    }
       

    [HttpPut("PushCart")]
    public async Task<IActionResult> PushCart(string id, Cart cartItem)
    {
        var order = await _orderService.GetAsync(id);

        if (order is null)
            return NotFound();

        await _orderService.PushCartAsync(id, cartItem);

        return NoContent();
    }
    
    [HttpPut("PullCart")]
    public async Task<IActionResult> PullCart(string id, string hardDriveId)
    {
        var order = await _orderService.GetAsync(id);
        var hardDrive = await _hardDriveService.GetAsync(hardDriveId);

        if (order is null)
            return NotFound();

        if (hardDrive is null)
            return NotFound();

        await _orderService.PullCartAsync(id, hardDriveId);

        return NoContent();
    }
}
