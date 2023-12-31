using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using QRCodeApp.Shared.Models.Common;

namespace QrCodeApp.Api.Repositories.Abstract.Common;

public interface IGenericRepository<TSource> where TSource : BaseModel
{
    DbSet<TSource> Table { get; }
    Task<int> SaveAsync();
    Task<int> Save();

    // Query işlemleri
    Task<List<TSource>?> GetAllAsync();
    Task<List<TSource>?> GetAllAsync(Expression<Func<TSource, bool>> filter);
    Task<TSource?> GetSingleAsync(Expression<Func<TSource, bool>> filter);
    Task<int> GetCountAsync();
    Task<int> GetCountAsync(Expression<Func<TSource, bool>> filter);

    // Komut işlemleri
    Task<bool> InsertAsync(TSource item);
    Task<bool> UpdateAsync(TSource item);
    Task<bool> RemoveAsync(int item);
    Task<bool> RemoveRangeAsync(List<int> item);
}