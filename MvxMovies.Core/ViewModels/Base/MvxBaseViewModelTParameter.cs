using System;
using MvvmCross.ViewModels;
using MvxMovies.AppServices.Contracts;
using MvxMovies.Common.Contracts;

namespace MvxMovies.Core.ViewModels.Base
{
    public class MvxBaseViewModel<TParameter> : MvxViewModel<TParameter>
    {
        public IBaseViewModel BaseViewModel { get; private set; }

        public MvxBaseViewModel(IBaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
        }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            base.ViewDestroy(viewFinishing);
            this.InitializeTask.PropertyChanged -= this.InitializeTask_PropertyChanged;
        }

        /// <summary>
        /// This method should be called in every View Code Behind when you
        /// need to subscribe to InitializeTask changes.
        /// </summary>
        public void OnViewModelSet()
        {
            if (this.InitializeTask is null)
            {
                return;
            }
            this.InitializeTask.PropertyChanged += this.InitializeTask_PropertyChanged;
        }

        /// <summary>
        /// It fires before Initialize to fill sent data from previous View Model
        /// </summary>
        /// <param name="parameter"></param>
        public override void Prepare(TParameter parameter) { }

        private void InitializeTask_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.InitializeTask.IsCompleted))
            {
                if (this.BaseViewModel.ShouldNavigateToLogin)
                {
                    this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<LoginViewModel>();
                }
            }
        }
    }
}
