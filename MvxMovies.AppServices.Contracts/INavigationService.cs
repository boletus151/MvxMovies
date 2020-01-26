using System;
using MvvmCross.Navigation;

namespace MvxMovies.AppServices.Contracts
{
    public interface INavigationService
    {
        IMvxNavigationService MvxNavigationService { get; }
    }
}
