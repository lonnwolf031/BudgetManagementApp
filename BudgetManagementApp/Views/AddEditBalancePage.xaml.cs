﻿using BudgetManagementApp.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetManagementApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AddEditBalancePage : ContentPage
  {
    private bool isNewItem;

    public AddEditBalancePage()
    {
      InitializeComponent();
      isNewItem = true;
    }
    public AddEditBalancePage(Balance balance)
    {
      isNewItem = false;
    }

    async void OnButtonClicked(object sender, EventArgs args)
    {
      await Task.Run(() =>
      {
        // do thing
      });
    }
  }
}