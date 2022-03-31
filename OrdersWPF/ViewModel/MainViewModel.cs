using OrdersWPF.Core;

namespace OrdersWPF.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand ReadViewCommand { get; set; }

        public ReadViewModel ReadVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            ReadVM = new ReadViewModel();
            CurrentView = ReadVM;

            ReadViewCommand = new RelayCommand(o =>
            {
                CurrentView = ReadVM;
            });
        }
    }
    class ReadViewModel
    {
    }
}
