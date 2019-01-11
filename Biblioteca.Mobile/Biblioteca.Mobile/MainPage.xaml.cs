using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Biblioteca.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetAllBooks();
        }

        private async void GetAllBooks()
        {
            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync("https://biblioteca-a1.firebaseio.com");

            
        }
    }
}
