using MyNextApp.Components.Domain;
using MyNextApp.Components.Repository.Abstract;
using MyNextApp.Components.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextApp.Components.Service
{
    public class IdeaService : IIdeaService
    {
        private readonly IGenericRepository<Idea> _genericRepository;

        /// <summary>
        ///     ctor
        /// </summary>
        public IdeaService(IGenericRepository<Idea> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        /// <summary>
        ///     Gets all the ideas out of the database
        /// </summary>
        /// <returns></returns>
        public List<Idea> Get()
        {
            return _genericRepository.Read();
        }

        /// <summary>
        ///     Adds a new idea to the database
        /// </summary>
        /// <param name="idea"></param>
        /// <returns></returns>
        public Idea Create(Idea idea)
        {
            return _genericRepository.Create(idea);
        }
    }
}
