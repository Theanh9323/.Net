using MovieManagement.DataAccess.Context;
using MovieManagement.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieManagementDbContext _context;

        public UnitOfWork(MovieManagementDbContext context)
        {
            _context = context;
            ActorRepository = new ActorRepository(_context);
            MovieRepository = new MovieRepository(_context);
            GenerationRepository = new GenreRepository(_context);
            BiographyRepository = new BiographyRepository(_context);
        }

        public IActorRepository ActorRepository {get; private set;}

        public IMovieRepository MovieRepository { get; private set; }

        public IGenerRepository GenerationRepository { get; private set; }

        public IBiographyRepository BiographyRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
 