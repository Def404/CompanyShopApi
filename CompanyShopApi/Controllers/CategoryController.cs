using CompanyShopApi.Models;
using CompanyShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyShopApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController :  ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService) =>
        _categoryService = categoryService;

    [HttpGet]
    public async Task<List<Category>> Get() =>
        await _categoryService.GetAsync();
    
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Category>> Get(string id)
    {
        var category = await _categoryService.GetAsync(id);

        if (category is null)
        {
            return NotFound();
        }

        return category;
    }
}
