using API_Inmuebles.Data;
using API_Inmuebles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PropertiesController : ControllerBase
{
    private readonly RealEstateContext _context;

    public PropertiesController(RealEstateContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Property>>> GetProperties()
    {
        return await _context.Properties.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Property>> GetProperty(int id)
    {
        var property = await _context.Properties.FindAsync(id);

        if (property == null)
        {
            return NotFound();
        }

        return property;
    }

    [HttpPost]
    public async Task<ActionResult<Property>> PostProperty(Property property)
    {
        _context.Properties.Add(property);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProperty", new { id = property.Id }, property);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProperty(int id, Property property)
    {
        if (id != property.Id)
        {
            return BadRequest();
        }

        _context.Entry(property).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PropertyExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")] 
    public async Task<IActionResult> DeleteProperty(int id)
    {
        var rowsAffected = await _context.DeletePropertyByIdAsync(id);

        if (rowsAffected == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

    private bool PropertyExists(int id)
    {
        return _context.Properties.Any(e => e.Id == id);
    }
}