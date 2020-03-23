using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class BatalhaController : ControllerBase {
    private readonly IEFCoreRepository _repo;

    public BatalhaController(IEFCoreRepository repo) {
      _repo = repo;
    }

    // GET: api/Batalha
    [HttpGet]
    public async Task<IActionResult> Get() {
      try {

        var herois = await _repo.GetAllHerois();

        return Ok(herois);

      } catch (Exception e) {

        return BadRequest($"Error: {e}");

      }

    }

    // GET: api/Batalha/5
    [HttpGet("{id}", Name = "GetBatalha")]
    public async Task<IActionResult> Get(int id) {
      try {

        var heroi = await _repo.GetHeroiById(id, true);

        return Ok(heroi);

      } catch (Exception e) {

        return BadRequest($"Erro: {e}");
      }
    }

    // POST: api/Batalha
    [HttpPost]
    public async Task<IActionResult> Post(Batalha model) {
      try {

        _repo.Add(model);

        if (await _repo.SaveChangeAsyc()) {

          return Ok("BAZINGA");

        }

      } catch (Exception e) {

        return BadRequest($"Error: {e}");

      }

      return BadRequest("Não salvou");
    }

    // PUT: api/Batalha/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, Batalha model) {
      try {

        //if (_context.Batalhas.AsNoTracking().FirstOrDefault(b => b.Id == id) != null) {
        // _repo.Update(model);
        //  _context.SaveChanges();

        return Ok("BAZINGA");

        //}

        return BadRequest("Not Found!");

      } catch (Exception e) {

        return BadRequest("Error: " + e);
      }
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {

      try {

        var heroi = await _repo.GetHeroiById(id);

        if (heroi != null) {

          _repo.Delete(heroi);

          if (await _repo.SaveChangeAsyc())

            return Ok("BAZINGA");
        }

      } catch (Exception e) {

        return BadRequest($"Error: {e}");

      }

      return BadRequest("Não deletado");

    }
  }
}
