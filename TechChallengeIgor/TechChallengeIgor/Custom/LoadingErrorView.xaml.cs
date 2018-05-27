using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TechChallengeIgor.Custom
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingErrorView : ContentView
	{
		public LoadingErrorView ()
		{
			InitializeComponent ();
		}
	}
}