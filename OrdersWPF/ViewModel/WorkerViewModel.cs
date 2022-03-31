using OrdersWPF.Core;

namespace OrdersWPF.ViewModel
{
    class WorkerViewModel : ObservableObject
    {
        public RelayCommand WorkerReadViewCommand { get; set; }
        public RelayCommand WorkerCreateViewCommand { get; set; }
        public RelayCommand WorkerUpdateViewCommand { get; set; }

        public WorkerReadViewModel ReadWorkerVM { get; set; }
        public WorkerCreateViewModel CreateWorkerVM { get; set; }
        public WorkerUpdateViewModel UpdateWorkerVM { get; set; }

        private object _currentView;
        public object CurrentViewWorker
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public WorkerViewModel()
        {
            ReadWorkerVM = new WorkerReadViewModel();
            CreateWorkerVM = new WorkerCreateViewModel();
            UpdateWorkerVM = new WorkerUpdateViewModel();
            CurrentViewWorker = ReadWorkerVM;

            WorkerReadViewCommand = new RelayCommand(o =>
            {
                CurrentViewWorker = ReadWorkerVM;
            });

            WorkerCreateViewCommand = new RelayCommand(o =>
            {
                CurrentViewWorker = CreateWorkerVM;
            });

            WorkerUpdateViewCommand = new RelayCommand(o =>
            {
                CurrentViewWorker = UpdateWorkerVM;
            });
        }
    }
    class WorkerReadViewModel
    {
    }
    class WorkerCreateViewModel
    {
    }
    class WorkerUpdateViewModel
    {
    }
}
