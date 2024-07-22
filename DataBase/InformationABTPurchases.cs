using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Windows.Input;
using utf.Service;
using utf.Models;

namespace utf.DataBase
{
    public partial class InformationABTPurchases : ObservableObject
    {

        public static InformationABTPurchases DBInfoVM = new InformationABTPurchases();
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
        public ObservableCollection<Purchases> DataPurchases { get; set; } = new();

        public InformationABTPurchases()
        {
            ShowDBPurchases();
            CurrencyConverter = new();
        }
        public static void Save(Purchases pur)
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
                    var newPurchase1 = new Purchases { Purchase = InputPurchase, PriceRUB = InputPrice, PriceConverted = 0, DatePurchase = DateTime.Now };
                    Save(newPurchase1);
                    DataPurchases.Add(newPurchase1);
                }
                else
                {
                    var ConvertedInputPrice = CurrencyConverter.Convert(InputPrice, SelectedConvertation.ToString());

                    var newPurchase = new Purchases { Purchase = InputPurchase, PriceRUB = InputPrice, PriceConverted = ConvertedInputPrice, DatePurchase = DateTime.Now };
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
                        if (purchase is Purchases item)
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

