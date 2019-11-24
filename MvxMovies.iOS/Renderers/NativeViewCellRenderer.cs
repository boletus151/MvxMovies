using UIKit;
using WeBuild.App.Controls.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ViewCell), typeof(NativeViewCellRenderer))]
namespace WeBuild.App.Controls.iOS.Renderers
{
    public class NativeViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            reusableCell = base.GetCell(item, reusableCell, tv);

            reusableCell.SelectionStyle = UITableViewCellSelectionStyle.None;

            return reusableCell;
        }
    }
}
