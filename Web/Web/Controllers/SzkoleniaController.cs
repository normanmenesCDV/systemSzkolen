using Application.DTO;
using Application.SzkolenieCRUD.Create;
using Application.SzkolenieCRUD.Delete;
using Application.SzkolenieCRUD.Get;
using Application.SzkolenieCRUD.Update;
using Domain.SzkolenieAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Web.Web.Controllers;

[Route("api/szkolenia")]
[ApiController]
public class SzkoleniaController : ControllerBase
{
    private readonly ILogger<SzkoleniaController> _logger;

    public SzkoleniaController(ILogger<SzkoleniaController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SzkolenieDTO>> GetSzkolenie()
    {
        try
        {
            var SzkolenieDTO = new GetSzkolenieQuery().GetSzkolenieDTO();
            return SzkolenieDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w pobieraniu szkoleń: {ex}");
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Szkolenie> GetSzkolenie(int id)
    {
        try
        {
            var szkolenieDTO = new GetSzkolenieQuery().GetSzkolenieDTO(id);

            if (szkolenieDTO == null)
            {
                return NotFound();
            }

            return Ok(szkolenieDTO);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w pobieraniu szkolenia: {ex}");
            return StatusCode(500);
        }
    }

    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public ActionResult PutSzkolenie(int id, SzkolenieDTO szkolenieDTO)
    {
        try
        {
            new UpdateSzkolenieCommand().UpdateSzkolenie(id, szkolenieDTO);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w aktualizacji danych szkolenia: {ex}");
            return StatusCode(500);
        }
    }

    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<SzkolenieDTO> PostSzkolenie(SzkolenieDTO szkolenieDTO)
    {
        try
        {
            var wynik = new CreateSzkolenieCommand().CreateSzkolenie(szkolenieDTO);
            return CreatedAtAction(nameof(GetSzkolenie), new { id = wynik }, wynik);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w dodawaniu nowego szkolenia: {ex}");
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSzkolenie(int id)
    {
        try
        {
            new DeleteSzkolenieCommand().DeleteSzkolenie(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w usuwaniu nowego szkolenia: {ex}");
            return StatusCode(500);
        }
    }
}
