using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using API_Setup_Test_Task.Models;
using API_Setup_Test_Task.IRepository;

namespace API_Setup_Test_Task.Repository;
public class VehicleRepository : IVehicleRepository
{
    private readonly CarContext _context;

    public VehicleRepository(CarContext Context)
    {
        _context = Context;
    }

    public async Task<IEnumerable<Vehicle>> GetVehicleAsync()
    {
        var query = (from vehicle in _context.Vehicles
                      select vehicle).ToListAsync();
        return await query;
    }

    public async Task<Vehicle> GetVehicleByIdAsync(string id)
    {
        Vehicle vehicle = await _context.Vehicles.FindAsync(id);
        return vehicle;

    }

    public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        return vehicle;
    }

    public async Task<Vehicle> DeleteVehicleAsync(string id)
    {
        var vehicle = await GetVehicleByIdAsync(id);
        if(vehicle == null)
        {
            return vehicle;
        }
        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return vehicle;

    }
    
    public async Task<Vehicle> UpdateVehicleAsync(string id, Vehicle vehicle)
    {
        var vehicleQuery = await GetVehicleByIdAsync(id);
        if(vehicleQuery == null)
        {
            return vehicleQuery;
        }
        
        _context.Entry(vehicleQuery).CurrentValues.SetValues(vehicle);
        await _context.SaveChangesAsync();

        return vehicleQuery;
    }
    // JsonPatchDocument formats Client submitted JSON for PATCH
    public async Task<Vehicle> UpdateVehiclePatchAsync(string id, JsonPatchDocument vehicle)
    {
        var vehicleQuery = await GetVehicleByIdAsync(id);
        if (vehicleQuery == null)
        {
            return vehicleQuery;
        }
        vehicle.ApplyTo(vehicleQuery);
        await _context.SaveChangesAsync();

        return vehicleQuery;
    }
}