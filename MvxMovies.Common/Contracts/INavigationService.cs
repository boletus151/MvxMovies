using System;
using MvvmCross.Navigation;

namespace MvxMovies.Common.Contracts
{
    public interface INavigationService
    {
        IMvxNavigationService MvxNavigationService { get; }
    }
}
