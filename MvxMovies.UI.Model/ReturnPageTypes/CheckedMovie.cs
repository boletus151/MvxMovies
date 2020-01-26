using System;
namespace MvxMovies.UI.Model.ReturnPageTypes
{
    public class CheckedMovie : ReturnTypeBase
    {
        public bool Checked { get; private set; }

        public string CheckedMovieId { get; private set; }
        
        public CheckedMovie(bool checkedMovie, string id)
        {
            this.Checked = checkedMovie;
            this.CheckedMovieId = id;
        }
    }
}
