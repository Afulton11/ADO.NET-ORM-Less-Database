using System;
namespace DatabaseFactory.Data.Contracts
{
    public interface IRepsoitory<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Get the entity whose PrimaryKey equals the given PrimaryKey.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="primaryKey">The entitiy's Primary Key</param>
        TEntity Get(object primaryKey);

        /// <summary>
        /// Save the specified entity.
        /// </summary>
        /// <param name="entity">The entity to update</param>
        void Save(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The Entity to delete.</param>
        void Delete(TEntity entity);
    }
}
