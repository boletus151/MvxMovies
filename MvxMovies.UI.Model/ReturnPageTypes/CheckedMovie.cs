using System;
namespace MvxMovies.UI.Model.ReturnPageTypes
{
    public class CheckedMovie : ReturnTypeBase
    {
        public bool Checked { get; private set; }

        public int CheckedMovieId { get; private set; }
        
        public CheckedMovie(bool checkedMovie, int id)
        {
            this.Checked = checkedMovie;
            this.CheckedMovieId = id;
        }
    }
}
