using System;
namespace MvxMovies.UI.Model.ReturnPageTypes
{
    public class ReturnTypeBase
    {
        private readonly string fromViewModel;
        
        public ReturnTypeBase()
        {
            this.fromViewModel = this.GetType().FullName;
        }
    }
}
