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
            lblQuantity.TextColor = Color.FromHex("#e19a17");           
        }
	}
}