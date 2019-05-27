﻿using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdCornicesView.xaml
    /// </summary>
    public partial class UpdCornicesView : UserControl, INavigatable
    {
        public UpdCornicesView()
        {
            InitializeComponent();
            DataContext = new UpdCornicesVM();
        }
    }
}