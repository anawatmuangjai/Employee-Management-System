using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EMS.WinForm.Views.Interfaces;
using EMS.WinForm.Presenters;
using EMS.ApplicationCore.Models;
using System.IO;

namespace EMS.WinForm.Views.UserControls
{
    public partial class RegistrationView : UserControl, IEmployeeView
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        public int EmployeeId { get; set; }

        public string GlobalId
        {
            get => GlobalIDTextBox.Text.Trim();
            set => GlobalIDTextBox.Text = value;
        }

        public string CardId
        {
            get => CardIDTextBox.Text.Trim();
            set => CardIDTextBox.Text = value;
        }

        public string EmployeeType
        {
            get => TypeComboBox.Text.Trim();
            set => TypeComboBox.Text = value;
        }

        public string Title
        {
            get => TitleComboBox.Text.Trim();
            set => TitleComboBox.Text = value;
        }

        public string FirstName
        {
            get => FirstNameTextBox.Text.Trim();
            set => FirstNameTextBox.Text = value;
        }

        public string LastName
        {
            get => LastNameTextBox.Text.Trim();
            set => LastNameTextBox.Text = value;
        }

        public string FirstNameThai
        {
            get => ThaiFirstNameTextBox.Text.Trim();
            set => ThaiFirstNameTextBox.Text = value;
        }

        public string LastNameThai
        {
            get => ThaiFirstNameTextBox.Text.Trim();
            set => ThaiFirstNameTextBox.Text = value;
        }

        public string Gender { get; set; }

        public bool AvailableFlag { get; set; }

        public string Address
        {
            get => AddressTextBox.Text.Trim();
            set => AddressTextBox.Text = value;
        }

        public string City
        {
            get => CityTextBox.Text.Trim();
            set => CityTextBox.Text = value;
        }

        public string Country
        {
            get => CountryTextBox.Text.Trim();
            set => CountryTextBox.Text = value;
        }

        public string PostalCode
        {
            get => PostalCodeTextBox.Text.Trim();
            set => PostalCodeTextBox.Text = value;
        }

        public string PhoneNumber
        {
            get => PhoneTextBox.Text.Trim();
            set => PhoneTextBox.Text = value;
        }

        public string EmailAddress
        {
            get => EmailTextBox.Text.Trim();
            set => EmailTextBox.Text = value;
        }

        public DateTime HireDate { get; set; }

        public DateTime ChangedDate { get; set; }

        public byte[] EmployeeImage { get; set; }

        public IList<JobModel> Jobs
        {
            set
            {
                var jobs = value;
                JobComboBox.DataSource = jobs;
                JobComboBox.DisplayMember = "JobTitle";
                JobComboBox.ValueMember = "JobId";
                JobComboBox.SelectedIndex = -1;
            }
        }

        public IList<EmployeeLevelModel> Levels
        {
            set
            {
                var levels = value;
                LevelComboBox.DataSource = levels;
                LevelComboBox.DisplayMember = "LevelName";
                LevelComboBox.ValueMember = "LevelId";
                LevelComboBox.SelectedIndex = -1;
            }
        }

        public IList<DepartmentModel> Departments
        {
            set
            {
                var levels = value;
                DepartmentComboBox.DataSource = levels;
                DepartmentComboBox.DisplayMember = "DepartmentName";
                DepartmentComboBox.ValueMember = "DepartmentId";
                DepartmentComboBox.SelectedIndex = -1;
            }
        }

        public IList<SectionModel> Sections
        {
            set
            {
                var levels = value;
                SectionComboBox.DataSource = levels;
                SectionComboBox.DisplayMember = "SectionName";
                SectionComboBox.ValueMember = "SectionId";
                SectionComboBox.SelectedIndex = -1;
            }
        }

        public IList<ShiftModel> Shifts
        {
            set
            {
                var shifts = value;
                ShiftComboBox.DataSource = shifts;
                ShiftComboBox.DisplayMember = "ShiftName";
                ShiftComboBox.ValueMember = "ShiftId";
                ShiftComboBox.SelectedIndex = -1;
            }
        }

        public EmployeePresenter Presenter { private get; set; }

        private async void NewToolStripButton_Click(object sender, EventArgs e)
        {
            await Presenter.GetEmployeeLevelsAsync();
            await Presenter.GetDepartmentsAsync();
            await Presenter.GetSectionsAsync();
            await Presenter.GetShiftsAsync();
            await Presenter.GetJobsAsync();

            RegistrationPanel.Enabled = true;
            BrowsePanel.Enabled = true;
            GlobalIDTextBox.Select();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                openFile.Title = "Select a picture";
                openFile.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                                  "Portable Network Graphic (*.png)|*.png";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(openFile.FileName))
                    {
                        EmployeeImage = File.ReadAllBytes(openFile.FileName);

                        EmployeePictureBox.Image = new Bitmap(openFile.FileName);
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            EmployeeId = 0;
            GlobalId = string.Empty;
            CardId = string.Empty;
            EmployeeType = string.Empty;
            Title = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            FirstNameThai = string.Empty;
            LastNameThai = string.Empty;
            Gender = string.Empty;
            AvailableFlag = false;
            Address = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            PostalCode = string.Empty;
            PhoneNumber = string.Empty;
            EmailAddress = string.Empty;
        }
    }
}
