﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.BL.DTOs;
using UniversityApp.BL.Services.Implements;
using UniversityApp.Helpers;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{
    public class InstructorViewModel : BaseViewModel
    {
        private BL.Services.IInstructorService instructorService;
        private ObservableCollection<InstructorItemViewModel> instructors;
        private bool isRefreshing;
        private string filter;
        public List<InstructorItemViewModel> AllInstructors { get; set; }
        public string Filter
        {
            get { return this.filter; }
            set
            {
                this.SetValue(ref this.filter, value);
                this.GetInstructorsByName();
            }
        }

        public ObservableCollection<InstructorItemViewModel> Instructors
        {
            get { return this.instructors; }
            set { this.SetValue(ref this.instructors, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public InstructorViewModel()
        {
            instance = this;
            this.instructorService = new InstructorService();
            this.RefreshCommand = new Command(async () => await GetInstructors());
            this.RefreshCommand.Execute(null);
        }
        private static InstructorViewModel instance;
        public static InstructorViewModel GetInstance()
        {
            if (instance == null)
                return new InstructorViewModel();

            return instance;
        }

        public Command RefreshCommand { get; set; }

        async Task GetInstructors()
        {
            try
            {
                this.IsRefreshing = true;

                var connection = await instructorService.CheckConnection();
                if (!connection)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "No internet connection", "Cancel");
                    return;
                }

                var listInstructors = (await instructorService.GetAll(Endpoints.GET_INSTRUCTORS)).Select(x => ToInstructorItemViewModel(x)); ;
                this.AllInstructors = listInstructors.ToList();
                this.Instructors = new ObservableCollection<InstructorItemViewModel>(listInstructors);
                this.IsRefreshing = false;
            }
            catch (Exception ex)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
            }
        }
        private InstructorItemViewModel ToInstructorItemViewModel(InstructorDTO instructortDTO) => new InstructorItemViewModel
        {
            ID = instructortDTO.ID,
            LastName = instructortDTO.LastName,
            FirstMidName = instructortDTO.FirstMidName,
            HireDate = instructortDTO.HireDate
        };
        public void GetInstructorsByName()
        {
            var listInstructors = this.AllInstructors;
            if (!string.IsNullOrEmpty(this.Filter))
                listInstructors = listInstructors.Where(x => x.LastName.ToLower().Contains(this.Filter.ToLower()) ||
                                                                       x.FirstMidName.ToLower().Contains(this.Filter.ToLower())).ToList();

            this.Instructors = new ObservableCollection<InstructorItemViewModel>(listInstructors);
        }
    }
}