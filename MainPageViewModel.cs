using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Windows.Input;
using utf.APIService;
using utf.DataBase;
using utf.Models;

namespace utf
{
    public partial class MainPageViewModel : ObservableObject
    {
        /// <summary> Ввод рублей пользователем </summary>
        [ObservableProperty]
        public double moneyInRUB;
        /// <summary> Повторный вывод валюты при дальнейшей конвертации </summary>
        [ObservableProperty]
        public double repeatMoneyInRUB;
        /// <summary> Показ выпадающего списка с целевыми валютами </summary>
        [ObservableProperty]
        public bool visiblePickerTargetCurrency = true;
        /// <summary> Выбранная целевая валюта </summary>
        [ObservableProperty]
        public string selectedTargetCurrency;
        /// <summary> Конвертированная валюта </summary>
        [ObservableProperty]
        public double convertedCurrency;
        /// <summary> Показ конвертированной валюты </summary>
        [ObservableProperty]
        public bool visibleConvertedCurrency = true;
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
            var ConvertedInputPrice = CurrencyConverter.Convert(MoneyInRUB, SelectedTargetCurrency);
            ShowConvertFromRUB = MoneyInRUB;
            ConvertedCurrency = ConvertedInputPrice;
            double[] ArrayMagazineConvert = new double[] { ShowConvertFromRUB, ConvertedCurrency };
            //var RubToTargetCurrency = string.Join(" ", ArrayMagazineConvert);
            //MagazineConversions.Add(RubToTargetCurrency);

            var MagazineConvert = new ConvertCurrencyModel { RUB = MoneyInRUB,OtherCurrency = ConvertedCurrency };
            Save(MagazineConvert);
            MagazineConversionsDB.Add(MagazineConvert);
            
            

        }
        /// <summary>
        /// Метод для сохранения значений в бд
        /// </summary>
        /// <param name="model">запись строк</param>
        public static void Save(ConvertCurrencyModel model)
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
