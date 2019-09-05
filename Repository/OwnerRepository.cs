using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Entities.Models;
using Entities.ExtendedModels;
using Entities.Extensions;
using Contracts;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await FindAll()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Owner> GetOwnerByIdAsync(int ownerId)
        {
            return await FindByCondition(o => o.Id.Equals(ownerId))
                .DefaultIfEmpty(new Owner())
                .SingleAsync();
        }

        public async Task<OwnerExtended> GetOwnerWithDetailsAsync(int ownerId)
        {
            return await FindByCondition(o => o.Id.Equals(ownerId))
                .Select(owner => new OwnerExtended(owner)
                {
                    Accounts = RepositoryContext.Accounts
                    .Where(a => a.OwnerId.Equals(owner.Id))
                    .ToList()
                })
                .SingleOrDefaultAsync();
        }

        public async Task CreateOwnerAsync(Owner owner)
        {
            //Id = Guid.NewGuid();
            Create(owner);
            await SaveAsync();
        }

        public async Task UpdateOwnerAsync(Owner dbOwner, Owner owner)
        {
            dbOwner.Map(owner);
            Update(dbOwner);
            await SaveAsync();
        }

        public async Task DeleteOwnerAsync(Owner owner)
        {
            Delete(owner);
            await SaveAsync();
        }
    }
}
