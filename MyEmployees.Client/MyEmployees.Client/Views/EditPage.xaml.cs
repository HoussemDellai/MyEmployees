using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyEmployees.Client.Views
{
    public partial class EditPage : ContentPage
    {
        private int employeeId = 0;
        private string Uri = "http://myemployeesdirectory.azurewebsites.net/api/EmployeesApi/";
        public EditPage(Employee employee)
        {
            InitializeComponent();

            NameEntry.Text = employee.Name;
            DepartmentEntry.Text = employee.Department;
            employeeId = employee.Id;
        }

        private async void EditEmployee_Clicked(object sender, EventArgs e)
        {
            var employee = new Employee
            {
                Id = employeeId,
                Name = NameEntry.Text,
                Department = DepartmentEntry.Text
            };

            var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(employee);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await httpClient.PutAsync(Uri + employee.Id, httpContent);
        }

        private async void DeleteEmployee_Clicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(Uri + employeeId);
        }
    }
}
