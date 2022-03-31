using OrdersWPF.Core;

namespace OrdersWPF.ViewModel
{
    class DepartmentViewModel : ObservableObject
    {
        public RelayCommand DepartmentReadViewCommand { get; set; }
        public RelayCommand DepartmentCreateViewCommand { get; set; }
        public RelayCommand DepartmentUpdateViewCommand { get; set; }

        public DepartmentReadViewModel ReadDepartmentVM { get; set; }
        public DepartmentCreateViewModel CreateDepartmentVM { get; set; }
        public DepartmentUpdateViewModel UpdateDepartmentVM { get; set; }

        private object _currentView;
        public object CurrentViewDepartment
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public DepartmentViewModel()
        {
            ReadDepartmentVM = new DepartmentReadViewModel();
            CreateDepartmentVM = new DepartmentCreateViewModel();
            UpdateDepartmentVM = new DepartmentUpdateViewModel();

            CurrentViewDepartment = ReadDepartmentVM;

            DepartmentReadViewCommand = new RelayCommand(o =>
            {
                CurrentViewDepartment = ReadDepartmentVM;
            });

            DepartmentCreateViewCommand = new RelayCommand(o =>
            {
                CurrentViewDepartment = CreateDepartmentVM;
            });

            DepartmentUpdateViewCommand = new RelayCommand(o =>
            {
                CurrentViewDepartment = UpdateDepartmentVM;
            });
        }
    }

    class DepartmentReadViewModel
    {
    }
    class DepartmentCreateViewModel
    {
    }
    class DepartmentUpdateViewModel
    {
    }
}
