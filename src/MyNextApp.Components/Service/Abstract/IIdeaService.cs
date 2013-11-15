using MyNextApp.Components.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextApp.Components.Service.Abstract
{
    public interface IIdeaService
    {
        /// <summary>
        ///     Gets all the ideas out of the database
        /// </summary>
        /// <returns></returns>
        List<Idea> Get();

        /// <summary>
        ///     Adds a new idea to the database
        /// </summary>
        /// <param name="idea"></param>
        /// <returns></returns>
        Idea Create(Idea idea);
    }
}
