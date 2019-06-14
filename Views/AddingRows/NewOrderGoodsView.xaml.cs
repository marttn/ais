﻿using System.Windows;
using ais.ViewModels.AddingRowsVM;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewOrderGoodsView.xaml
    /// </summary>
    public partial class NewOrderGoodsView : Window
    {
        public NewOrderGoodsView()
        {
            InitializeComponent();
            DataContext = new OrderGoodsViewModel();
        }
    }
}
