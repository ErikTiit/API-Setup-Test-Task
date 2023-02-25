using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Setup_Test_Task.Models;

namespace API_Setup_Test_Task.IRepository;
public interface IVehicleRepository
{   //interface between API controller and repository
    Task<IEnumerable<Vehicle>> GetVehicleAsync();

    Task<Vehicle> GetVehicleByIdAsync(string id);

    Task<Vehicle> AddVehicleAsync(Vehicle vehicle);

    Task<Vehicle> DeleteVehicleAsync(string id);

    Task<Vehicle> UpdateVehicleAsync(string id, Vehicle vehicle);

    Task<Vehicle> UpdateVehiclePatchAsync(string id, JsonPatchDocument vehicle);
}
