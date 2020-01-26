using MvvmCross.ViewModels;
using MvxMovies.UI.Model.ReturnPageTypes;

namespace MvxMovies.Core.ViewModels.Base
{
    public class MvxBaseViewModel<TParameter,TResult> : MvxViewModel<TParameter,TResult>
    {
        public IBaseViewModel BaseViewModel { get; private set; }

        public MvxBaseViewModel(IBaseViewModel baseViewModel)
        {
            this.BaseViewModel = baseViewModel;
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

        /// <summary>
        /// It fires after going back from next View Model.
        /// Commonly used when navigation type is like:
        /// "var result = await NavigationService.MvxNavigationService.Navigate(TargetViewModel,TParameter,TResult)(parameter_to_send)"
        /// </summary>
        /// <param name="result"></param>
        protected virtual void ReturningToViewModel(ReturnTypeBase result) { }

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
