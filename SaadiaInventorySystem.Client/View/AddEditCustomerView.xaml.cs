﻿using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for AddEditCustomerView.xaml
    /// </summary>
    public partial class AddEditCustomerView : Window, IClosable
    {
        public AddEditCustomerView(CustomerViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
