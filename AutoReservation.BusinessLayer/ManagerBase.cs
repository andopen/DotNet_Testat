﻿using AutoReservation.BusinessLayer.Exceptions;
using AutoReservation.Dal;
using System.Collections.Generic;

namespace AutoReservation.BusinessLayer
{
    public abstract class ManagerBase
    {
        protected static OptimisticConcurrencyException<T> CreateOptimisticConcurrencyException<T>(AutoReservationContext context, T entity)
            where T : class
        {
            var dbEntity = (T)context.Entry(entity)
                .GetDatabaseValues()
                .ToObject();

            return new OptimisticConcurrencyException<T>($"Update {typeof(T).Name}: Concurrency-Fehler", dbEntity);
        }

        protected static OptimisticConcurrencyException<T> CreateOptimisticConcurrencyExceptionOnDelete<T>(AutoReservationContext context, T entity)
            where T : class
        {
            return new OptimisticConcurrencyException<T>($"Delete {typeof(T).Name}: Concurrency-Fehler", entity);
        }
    }
}