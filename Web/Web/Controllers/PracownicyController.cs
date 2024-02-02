using Application.DTO;
using Application.PracownikCRUD.Create;
using Application.PracownikCRUD.Delete;
using Application.PracownikCRUD.Get;
using Application.PracownikCRUD.Update;
using Domain.PracownikAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Web.Web.Controllers;

[Route("api/pracownicy")]
[ApiController]
public class PracownicyController : ControllerBase
{
    private readonly ILogger<PracownicyController> _logger;

    public PracownicyController(ILogger<PracownicyController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PracownikDTO>> GetPracownicy()
    {
        try
        {
            var pracownicyDTO = new GetPracownikQuery().GetPracownicyDTO();
            return pracownicyDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w pobieraniu pracowników: {ex}");
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Pracownik> GetPracownik(int id)
    {
        try
        {
            var pracownikDTO = new GetPracownikQuery().GetPracownikDTO(id);

            if (pracownikDTO == null)
            {
                return NotFound();
            }

            return Ok(pracownikDTO);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w pobieraniu pracownika: {ex}");
            return StatusCode(500);
        }
    }

    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public ActionResult PutPracownik(int id, PracownikDTO pracownikDTO)
    {
        try
        {
            new UpdatePracownikCommand().UpdatePracownik(id, pracownikDTO);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w aktualizacji danych pracownika: {ex}");
            return StatusCode(500);
        }
    }

    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<PracownikDTO> PostPracownik(PracownikDTO pracownikDTO)
    {
        try
        {
            var wynik = new CreatePracownikCommand().CreatePracownik(pracownikDTO);
            return CreatedAtAction(nameof(GetPracownik), new { id = wynik }, wynik);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w dodawaniu nowego pracownika: {ex}");
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePracownik(int id)
    {
        try
        {
            new DeletePracownikCommand().DeletePracownik(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w usuwaniu nowego pracownika: {ex}");
            return StatusCode(500);
        }
    }
}
