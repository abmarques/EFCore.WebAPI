﻿using EFCore.Dominio;
using EFCore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.WebAPI.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class HeroiController : ControllerBase {

    private readonly HeroiContext _context;

    public HeroiController(HeroiContext context) {
      _context = context;
    }

    // GET: api/Heroi
    [HttpGet]
    public ActionResult Get() {
      try {

        return Ok(new Heroi());

      } catch (Exception e) {

        return BadRequest($"Error: {e}");
      }

    }

    // GET: api/Heroi/5
    [HttpGet("{id}", Name = "Get")]
    public ActionResult Get(int id) {
      return Ok("value");
    }

    // POST: api/Heroi
    [HttpPost]
    public ActionResult Post(Heroi model) {
      try {

        _context.Herois.Add(model);
        _context.SaveChanges();

        return Ok("BAZINGA");

      } catch (Exception e) {

        return BadRequest($"Error: {e}");

      }
    }

    // PUT: api/Heroi/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, Heroi model) {
      try {

        if (_context.Herois.AsNoTracking().FirstOrDefault(h => h.Id == id) != null) {

          _context.Update(model);
          _context.SaveChanges();

          return Ok("BAZINGA");

        }

        return Ok("Not found!");

      } catch (Exception e) {

        return BadRequest($"ERROR: {e}");

      }
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }
  }
}
