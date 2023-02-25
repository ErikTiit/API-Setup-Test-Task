using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Setup_Test_Task.Models;
using Microsoft.AspNetCore.JsonPatch;
using API_Setup_Test_Task.Repository;
using API_Setup_Test_Task.IRepository;

namespace API_Setup_Test_Task.Controllers
{
    [Route("/Vehicles")]
    [ApiController]
    public class VehicleController : Controller
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        // GET
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return await _vehicleRepository.GetVehicleAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle([FromRoute] string id)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> PostVehicle([FromBody] Vehicle vehicle)
        {
            await _vehicleRepository.AddVehicleAsync(vehicle);
            return CreatedAtAction("GetVehicle", new { id = vehicle.VIN }, vehicle);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] string id)
        {
            var vehicle = await _vehicleRepository.DeleteVehicleAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle([FromRoute] string id, [FromBody] Vehicle vehicle)
        {
            if (id != vehicle.VIN)
            {
                return BadRequest();
            }
            var updatedVehicle = await _vehicleRepository.UpdateVehicleAsync(id, vehicle);
            if (updatedVehicle == null)
            {
                return NotFound();
            }
            return Ok(updatedVehicle);
        }

        // PATCH
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchVehicle([FromRoute] string id, [FromBody] JsonPatchDocument vehicle)
        {
            
            var updatedVehicle = await _vehicleRepository.UpdateVehiclePatchAsync(id, vehicle);
            if (updatedVehicle == null)
            {
                return NotFound();
            }
            return Ok(updatedVehicle);
            
        }

        
        
    }
}
