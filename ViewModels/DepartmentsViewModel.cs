
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UniversityApp.BL.DTOs;
using UniversityApp.BL.Services.Implements;
using UniversityApp.Helpers;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{


    public class DepartmentsViewModel : BaseViewModel
    {

        private BL.Services.IDepartmentService departmentService;
        private ObservableCollection<DepartmentDTO> departments;
        private bool isRefreshing;


        public ObservableCollection<DepartmentDTO> Departments
        {
            get { return this.departments; }
            set { this.SetValue(ref this.departments, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public DepartmentsViewModel()
        {
            this.departmentService = new DepartmentService();
            this.RefreshCommand = new Command(async () => await GetDepartments());
            this.RefreshCommand.Execute(null);
        }
        public Command RefreshCommand { get; set; }

        async Task GetDepartments()
        {
            try
            {
                this.IsRefreshing = true;
                var connection = await departmentService.CheckConnection();
                if (!connection)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "No internet connection", "Cancel");
                    return;
                }
                var listDepartments = await departmentService.GetAll(Endpoints.GET_DEPARTMENTS);
                this.Departments = new ObservableCollection<DepartmentDTO>(listDepartments);
                this.IsRefreshing = false;
            }
            catch (Exception ex)

            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
            }

        }
    }
}