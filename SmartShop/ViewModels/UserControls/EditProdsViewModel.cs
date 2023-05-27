using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Win32;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public class EditProdsViewModel : BaseViewModel
    {
        private List<ProductView> prods;
        public List<ProductView> Prods { get => prods; set { prods = value; OnPropertyChanged(); } }
        
        private ProductView selProd;
        public ProductView SelProd { get => selProd; set { selProd = value; OnPropertyChanged(); } }

        public List<Category> Categories { get; set; }

        public ICommand ChooseImgCommand { get; private set; }
        public ICommand AddProdCommand { get; private set; }
        public ICommand UpdateProdCommand { get; private set; }
        public ICommand DeleteProdCommand { get; private set; }
        
        private readonly ProductRepository prodRepos;
        private readonly CategoryRepository ctgRepos;
        
        public EditProdsViewModel(ProductRepository prodRepos, CategoryRepository ctgRepos)
        {
            this.prodRepos = prodRepos;
            this.ctgRepos = ctgRepos;
            SetCommands();
            SetComboBox();
            LoadProducts();
        }

        private void SetCommands()
        {
            ChooseImgCommand = new RelayCommand<object>(ExecuteChooseImg);
            AddProdCommand = new RelayCommand<object>(ExecuteAddProd);
            UpdateProdCommand = new RelayCommand<object>(ExecuteUpdateProd);
            DeleteProdCommand = new RelayCommand<string>(ExecuteDeleteProd);
        }

        private void ExecuteChooseImg(object obj)
        {
            throw new NotImplementedException();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == true)
            {
                var selectedImagePath = openFileDialog.FileName;
            }
        }

        private void ExecuteAddProd(object obj)
        {
            prodRepos.Add(SelProd);
            LoadProducts();
        }

        private void ExecuteUpdateProd(object obj)
        {
            prodRepos.Update(SelProd);
            LoadProducts();
        }

        private void ExecuteDeleteProd(string prodID)
        {
            prodRepos.Delete(prodID);
            LoadProducts();
        }

        private void LoadProducts()
        {
            Prods = prodRepos.GetAll();
        }

        private void SetComboBox()
        {
            Categories = ctgRepos.GetAll();
        }
    }
}