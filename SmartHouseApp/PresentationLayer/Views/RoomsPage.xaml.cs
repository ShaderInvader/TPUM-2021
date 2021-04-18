﻿using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer.Views
{
    /// <summary>
    /// Interaction logic for RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        private RoomViewModel RoomViewModel { get; set; } = new RoomViewModel();
        public RoomsPage()
        {
            InitializeComponent();
            this.DataContext = RoomViewModel;
        }
    }
}
