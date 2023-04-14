using SmartShop.ViewModel.Base;
using System.Windows.Controls;

namespace SmartShop.ViewModel
{
    public class BuyerViewModel : BaseViewModel
    {
        private ContentControl currentChildView;
        public ContentControl CurrentChildView { get => currentChildView; set { currentChildView = value; OnPropertyChanged(); } }
    }
}
