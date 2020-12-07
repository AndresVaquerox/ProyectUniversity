using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UniversityApp.BL.DTOs;
using UniversityApp.BL.Services.Implements;
using UniversityApp.Helpers;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{
    public class OfficeAssignmentViewModel : BaseViewModel
    {
        private BL.Services.IOfficeAssignmentService officeAssignmentService;
        private ObservableCollection<OfficeAssignmentDTO> officeAssignments;
        private bool isRefreshing;

        public ObservableCollection<OfficeAssignmentDTO> OfficeAssignments
        {
            get { return this.officeAssignments; }
            set { this.SetValue(ref this.officeAssignments, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public OfficeAssignmentViewModel()
        {
            this.officeAssignmentService = new OfficeAssignmentService();
            this.RefreshCommand = new Command(async () => await GetOfficeAssignments());
            this.RefreshCommand.Execute(null);
        }

        public Command RefreshCommand { get; set; }

        async Task GetOfficeAssignments()
        {
            try
            {
                this.IsRefreshing = true;

                var connection = await officeAssignmentService.CheckConnection();
                if (!connection)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "No internet connection", "Cancel");
                    return;
                }

                var listOfficeAssignments = await officeAssignmentService.GetAll(Endpoints.GET_OFFICE_ASSIGNMENTS);
                this.OfficeAssignments = new ObservableCollection<OfficeAssignmentDTO>(listOfficeAssignments);
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