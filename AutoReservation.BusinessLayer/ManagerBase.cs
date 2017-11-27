using AutoReservation.BusinessLayer.Exceptions;
using AutoReservation.Dal;
using System.Collections.Generic;

namespace AutoReservation.BusinessLayer
{
    public abstract class ManagerBase<T>
    {
        protected static OptimisticConcurrencyException<T> CreateOptimisticConcurrencyException<T>(AutoReservationContext context, T entity)
            where T : class
        {
            var dbEntity = (T)context.Entry(entity)
                .GetDatabaseValues()
                .ToObject();

            return new OptimisticConcurrencyException<T>($"Update {typeof(T).Name}: Concurrency-Fehler", dbEntity);
        }

        public abstract List<T> List { get; }
        public abstract T GetById(int id);
        public abstract T Update(T entity);
        public abstract T Insert(T entity);
        public abstract void Delete(T entity);
    }
}