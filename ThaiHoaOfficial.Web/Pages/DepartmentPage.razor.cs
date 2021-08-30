using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Models;
using System.Threading;
using ThaiHoaOfficial.Web.Components.Departments;

namespace ThaiHoaOfficial.Web.Pages
{
    public class DepartmentPageBase : ComponentBase
    {
        [Inject]
        public HttpClient httpClient { get; set; }
        public string SearchString = "";
        public Department SelectedItem = null;
        public HashSet<Department> SelectedItems = new HashSet<Department>();
        public IEnumerable<Department> Departments;
        public CreateOrUpdateDepartment frmCreateOrUpdate;

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        public bool FilterFunc1(Department element) => FilterFunc(element, SearchString);

        private bool FilterFunc(Department element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private async Task LoadData()
        {
            Departments = await httpClient.GetFromJsonAsync<List<Department>>("api/departments/danh-sach-phong-ban");
            await Task.Delay(3000);
        }
        public async Task ShowCreateDepartment()
        {
          await  frmCreateOrUpdate.ShowDialog(new Department());
        }
    }
}
