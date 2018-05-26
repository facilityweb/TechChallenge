using System.ComponentModel;
using System.Windows.Input;
using TechChallengeIgor.Domain;

namespace TechChallengeIgor.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public abstract ICommand TryAgainCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }
        private bool isError;
        public bool IsError
        {
            get { return isError; }
            set
            {
                if (isError != value)
                {
                    isError = value;
                    OnPropertyChanged("IsError");
                }
            }
        }
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }
        public void LoadingOn()
        {
            this.IsLoading = true;
        }
        public void LoadingOff()
        {
            this.IsLoading = false;
        }
        public void ErrorOcurred(string message = SystemInfra.DefaultMessage)
        {
            this.IsError = true;
            this.ErrorMessage = message;
        }
    }
}
