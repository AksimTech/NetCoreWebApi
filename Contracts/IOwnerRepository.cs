using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.ExtendedModels;
using Entities.Models;

namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(int ownerId);
        Task<OwnerExtended> GetOwnerWithDetailsAsync(int ownerId);
        Task CreateOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner dbOnwer, Owner owner);
        Task DeleteOwnerAsync(Owner owner);
    }
}
