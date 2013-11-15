using MyNextApp.Components.Repository.Abstract;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNextApp.Components.Repository
{
    /// <summary>
    ///     Provides basic CRUD operations for interacting with the
    ///     RavenDB database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T>
    {
        /// <summary>
        ///     Creates connection to the database
        /// </summary>
        private readonly IDocumentStore _documentStore;

        /// <summary>
        ///     ctor
        /// </summary>
        public GenericRepository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        /// <summary>
        ///     Adds a new item to the database
        /// </summary>
        /// <param name="entity">
        ///     The item to be added to the database
        /// </param>
        /// <returns>
        ///     The item with the updated id field
        /// </returns>
        public T Create(T entity)
        {
            using (var session = _documentStore.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }

            return entity;
        }

        /// <summary>
        ///     Deletes the item out of the database
        /// </summary>
        /// <param name="entity">
        ///     The details surrounding the item to be deleted out of the database
        /// </param>
        public void Delete(int id)
        {
            using (var session = _documentStore.OpenSession())
            {
                var entity = session.Load<T>(id);
                session.Delete(entity);
                session.SaveChanges();
            }
        }

        /// <summary>
        ///     Reads a single item out of the database
        /// </summary>
        /// <param name="id">
        ///     The UID for that item in the database
        /// </param>
        /// <returns>
        ///     The data associated with that item in the database
        /// </returns>
        public T Read(int id)
        {
            T entity;

            using (var session = _documentStore.OpenSession())
            {
                entity = session.Load<T>(id);
            }

            return entity;
        }

        /// <summary>
        ///     Reads all the items out of the database
        /// </summary>
        /// <returns>
        ///     A collection of those items out of the database
        /// </returns>
        /// <remarks>
        ///     The most this query will return is 1000. If you
        ///     would like to pull back more data, then use the
        ///     paged query multiple times.
        /// </remarks>
        public List<T> Read()
        {
            List<T> entities;

            using (var session = _documentStore.OpenSession())
            {
                entities = session.Query<T>().Take(1000).ToList();
            }

            return entities;
        }

        /// <summary>
        ///     Reads a paged collection of items out of the database
        /// </summary>
        /// <param name="page">
        ///     The starting point in pages the query should start at
        /// </param>
        /// <param name="pageSize">
        ///     The maximum number of items to pull back
        /// </param>
        /// <returns>
        ///     A collection of items out of the database
        /// </returns>
        /// <remarks>
        ///     The most this query will return is 1000 entities. If
        ///     you would like to pull back more items, run this query
        ///     multiple times.
        /// </remarks>
        public List<T> Read(int page, int pageSize)
        {
            List<T> entities;

            var amount = pageSize;
            if (amount > 1000)
            {
                throw new ArgumentException("Limit page size to something lower than 1000");
            }

            using (var session = _documentStore.OpenSession())
            {
                entities = session.Query<T>().Skip(page * pageSize).Take(amount).ToList();
            }

            return entities;
        }

        /// <summary>
        ///     Updates an item in the database
        /// </summary>
        /// <param name="entity">
        ///     The item with the updated data
        /// </param>
        /// <returns>
        ///     The item with the updated data
        /// </returns>
        public T Update(T entity)
        {
            using (var session = _documentStore.OpenSession())
            {
                session.Store(entity);
                session.SaveChanges();
            }

            return entity;
        }
    }
}
