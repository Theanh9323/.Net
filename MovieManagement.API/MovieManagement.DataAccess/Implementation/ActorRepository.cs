using Microsoft.EntityFrameworkCore;
using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Implementation
{
    internal class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(MovieManagementDbContext context) : base(context)
        {
        }

        public  IEnumerable<Actor> GetActorsWithMovies()
        {
            var actors = _context.Actors.Include(x => x.Movies).ToList();
            return actors;
        }
    }
}
