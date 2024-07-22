using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Windows.Input;
using utf.Service;
using utf.DataBase;
using utf.Models;
using utf.AlertPopup;
using CommunityToolkit.Maui.Views;

namespace utf
{
    public partial class MainPageViewModel : ObservableObject
    {
        /// <summary> Ввод рублей пользователем </summary>
        [ObservableProperty]
        public double inputAmount = 0;
        /// <summary> Повторный вывод валюты при дальнейшей конвертации </summary>
        [ObservableProperty]
        public double repeatMoneyInRUB;
        /// <summary> Показ выпадающего списка с целевыми валютами </summary>
        [ObservableProperty]
        public bool visiblePickerTargetCurrency = true;
        /// <summary> Выбранная валюта С КАКОЙ нужно перевести </summary>
        [ObservableProperty]
        public string fromSelectedTargetCurrency;
        /// <summary> Валюта В КОТОРУЮ нужно перевести </summary>
        [ObservableProperty]
        public string whereSelectedTargetCurrency;
        /// <summary> Конвертированная валюта </summary>
        [ObservableProperty]
        public double convertedCurrency;
        /// <summary> Показ конвертированной валюты </summary>
        //[ObservableProperty]
        //public bool visibleConvertedCurrency = true;
        /// <summary> После нажатия кнопки конвертации, значение MoneyInRUB сохраняется в этом свойстве как журнал</summary>
        [ObservableProperty]
        public double showConvertFromRUB;

        public CurrencyConverter CurrencyConverter { get; }
        // public ObservableCollection<string> MagazineConversions { get; set; } = new();

        public static MainPageViewModel Instance = new MainPageViewModel();
        public ObservableCollection<ConvertCurrencyModel> MagazineConversionsDB { get; set; } = new();

        public MainPageViewModel()
        {
            CurrencyConverter = new();
            MagazineConvert();
        }
       
        /// <summary> Метод для перевода рублей в целевую валюту </summary>
        [RelayCommand]
        public void StartConvert()
        {
            if (InputAmount > 1)
            {
                //var ConvertedInputPrice = CurrencyConverter.Convert(inputAmount, FromSelectedTargetCurrency);
                var Converting = CurrencyConverter.Convert2(InputAmount, FromSelectedTargetCurrency, WhereSelectedTargetCurrency);
                ShowConvertFromRUB = InputAmount;
                //ConvertedCurrency = ConvertedInputPrice;
                ConvertedCurrency = Converting;
                
                var MagazineConvert = new ConvertCurrencyModel { RUB = InputAmount, CurrencyFrom = FromSelectedTargetCurrency, OtherCurrency = ConvertedCurrency, CurrencyTo = WhereSelectedTargetCurrency };
                Save(MagazineConvert);
                MagazineConversionsDB.Add(MagazineConvert);
            }
            else Application.Current.MainPage.ShowPopup(new FirstPopup()); 
        }
        /// <summary>
        /// Метод для сохранения значений в бд
        /// </summary>
        /// <param name="model">запись строк</param>
        public void Save(ConvertCurrencyModel model)
        {
            using (MyDbContext context = new MyDbContext())
            {
                context.ConvertCurrency.Add(model);
                context.SaveChanges();
            }
        }

        /// <summary> журнал конвертаций </summary>
        public void MagazineConvert()
        {
            using (MyDbContext context = new MyDbContext())
            {
                MagazineConversionsDB.Clear();
                //context.ConvertCurrency.RemoveRange(context.ConvertCurrency);
                //context.SaveChanges();
                foreach (var element in context.ConvertCurrency)
                {
                    MagazineConversionsDB.Add(element);
                }
            }
        }
    }
}
