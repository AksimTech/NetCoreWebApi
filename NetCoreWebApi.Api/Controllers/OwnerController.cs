using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Extensions;
using Entities.Models;

namespace NetCoreWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public OwnerController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners()
        {
            try
            {
                var owners = await _repository.Owner.GetAllOwnersAsync();
                return Ok(owners);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "OwnerById")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerByIdAsync(id);
                if (owner.IsEntityObject())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/account")]
        public async Task<IActionResult> GetOwnerWithDetails(int id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerWithDetailsAsync(id);
                if (owner.IsEntityObject())
                {
                    return NotFound();
                }
                else
                {
                    return Ok(owner);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
        {
            try
            {
                if(owner.IsObjectNull())
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                await _repository.Owner.CreateOwnerAsync(owner);

                return CreatedAtRoute("OwnerById", new { id = owner.Id }, owner);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOwner(int id, [FromBody]Owner owner)
        {
            try
            {
                if (owner.IsObjectNull())
                {
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var dbOwner = await _repository.Owner.GetOwnerByIdAsync(id);
                if (dbOwner.IsEntityObject())
                {
                    return NotFound();
                }

                await _repository.Owner.UpdateOwnerAsync(dbOwner, owner);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            try
            {
                var owner = await _repository.Owner.GetOwnerByIdAsync(id);
                if (owner.IsEntityObject())
                {
                    return NotFound();
                }

                await _repository.Owner.DeleteOwnerAsync(owner);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}