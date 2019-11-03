using System;
using MvvmCross.ViewModels;
using MvxMovies.Core.ViewModels;

namespace MvxMovies.Core
{
    public class MvxApp : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<FirstViewModel>();
        }
    }
}
