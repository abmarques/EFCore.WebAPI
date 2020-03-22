using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.WebAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class BatalhaController : ControllerBase {

    private readonly HeroiContext _context;

    public BatalhaController(HeroiContext context) {
      _context = context;
    }

    // GET: api/Batalha
    [HttpGet]
    public ActionResult Get() {
      return Ok(new Batalha());
    }

    // GET: api/Batalha/5
    [HttpGet("{id}", Name = "GetBatalha")]
    public string Get(int id) {
      return "value";
    }

    // POST: api/Batalha
    [HttpPost]
    public ActionResult Post(Batalha model) {
      try {

        _context.Add(model);
        _context.SaveChanges();

        return Ok("BAZINGA");

      } catch (Exception e) {

        return BadRequest($"Error: {e}");

      }
    }

    // PUT: api/Batalha/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, Batalha model) {
      try {

        if (_context.Batalhas.AsNoTracking().FirstOrDefault(b => b.Id == id) != null) {

          _context.Update(model);
          _context.SaveChanges();

          return Ok("BAZINGA");

        }

        return BadRequest("Not Found!");

      } catch (Exception e) {

        return BadRequest("Error: " + e);
      }
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }
  }
}
