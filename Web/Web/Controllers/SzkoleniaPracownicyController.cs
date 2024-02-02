using Application.DTO;
using Application.PracownikCRUD.Update;
using Application.SzkoleniePracownikCRUD.Create;
using Application.SzkoleniePracownikCRUD.Delete;
using Application.SzkoleniePracownikCRUD.Get;
using Domain.SzkolenieAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Web.Web.Controllers;

[Route("api/szkoleniaPracownicy")]
[ApiController]
public class SzkoleniaPracownicyController : ControllerBase
{
    private readonly ILogger<SzkoleniaPracownicyController> _logger;

    public SzkoleniaPracownicyController(ILogger<SzkoleniaPracownicyController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SzkoleniePracownikDTO>> GetSzkoleniePracownicy()
    {
        try
        {
            var szkoleniePracownicyDTO =
                new GetSzkoleniePracownikQuery().GetSzkoleniaPracownicyDTO();
            return szkoleniePracownicyDTO;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w pobieraniu szkoleń pracowników: {ex}");
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<SzkoleniePracownik> GetSzkoleniePracownik(SzkoleniePracownikDTO inputDTO)
    {
        try
        {
            var szkoleniePracownikDTO = new GetSzkoleniePracownikQuery().GetSzkoleniePracownikDTO(
                inputDTO.SzkolenieId ?? 0,
                inputDTO.PracownikId ?? 00
            );

            if (szkoleniePracownikDTO == null)
            {
                return NotFound();
            }

            return Ok(szkoleniePracownikDTO);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w pobieraniu szkolenia pracownika: {ex}");
            return StatusCode(500);
        }
    }

    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut]
    public ActionResult PutWynikWProc(SzkoleniePracownikDTO szkoleniePracownikDTO)
    {
        try
        {
            new UpdateSzkoleniePracownikCommand().UpdateSzkoleniePracownikWynik(
                szkoleniePracownikDTO
            );
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w aktualizacji wyniku w procentach: {ex}");
            return StatusCode(500);
        }
    }

    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public ActionResult<SzkoleniePracownikDTO> PostSzkoleniePracownik(
        SzkoleniePracownikDTO szkoleniePracownikDTO
    )
    {
        try
        {
            var wynik = new CreateSzkoleniePracownikCommand().CreateSzkoleniePracownik(
                szkoleniePracownikDTO
            );
            return CreatedAtAction(nameof(GetSzkoleniePracownik), new { id = wynik }, wynik);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w dodawaniu nowego szkolenia pracownika: {ex}");
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSzkoleniePracownik(SzkoleniePracownikDTO szkoleniePracownikDTO)
    {
        try
        {
            new DeleteSzkoleniePracownikCommand().DeleteSzkoleniePracownik(
                szkoleniePracownikDTO.SzkolenieId ?? 0,
                szkoleniePracownikDTO.PracownikId ?? 0
            );
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Błąd w usuwaniu szkolenia pracownika: {ex}");
            return StatusCode(500);
        }
    }
}
