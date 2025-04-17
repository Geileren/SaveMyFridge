using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaveMyFridge.Api.Data;
using SaveMyFridge.Lib.DTOs;
using SaveMyFridge.Lib.Models;

namespace SaveMyFridge.Api;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    // private members:
    private readonly SaveMyFridgeDbContext _context;

    // Constructor
    public IngredientsController(SaveMyFridgeDbContext context)
    {
        _context = context;
    }

    // Endpoints

    [HttpGet("GetAll")]
    public async Task<ActionResult<Ingredient>> GetAllIngredients()
    {
        var IngredientDTOs = await _context.Ingredients.Select(i => new IngredientDTO
        {
            IngredientId = i.IngredientId,
            Name = i.Name
        }).ToListAsync();

        return Ok(IngredientDTOs);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<Ingredient>> CreateNewIngredient(IngredientDTO ingredientDTO)
    {
        // Creating the ingredient from recieved data
        var ingredient = new Ingredient
        {
            Name = ingredientDTO.Name,
            //IngredientId = ingredientDTO.IngredientId
        };

        //adding and saving to database
        await _context.Ingredients.AddAsync(ingredient);
        await _context.SaveChangesAsync();


        return ingredient;
    }
}