using OrdersWPF.Core;

namespace OrdersWPF.ViewModel
{
    class OrderViewModel : ObservableObject
    {
        public RelayCommand OrderReadViewCommand { get; set; }
        public RelayCommand OrderCreateViewCommand { get; set; }
        public RelayCommand OrderUpdateViewCommand { get; set; }

        public OrderReadViewModel ReadOrderVM { get; set; }
        public OrderCreateViewModel CreateOrderVM { get; set; }
        public OrderUpdateViewModel UpdateOrderVM { get; set; }

        private object _currentView;
        public object CurrentViewOrder
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public OrderViewModel()
        {
            ReadOrderVM = new OrderReadViewModel();
            CreateOrderVM = new OrderCreateViewModel();
            UpdateOrderVM = new OrderUpdateViewModel();
            CurrentViewOrder = ReadOrderVM;

            OrderReadViewCommand = new RelayCommand(o =>
            {
                CurrentViewOrder = ReadOrderVM;
            });

            OrderCreateViewCommand = new RelayCommand(o =>
            {
                CurrentViewOrder = CreateOrderVM;
            });

            OrderUpdateViewCommand = new RelayCommand(o =>
            {
                CurrentViewOrder = UpdateOrderVM;
            });
        }
    }
    class OrderReadViewModel
    {
    }
    class OrderCreateViewModel
    {
    }
    class OrderUpdateViewModel
    {
    }
}
