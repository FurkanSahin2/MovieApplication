using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMovieDal : EfEntityRepositoryBase<Movie, MovieDbContext> , IMovieDal
    {
        public List<MovieDetailDto> GetMovieDetails()
        {
            using (MovieDbContext context = new MovieDbContext())
            {
                var result = from m in context.Movies
                             join c in context.Categories
                             on m.CategoryId equals c.CategoryId
                             select new MovieDetailDto {MovieId = m.MovieId, MovieName = m.MovieName, CategoryName = c.CategoryName, Description = m.Description};
                
                return result.ToList();
            }

            
        }
    }
}
