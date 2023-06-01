﻿using SmartShop.ViewModels.Base;
using System.Windows.Input;
using SmartShop.Models;
using SmartShop.Repositories;
using System.Collections.Generic;
using System.Windows;
using SmartShop.Database;

namespace SmartShop.ViewModels.UserControls
{
    public interface IReceiveCartItem
    {
        void Receive(CartItemView itemView);
    }
    
    public class CartViewModel : BaseViewModel, IReceiveCartItem, ILoadView
    {
        private List<CartItemView> items;
        public List<CartItemView> Items { get => items; set { items = value; OnPropertyChanged(); } }

        private int totalQuantity;
        public int TotalQuantity { get => totalQuantity; set { totalQuantity = value; OnPropertyChanged(); } }

        private decimal curWalletBalance;
        public decimal CurWalletBalance { get => curWalletBalance; set { curWalletBalance = value; OnPropertyChanged(); } }

        private decimal totalPrice;
        public decimal TotalPrice { get => totalPrice; set { totalPrice = value; OnPropertyChanged(); } }
        
        public ICommand PlusSelQtyProdCommand { get; private set; }
        public ICommand MinusSelQtyProdCommand { get; private set; }
        public ICommand DeleteCartItemCommand { get; private set; }
        public ICommand PayCommand { get; private set; }

        private readonly CartItemRepository cartItemRepos;
        private readonly OrderRepository orderRepos;
        private INavigateView navView;
        private IReceiveOrder payIns;

        private User user = CurrentDb.Ins.Usr;

        public CartViewModel(CartItemRepository cartItemRepos, OrderRepository orderRepos, INavigateView navView, IReceiveOrder payIns)
        {
            this.cartItemRepos = cartItemRepos;
            this.orderRepos = orderRepos;
            this.navView = navView;
            this.payIns = payIns;
            Load();
            SetCommands();
        }

        public void Load()
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            Items = cartItemRepos.SearchByUserID(user.ID);
            TotalQuantity = cartItemRepos.GetTotalQuantity(user.ID);
            CurWalletBalance = user.WalletBalance;
            TotalPrice = cartItemRepos.GetTotalPrice(user.ID);
        }

        private void SetCommands()
        {
            PlusSelQtyProdCommand = new RelayCommand<CartItemView>(ExecutePlusSelQtyProd);
            MinusSelQtyProdCommand = new RelayCommand<CartItemView>(ExecuteMinusSelQtyProd);
            DeleteCartItemCommand = new RelayCommand<object>(ExecuteDeleteCartItem);
            PayCommand = new RelayCommand<object>(ExecutePay);
        }

        private void ExecutePlusSelQtyProd(CartItemView item)
        {
            item.Quantity += 1;
            Update(item);
        }

        private void ExecuteMinusSelQtyProd(CartItemView item)
        {
            item.Quantity -= 1;
            Update(item);
        }

        private void ExecuteDeleteCartItem(object itemID)
        {
            cartItemRepos.Delete(itemID as string, out var notification);
            if (!string.IsNullOrEmpty(notification))
                MessageBox.Show(notification);
            Load();
        }

        private void Update(CartItem item)
        {
            cartItemRepos.Update(item, out var notification);
            if (!string.IsNullOrEmpty(notification))
                MessageBox.Show(notification, "", MessageBoxButton.OK);
            Load();
        }

        private void ExecutePay(object obj)
        {
            string orderID = orderRepos.GetNewOrder(CurrentDb.Ins.Usr.ID);
            payIns.Receive(orderID);
            navView.MoveToPaymentView();
        }

        public void Receive(CartItemView itemView)
        {
            cartItemRepos.Add(itemView, out var notification);
            MessageBox.Show(notification, "", MessageBoxButton.OK);
            Load();
        }
    }
}
