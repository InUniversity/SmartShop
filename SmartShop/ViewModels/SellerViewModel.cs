using System.Windows.Controls;
using System.Windows.Input;
using SmartShop.ConvertToModel;
using SmartShop.Database;
using SmartShop.Models;
using SmartShop.Queries;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;
using SmartShop.ViewModels.UserControls;
using SmartShop.Views.UserControls;

namespace SmartShop.ViewModels
{
    public class SellerViewModel : BaseViewModel
    {
        private ContentControl currentChildView;
        public ContentControl CurrentChildView { get => currentChildView; set { currentChildView = value; OnPropertyChanged(); } }
        
        public ICommand MoveToEditProdsViewCommand { get; private set; }
        
        private EditProdsUC editProdsUC;
        
        public SellerViewModel()
        {
            InitComponentsView();
            MoveToEditProdsView();
            SetCommands();
        }

        private void InitComponentsView()
        {
            var dbConn = new DbConnection();
            var convModelFactory = new ConvModelFactory();
            var dbConv = new DbConverter(convModelFactory);

            var prodQuery = new ProductQuery();
            var ctgQuery = new CategoryQuery();
            
            var prodRepos = new ProductRepository(dbConn, dbConv, prodQuery);
            var ctgRepos = new CategoryRepository(dbConn, dbConv, ctgQuery);

            var editProdVM = new EditProdsViewModel(prodRepos, ctgRepos);

            editProdsUC = new EditProdsUC { DataContext = editProdVM };
        }

        private void SetCommands()
        {
            MoveToEditProdsViewCommand = new RelayCommand<object>(_ => MoveToEditProdsView());
        }

        private void MoveToEditProdsView()
        {
            CurrentChildView = editProdsUC;
        }
    }
}
