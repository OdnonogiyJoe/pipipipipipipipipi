﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7._04._2021
{
    /// <summary>
    /// Логика взаимодействия для PageSpecials.xaml
    /// </summary>
    public partial class PageSpecials : Page
    {
        public PageSpecials()
        {
            InitializeComponent();
            DataContext = new VMSpecials();
        }
    }
}
