using System.Windows.Input;

namespace TechChallengeIgor.ViewModels
{
    public class PullRequestDetailPageViewModel : BaseViewModel
    {
        public override ICommand TryAgainCommand { get; set; }
        private string detailHtml;
        public string DetailHtml
        {
            get { return detailHtml; }
            set
            {
                if (detailHtml != value)
                {
                    detailHtml = value;
                    OnPropertyChanged("DetailHtml");
                }
            }
        }
    }
}
