using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32;
using SmartShop.Models;
using SmartShop.Repositories;
using SmartShop.ViewModels.Base;

namespace SmartShop.ViewModels.UserControls
{
    public class EditProdsViewModel : BaseViewModel, ILoadView
    {
        private List<ProductView> prods;
        public List<ProductView> Prods { get => prods; set { prods = value; OnPropertyChanged(); } }
        
        private ProductView selProd = new ProductView();
        public ProductView SelProd { get => selProd; set { selProd = value; OnPropertyChanged(); } }

        public List<Category> Categories { get; set; }

        private bool canAdd = false;
        public bool CanAdd { get => canAdd; set { canAdd = value; OnPropertyChanged(); } }

        private bool canUpdate = false;
        public bool CanUpdate { get => canUpdate; set { canUpdate = value; OnPropertyChanged(); } }

        private string textToSearch;
        public string TextToSearch { get => textToSearch; set { textToSearch = value; SearchByName(); OnPropertyChanged(); } }
            
        public ICommand ChooseImgCommand { get; private set; }
        public ICommand AddProdCommand { get; private set; }
        public ICommand UpdateProdCommand { get; private set; }
        public ICommand DeleteProdCommand { get; private set; }
        public ICommand OnAddModeCommand { get; private set; }
        public ICommand OnUpdateModeCommand { get; private set; }
        
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
            OnAddModeCommand = new RelayCommand<object>(_ => OnAddMode());
            OnUpdateModeCommand = new RelayCommand<object>(_ => OnUpdateMode());
        }

        private void ExecuteChooseImg(object obj)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif";

                if (openFileDialog.ShowDialog() == true)
                {
                    var selectedImagePath = openFileDialog.FileName;
                    byte[] imageBytes = File.ReadAllBytes(selectedImagePath);
                    SelProd.ImgUrl = Convert.ToBase64String(imageBytes);
                    OnPropertyChanged(nameof(SelProd));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        private void OnAddMode()
        {
            CanAdd = true;
            CanUpdate = false;
            SelProd = new ProductView { ID = prodRepos.GetNewID() };
        }

        private void OnUpdateMode()
        {
            CanAdd = false;
            CanUpdate = true;
        }

        private void SearchByName()
        {
            Prods = prodRepos.SearchByName(TextToSearch);
        }

        private void SetComboBox()
        {
            Categories = ctgRepos.GetAll();
        }

        public void Load()
        {
            LoadProducts();
        }
    }
}