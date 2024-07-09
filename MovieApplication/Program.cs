using System.Threading.Channels;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{

    class Program
    {
        static void Main(string[] args)
        {
              // MovieTest();
        }
         
        private static void MovieTest()
        {
            MovieManager movieManager = new MovieManager(new EfMovieDal());

            var result = movieManager.GetMovieDetails();

            if (result.Success == true)
            {
                foreach (var movie in result.Data)
                {
                    Console.WriteLine(movie.MovieName + " / " + movie.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

           
        }
    }
}

