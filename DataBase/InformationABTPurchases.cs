using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace utf.DataBase
{
    public class InformationABTPurchases : ViewModelBase
    {
        public static InformationABTPurchases DBInfoVM = new InformationABTPurchases();

        private string inputPurchase;
        private int inputPrice;
        private ICommand savePurchase;
        private string getElementPurchases;
        private ObservableCollection<string> dataPurchases;
        private ICommand showHistoryPurchases;
        private string purchasesHist;
        private int priceHist;
        private ICommand deleteFromHistory;
        private string behaviorDeletePurchases;

        public string InputPurchase
        {
            get => inputPurchase;
            set
            {
                inputPurchase = value;
                OnPropertyChanged(nameof(InputPurchase));
            }
        }

        public int InputPrice
        {
            get => inputPrice;
            set
            {
                inputPrice = value;
                OnPropertyChanged(nameof(InputPrice));
            }
        }

        public ICommand SavePurchase
        {
            get => savePurchase;
            set
            {
                savePurchase = value;
                OnPropertyChanged(nameof(SavePurchase));
            }
        }

        public string GetElementPurchases
        {
            get => getElementPurchases;
            set
            {
                getElementPurchases = value;
                OnPropertyChanged(nameof(GetElementPurchases));
            }
        }
        public ICommand ShowHistoryPurchases
        {
            get => showHistoryPurchases;
            set
            {
                showHistoryPurchases = value;
                OnPropertyChanged(nameof(ShowHistoryPurchases));
            }
        }
        public string PurchasesHist
        {
            get => purchasesHist;
            set
            {
                purchasesHist = value;
                OnPropertyChanged(nameof(PurchasesHist));
            }
        }
        public int PriceHist
        {
            get => priceHist;
            set
            {
                priceHist = value;
                OnPropertyChanged(nameof(PriceHist));
            }
        }
        public ICommand DeleteFromHistory
        {
            get => deleteFromHistory;
            set
            {
                deleteFromHistory = value;
                OnPropertyChanged(nameof(DeleteFromHistory));
            }
        }
        public ObservableCollection<object> BehaviorDeletePurchases { get; set; } = new();

        //public ObservableCollection<somedata> SavesCollectionElementsPurchases { get; set; } = new();       
        //public ObservableCollection<Purchases> SavesCollectionElementsPurchases { get; set; } = new();
        public ObservableCollection<Purchases> DataPurchases { get; set; } = new();

        public InformationABTPurchases()
        {
            //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "InformationABPurchases");
            //_database = new SQLiteConnection(dbPath);
            //_database.CreateTable<somedata>();
            SavePurchase = new Command(SaveMagazine);
            ShowHistoryPurchases = new Command(ShowDBPurchases);
            DeleteFromHistory = new Command(DeleteElementHistory);
            ShowDBPurchases();

        }
        public static void save(Purchases pur)
        {
            using (MyDbContext context = new MyDbContext())
            {
                context.Purchases.Add(pur);
                context.SaveChanges();
            }
        }

        public void SaveMagazine()
        {
            if (string.IsNullOrEmpty(InputPurchase) || string.IsNullOrEmpty(InputPurchase) == false)
            {
                var newPurchase = new Purchases { Purchase = InputPurchase, PriceRUB = InputPrice };
                save(newPurchase);
                DataPurchases.Add(newPurchase);
            }
        }
        public void ShowDBPurchases()
        {
            //Purchases? purchases = new Purchases();
            //var a = purchases.Purchase;
            //if (a is null) return;
            //db.Remove(a);

            //var ReaderDB = db.Purchases.ToList();

            //foreach (var element in ReaderDB)
            //{
            //    DataPurchases.Add(element.Purchase);
            //    DataPurchases.Add(element.PriceRUB);
            //    _ = 0;
            //}


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

