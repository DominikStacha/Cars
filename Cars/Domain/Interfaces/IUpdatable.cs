﻿namespace Cars.Domain.Interfaces
{
    public interface IUpdatable<T>
    {
        void Update(T entity);
    }
}