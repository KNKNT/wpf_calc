﻿using System;
using System.Data;
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

namespace test_nadly
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement element in MainGrid.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += Button_Click;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string buttonText = (string)((Button)e.OriginalSource).Content;

                if (buttonText == "C")
                    textBlock.Text = "";
                else if (buttonText == "=")
                {
                    string value = new DataTable().Compute(textBlock.Text, null).ToString();
                    textBlock.Text = value;
                }
                else
                    textBlock.Text += buttonText;
            }
            catch { }
        }
    }
}
