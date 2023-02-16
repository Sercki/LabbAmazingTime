﻿namespace AT.Membership.Database.Services;

public interface IDbService
{
    Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
        where TEntity : class, IEntity
        where TDto : class;
    Task<TReferenceEntity> AddReferenceAsync<TReferenceEntity, TDto>(TDto dto)
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class;
    Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> expression) where TEntity : class, IEntity;
    bool Delete<TReferenceEntity, TDto>(TDto dto)
        where TReferenceEntity : class
        where TDto : class;
    Task<bool> DeleteAsync<TEntity>(int id) where TEntity : class, IEntity;
    Task<List<TDto>> GetAsync<TEntity, TDto>()
        where TEntity : class, IEntity
        where TDto : class;
    Task<List<TDto>> GetAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class;
    Task<List<TDto>> GetReferenceAsync<TReferenceEntity, TDto>()
        where TReferenceEntity : class, IReferenceEntity
        where TDto : class;
    string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity;
    void Include<TEntity>() where TEntity : class;          //, IEntity;    
    Task<bool> SaveChangesAsync();
    Task<TDto> SingleAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class;
    void Update<TEntity, TDto>(int id, TDto dto)
        where TEntity : class, IEntity
        where TDto : class;
}