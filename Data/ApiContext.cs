using Microsoft.EntityFrameworkCore;
using DiaryAPI.Models;

namespace DiaryAPI.Data
{
  public class ApiContext : DbContext
  {
   public DbSet<Diary> Diaries { get; set; } 
    public ApiContext(DbContextOptions<ApiContext> options) :base(options)
    {
      
    }
  }
}