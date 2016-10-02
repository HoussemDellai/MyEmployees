using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyEmployees.Client.Views
{
    public partial class AllPage : ContentPage
    {
        private string Uri = "http://myemployeesdirectory.azurewebsites.net/api/EmployeesApi";
        public AllPage()
        {
            InitializeComponent();

            DownloadEmployeesAsync();
        }

        private async Task DownloadEmployeesAsync()
        {
            var httpClient = new HttpClient();

            var json = await httpClient.GetStringAsync(Uri);

            var employees = JsonConvert.DeserializeObject<List<Employee>>(json);

            EmployeesListView.ItemsSource = employees;
        }

        private async void EmployeesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var employee = e.Item as Employee;

            if (employee != null)
            {
                await Navigation.PushModalAsync(new EditPage(employee));
            }
        }
    }
}
