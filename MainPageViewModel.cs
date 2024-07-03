using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Windows.Input;
using utf.Models;

namespace utf
{
    public class MainPageViewModel : ViewModelBase
    {
        public static MainPageViewModel Instance = new MainPageViewModel();



        private string currency;
        private string bigMoney;
        private bool isVisible = false;
        private Regex RegularNumber = new Regex(@"\d");
        private object selectedCur;
        private string converterMaster;
        private string historyConvertCurrency;
        private ICommand saveCurrency;
        private string currencyChanged;
        private bool visibleConverterMaster = true;
        private string convertedCurrencies;
        private string historyValueColumn;
        private Dictionary<string, double> changeCur;
        private string historyCurrencyDeletePage;
        private string behaviorDeleteCurrency;
        private ICommand deleteCurrencyNote;

        //private bool focusedElement;

        private const string APIKey = "fca_live_LAfEb6eP0tqbK1r5ML0P4PVKOTRiOqqDIKCQDP6k";
        private const string URLApi = "https://api.freecurrencyapi.com/v1/latest?apikey=" + APIKey + "&currencies=EUR,USD,CAD&base_currency=RUB";


        //public bool FocusedElement
        //{
        //    get => focusedElement; set
        //    {
        //        focusedElement = value;
        //        OnPropertyChanged(nameof(FocusedElement));
        //    }
        //}

        public string BehaviorDeleteCurrency
        {
            get => behaviorDeleteCurrency;
            set
            {
                behaviorDeleteCurrency = value;
                OnPropertyChanged(nameof(BehaviorDeleteCurrency));
            }
        }
        public object SelectedCur
        {
            get => selectedCur; set
            {
                selectedCur = value;
                Calculate();
                OnPropertyChanged(nameof(SelectedCur));
            }
        }

        public string CurrencyChanged
        {
            get => currencyChanged;
        }

        public string HistoryConvertCurrency
        {
            get => historyConvertCurrency;

            set
            {
                historyConvertCurrency = value;
                OnPropertyChanged(nameof(HistoryConvertCurrency));
            }
        }


        public string BigMoney
        {
            get => bigMoney; set
            {
                bigMoney = value;
                OnPropertyChanged(nameof(BigMoney));
            }
        }
        public string Currency
        {
            get => currency; set
            {
                currencyChanged = currency;
                currency = value;

                if (RegularNumber.IsMatch(value))
                {
                    if (Currency != null || Currency != "")
                    {

                        IsVisible = true;
                        BigMoney = value.ToString() + " Рублей конвертировать в ";

                    }

                    else if (int.TryParse(value, out _))
                    {
                        Calculate();
                    }

                }
                if (string.IsNullOrEmpty(Currency))
                {

                    BigMoney = value.ToString();
                    IsVisible = false;
                }
                if (Currency != CurrencyChanged)
                {
                    Calculate();
                }

                OnPropertyChanged(nameof(Currency));

            }
        }



        public string ConverterMaster
        {
            get => converterMaster; set
            {
                converterMaster = value;
                OnPropertyChanged(nameof(ConverterMaster));
            }
        }
        public bool IsVisible
        {
            get => isVisible; set
            {
                isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }
        public bool VisibleConverterMaster
        {
            get => visibleConverterMaster;
            set
            {
                visibleConverterMaster = value;
                OnPropertyChanged(nameof(VisibleConverterMaster));
            }
        }
        public string HistoryCurrencyDeletePage
        {
            get => historyCurrencyDeletePage;
            set
            {
                historyCurrencyDeletePage = value;
                OnPropertyChanged(nameof(HistoryCurrencyDeletePage));
            }
        }



        public ObservableCollection<string> ChangeCur { get; set; }

        public MainPageViewModel()
        {
            var cl = new HttpClient();
            var response = cl.GetFromJsonAsync<CurrencyModel>(URLApi).Result;
            var result = response;/*.Data.Eur;*/

            var EUR = response.Data.Eur;
            var USD = response.Data.Usd;
            var CAD = response.Data.Cad;
            _ = 0;

            changeCur = new Dictionary<string, double>()
            {
                {"USD" , USD },
                {"CAD", CAD },
                {"EUR", EUR},

            };
            ChangeCur = new ObservableCollection<string>(changeCur.Keys);

            SaveCurrency = new Command(ExecuteMethodHistoryCurrency);
            DeleteCurrencyNote = new Command(DeleteNoteCurrency);

            if (Preferences.ContainsKey("SumNewCurrency"))
            {
                var saved = Preferences.Get("SumNewCurrency", "");
                ConvertedCurrencies = saved;

            }



        }
        public ICommand DeleteCurrencyNote
        {
            get => deleteCurrencyNote;
            set
            {
                deleteCurrencyNote = value; OnPropertyChanged(nameof(DeleteCurrencyNote));
            }
        }

        public ICommand SaveCurrency
        {
            get => saveCurrency; set
            {
                saveCurrency = value;
                OnPropertyChanged(nameof(SaveCurrency));
            }

        }
        public string ConvertedCurrencies
        {
            get
            {
                return convertedCurrencies;
            }
            set
            {

                convertedCurrencies = value;
                OnPropertyChanged(nameof(ConvertedCurrencies));
            }
        }
        public string HistoryValueColumn
        {
            get => historyValueColumn;
            set
            {
                historyValueColumn = value;
                OnPropertyChanged(nameof(HistoryValueColumn));
            }
        }

        List<string> ContainerConvertedCurrency = new List<string>();
        public string SumNewCurrency;
        public ObservableCollection<string> ColumnCurrencyDelete { get; set; } = new();

       
        
        private void ExecuteMethodHistoryCurrency()
        {
            if (SumNewCurrency != null)
            {
                ContainerConvertedCurrency.Add(SumNewCurrency);
                var a = string.Join(", ", ContainerConvertedCurrency);
                ConvertedCurrencies = a;
                ColumnCurrencyDelete.Add(SumNewCurrency);
                HistoryCurrencyDeletePage = SumNewCurrency;

                Preferences.Set("SumNewCurrency", ConvertedCurrencies);
            }

        }


        private void Calculate()
        {

            if (string.IsNullOrEmpty(Currency))
            {
                VisibleConverterMaster = false;
            }
            else if (Double.TryParse(Currency, out double currencyValue))
            {
                VisibleConverterMaster = true;

                var v = currencyValue * (SelectedCur switch
                {
                    "USD" => changeCur["USD"],
                    "EUR" => changeCur["EUR"],
                    "CAD" => changeCur["CAD"],
                    _ => 0
                });

                SumNewCurrency = ConverterMaster = v.ToString();

            }

            _ = 0;
        }

        public void DeleteNoteCurrency()
        {
            if (string.IsNullOrEmpty(BehaviorDeleteCurrency) != true)
            {
                ColumnCurrencyDelete.Remove(BehaviorDeleteCurrency);
                ContainerConvertedCurrency.Remove(BehaviorDeleteCurrency);
                var UpdateCurrencyDelete = ContainerConvertedCurrency;
                var a = string.Join(", ", UpdateCurrencyDelete);
                ConvertedCurrencies = a;
                _ = 0;
            }
            
            //HistoryCurrencyDeletePage = HistoryConvertCurrency.Remove(0);
        }




    }
}
