﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using tweetz.core.ViewModels;

namespace tweetz.core.Views
{
    public partial class GetPinView : UserControl
    {
        private GetPinControlViewModel ViewModel => (GetPinControlViewModel)DataContext;

        public GetPinView()
        {
            InitializeComponent();
        }

        private void GetPinClick(object sender, RoutedEventArgs e)
        {
            GetPinClickAsync().ConfigureAwait(false);
        }

        private async ValueTask GetPinClickAsync()
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                await ViewModel.GetPinAsync().ConfigureAwait(true);
                await Task.Delay(TimeSpan.FromSeconds(5)).ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                ShowPage(2);
            }
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            SignInClickAsync().ConfigureAwait(false);
        }

        private async ValueTask SignInClickAsync()
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;
                await ViewModel.SignInAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ShowPage(1);
            }
            finally
            {
                Mouse.OverrideCursor = Cursors.Arrow;
                ShowPage(1);
            }
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            ShowPage(1);
        }

        private void ShowPage(int page)
        {
            if (page < 1 || page > 2) throw new ArgumentOutOfRangeException(nameof(page), "page argument must be 1 or 2");
            Page1.Visibility = page == 1 ? Visibility.Visible : Visibility.Hidden;
            Page2.Visibility = page == 2 ? Visibility.Visible : Visibility.Hidden;
        }
    }
}