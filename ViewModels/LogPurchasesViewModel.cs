using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Windows.Input;
using utf.Service;
using utf.Models;
using utf.ManagementDB;

namespace utf.ViewModels
{
    public partial class LogPurchasesViewModel : ObservableObject
    {

        public static LogPurchasesViewModel DBInfoVM = new LogPurchasesViewModel();
        public CurrencyConverter CurrencyConverter { get; }

        /// <summary> Ввод покупки </summary>
        [ObservableProperty]
        public string inputPurchase;
        /// <summary> Ввод цены покупки </summary>
        [ObservableProperty]
        public int inputPrice;

        /// <summary> Выбранная целевая валюта </summary>
        [ObservableProperty]
        public object selectedConvertation;

        /// <summary> Коллекция для поведения удаления элементов </summary>
        public ObservableCollection<object> BehaviorDeletePurchases { get; set; } = new();

        /// <summary> Коллекция элементов из класса Purchases </summary>
        public ObservableCollection<PurchasesModel> DataPurchases { get; set; } = new();

        public LogPurchasesViewModel()
        {
            ShowDBPurchases();
            CurrencyConverter = new();
        }
        public static void Save(PurchasesModel pur)
        {
            using (MyDbContext context = new MyDbContext())
            {
                context.Purchases.Add(pur);
                context.SaveChanges();
            }
        }

        [RelayCommand]
        public void SavePurchase()
        {
            if (string.IsNullOrEmpty(InputPurchase) == false || InputPrice == 1 == false)
            {
                if (SelectedConvertation == null)
                {
                    var newPurchase1 = new PurchasesModel { Purchase = InputPurchase, PriceRUB = InputPrice, PriceConverted = 0, DatePurchase = DateTime.Now };
                    Save(newPurchase1);
                    DataPurchases.Add(newPurchase1);
                }
                else
                {
                    var ConvertedInputPrice = CurrencyConverter.Convert(InputPrice, SelectedConvertation.ToString());

                    var newPurchase = new PurchasesModel { Purchase = InputPurchase, PriceRUB = InputPrice, PriceConverted = ConvertedInputPrice, DatePurchase = DateTime.Now };
                    Save(newPurchase);
                    DataPurchases.Add(newPurchase);
                }
            }
        }
        /// <summary> История покупок </summary>
        [RelayCommand]
        public void ShowDBPurchases()
        {
            using (MyDbContext context = new MyDbContext())
            {
                //context.Purchases.RemoveRange(context.Purchases);
                //context.SaveChanges();
                
                DataPurchases.Clear();
                foreach (var element in context.Purchases)
                {
                    DataPurchases.Add(element);
                }
            }
        }
        [RelayCommand]
        public void DeleteElementHistory()
        {
            using (MyDbContext context = new MyDbContext())
            {
                if (DataPurchases != null)
                {
                    //DataPurchases.Remove(BehaviorDeletePurchases);
                    foreach (var purchase in BehaviorDeletePurchases)
                    {
                        if (purchase is PurchasesModel item)
                        {
                            context.Purchases.Remove(item);
                        }
                    }
                    context.SaveChanges();
                    BehaviorDeletePurchases.Clear();
                }
            }
            ShowDBPurchases();
        }
    }
}

