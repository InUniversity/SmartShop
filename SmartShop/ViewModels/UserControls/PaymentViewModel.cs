using System;
using System.Collections.Generic;
using System.Windows.Input;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveOrder
    {
        void Receive(List<OrderItem> items);
    }
    
    public class PaymentViewModel : BaseViewModel, IReceiveOrder
    {
        private List<OrderItem> orderItems = new List<OrderItem>(); 
        public List<OrderItem> OrderItems { get => orderItems; set { orderItems = value; OnPropertyChanged(); } }
        
        
        public ICommand ValidateCommand { get; private set; }

        public PaymentViewModel()
        {
            SetCommands();
        }

        private void SetCommands()
        {
            ValidateCommand = new RelayCommand<object>(ExecuteValidate);
        }

        private void ExecuteValidate(object obj)
        {
            throw new NotImplementedException();
        }

        public void Receive(List<OrderItem> items)
        {
            OrderItems = items;
        }
    }
}
