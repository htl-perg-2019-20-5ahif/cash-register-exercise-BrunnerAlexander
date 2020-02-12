using CashRegister.Models;
using CashRegister.Models.DTOs;
using Polly;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CashRegister.WPF
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            // Initialize the DelebateCommands
            AddToBasketCommand = new DelegateCommand<int?>(OnAddToBasket);
            CheckoutCommand = new DelegateCommand(async () => await OnCheckout(), () => Basket.Count > 0);

            // Change detection
            Basket.CollectionChanged += (_, __) =>
            {
                CheckoutCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(nameof(TotalSum));
            };
        }

        // Http Client
        private HttpClient HttpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5001"),
            Timeout = TimeSpan.FromSeconds(5)
        };
        

        //Get the products with Polly and save it in the Products Property
        private readonly AsyncPolicy RetryPolicy = Policy.Handle<HttpRequestException>().RetryAsync(5);
        public async Task InitAsync()
        {
            var productsString = await RetryPolicy.ExecuteAndCaptureAsync(
                async () => await HttpClient.GetStringAsync("/api/Products"));
            Products = JsonSerializer.Deserialize<ObservableCollection<Product>>(productsString.Result);
        }

        // Methods called when the button is clicked
        private void OnAddToBasket(int? productId)
        {
            var product = Products.First(p => p.Id == productId.Value);

            var basketItem = Basket.FirstOrDefault(p => p.ProductId == productId);
            if(basketItem != null)
            {
                basketItem.Amount++; ;
                basketItem.TotalPrice += product.Price;
                RaisePropertyChanged(nameof(TotalSum));
            }
            else
            {
                Basket.Add(new ReceiptLineViewModel
                {
                    ProductId = product.Id,
                    Amount = 1,
                    ProductName = product.Name,
                    TotalPrice = product.Price
                });
            }
        }
        private async Task OnCheckout()
        {
            var dto = Basket.Select(b => new ReceiptLineDto
            {
                ProductId = b.ProductId,
                Amount = b.Amount
            }).ToList();

            using (var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json"))
            {
                var response = await RetryPolicy.ExecuteAndCaptureAsync(async () => await HttpClient.PostAsync("api/receipts", content));

                response.Result.EnsureSuccessStatusCode();
            }

            Basket.Clear();
        }

        // Products, Basket Properties
        private ObservableCollection<Product> products;
        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }


        private ObservableCollection<ReceiptLineViewModel> basket = new ObservableCollection<ReceiptLineViewModel>();
        public ObservableCollection<ReceiptLineViewModel> Basket
        {
            get { return basket; }
            set { SetProperty(ref basket, value); }
        }


        // Sum Calculation
        public decimal TotalSum => Basket.Sum(rl => rl.TotalPrice);

        // DelegateCommands that are bound to the UI
        public DelegateCommand<int?> AddToBasketCommand { get; }
        public DelegateCommand CheckoutCommand { get; }
    }
}