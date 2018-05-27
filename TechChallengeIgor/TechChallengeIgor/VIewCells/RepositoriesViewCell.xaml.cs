using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechChallengeIgor.VIewCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RepositoriesViewCell : ViewCell
	{
		public RepositoriesViewCell ()
		{
			InitializeComponent ();
            lblForksQuantity.TextColor = Color.FromHex("#e19a17");
            lblWatchersQuantity.TextColor = Color.FromHex("#e19a17");
        }
	}
}