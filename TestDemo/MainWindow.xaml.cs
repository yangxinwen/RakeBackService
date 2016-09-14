﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TestDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var  client = CommunicationManager.GetClient();
            var bank = client.GetBankPager();
            Debug.WriteLine(bank.Item2);

            var result = client.AddBank(new RakeBackService.BankInfo() { bankName = "sdf" });
            Debug.WriteLine(result);


        }
    }
}
