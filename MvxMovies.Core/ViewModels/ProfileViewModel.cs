using System.Threading.Tasks;
using MvxMovies.Core.ViewModels.Base;

namespace MvxMovies.Core.ViewModels
{
    public class ProfileViewModel : MvxBaseViewModel
    {
        public ProfileViewModel(IBaseViewModel baseViewModel) : base(baseViewModel)
        {
        }

        public override async Task Initialize()
        {
            await Task.Delay(5000);
        }
    }
}
