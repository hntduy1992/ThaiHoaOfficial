using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Models;

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

        protected override async Task OnInitializedAsync()
        {
            Departments = await httpClient.GetFromJsonAsync<List<Department>>("api/departments/danh-sach-phong-ban");
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
    }
}
