using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ThaiHoaOfficial.Shared.Models;
using ThaiHoaOfficial.Web.Components.Departments;
using MudBlazor;
using ThaiHoaOfficial.Shared.CommandModels;
using ThaiHoaOfficial.Shared.Enums;

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
       [Inject]
        public IDialogService DialogService { get; set; }
        [Inject]
        public ISnackbar Snackbar { get; set; }
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
            if (element.Notification.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        private async Task LoadData()
        {
            Departments = await httpClient.GetFromJsonAsync<List<Department>>("api/departments/get-department-list");
        }
        public async Task ShowCreateDepartment()
        {
            DialogParameters keyValues = new DialogParameters();
            DialogOptions options = new DialogOptions()
            {
                CloseButton = true,
            };
            keyValues.Add("Department", new CreateOrUpdateDepartmentModel() { Id = Guid.Empty });
        
            var result = await DialogService.Show<CreateOrUpdateDepartment>("TẠO MỚI PHÒNG - BAN",keyValues, options).Result;
            if (!result.Cancelled)
            {
                if ((bool)result.Data)
                {
                    await LoadData();
                    Snackbar.Add("Tạo mới thành công!", Severity.Success);
                    StateHasChanged();
                }
                else
                {
                    Snackbar.Add("Tạo mới thất bại!", Severity.Error);
                }
            }
        }
        public async Task ShowUpdateDepartment(Department department)
        {
            DialogParameters keyValues = new DialogParameters();
            DialogOptions options = new DialogOptions()
            {
                CloseButton = true,
            };
            keyValues.Add("Department", new CreateOrUpdateDepartmentModel() { 
                Id = department.Id,
                Name = department.Name,
                Notification = department.Notification,
                Status = department.Status,
            });

            var result = await DialogService.Show<CreateOrUpdateDepartment>("CẬP NHẬT PHÒNG - BAN", keyValues, options).Result;
            if (!result.Cancelled)
            {
              
                if ((bool)result.Data)
                {
                    await LoadData();
                    Snackbar.Add($"Cập nhật {department.Name} thành công!", Severity.Success);
                    StateHasChanged();
                }
                else
                {
                    Snackbar.Add("Cập nhật thất bại!", Severity.Error);
                }
            }
        }
        public async Task ShowDeleteDepartment(Department department)
        {
            DialogParameters keyValues = new DialogParameters();
            keyValues.Add("Department", department);
            var result = await DialogService.Show<DeleteDepartment>("XÓA PHÒNG - BAN",keyValues).Result;
            if (!result.Cancelled)
            {
                if ((bool)result.Data)
                {
                    await LoadData();
                    Snackbar.Add($"Xóa {department.Name} thành công!", Severity.Success);
                    StateHasChanged();
                }
                else
                {
                    Snackbar.Add("Xóa thất bại!", Severity.Error);
                }    
            }
        }
    }
}
