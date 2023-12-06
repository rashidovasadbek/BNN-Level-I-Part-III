﻿using System.Linq.Expressions;
using Cashing.Infra.Domain.Common.Caching;
using Cashing.Infra.Domain.Common.Entities;
using Cashing.Infra.Domain.Comparers;

namespace Cashing.Infra.Domain.Common.Query;

public class QuerySpecification<TEntity>(uint pageSize, uint pageToken) : CacheModel where TEntity : IEntity
{

    public List<Expression<Func<TEntity, bool>>> FilteringOptions { get; } = new();

    public List<(Expression<Func<TEntity, object>> KeySelecter, bool IsAscending)> OrderingOptions { get; } = new();

    public FilterPagination PaginationOptions { get; set; } = new(pageSize, pageToken);

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var filter in FilteringOptions.Order(new PredicateExpressionComparer<TEntity>()))
            hashCode.Add(filter.ToString());

        foreach (var filter in OrderingOptions)
            hashCode.Add(filter.ToString());
        
        hashCode.Add(PaginationOptions);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification<TEntity> querySpecification && querySpecification.GetHashCode() == GetHashCode();
    }
    
    public override string CacheKey => $"{typeof(TEntity).Name}_{GetHashCode()}";
}