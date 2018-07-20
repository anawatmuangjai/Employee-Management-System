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

        public string EmployeeId
        {
            get => EmployeeIDTextBox.Text.Trim();
            set => EmployeeIDTextBox.Text = value;
        }

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
            get => ThaiLastNameTextBox.Text.Trim();
            set => ThaiLastNameTextBox.Text = value;
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

        public int DepartmentId { get; set; }

        public int SectionId { get; set; }

        public byte ShiftId { get; set; }

        public int JobId { get; set; }

        public int LevelId { get; set; }

        public int BusStationId { get; set; }

        public DateTime BirthDate { get => BirthDatePicker.Value; }

        public DateTime JoinDate { get => JoinDatePicker.Value; }

        public DateTime HireDate { get => HireDatePicker.Value; }

        public DateTime ChangedDate { get => DateTime.Now; }

        public byte[] EmployeeImage { get; set; }

        public IList<JobTitleModel> Jobs
        {
            set
            {
                var jobs = value;
                JobComboBox.DataSource = jobs;
                JobComboBox.DisplayMember = "JobTitle";
                JobComboBox.ValueMember = "JobTitleId";
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

        public IList<BusStationModel> BusStations
        {
            set
            {
                var shifts = value;
                BusStationComboBox.DataSource = shifts;
                BusStationComboBox.DisplayMember = "BusStationName";
                BusStationComboBox.ValueMember = "BusStationId";
                BusStationComboBox.SelectedIndex = -1;
            }
        }

        public EmployeePresenter Presenter { private get; set; }



        private async void NewToolStripButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            await Presenter.GetEmployeeLevelsAsync();
            await Presenter.GetDepartmentsAsync();
            await Presenter.GetSectionsAsync();
            await Presenter.GetShiftsAsync();
            await Presenter.GetJobsAsync();
            await Presenter.GetBusStationAsync();

            RegistrationPanel.Enabled = true;
            BrowsePanel.Enabled = true;
            GlobalIDTextBox.Select();

            Cursor = Cursors.Default;
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

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await Presenter.SaveAsync();
            Cursor = Cursors.Default;
            Clear();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            EmployeeId = string.Empty;
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

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeComboBox.SelectedIndex < 0)
                return;

            EmployeeType = TypeComboBox.Text.Trim();
        }

        private void JobComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JobComboBox.SelectedIndex < 0)
                return;

            var job = JobComboBox.SelectedItem as JobTitleModel;
            JobId = job.JobTitleId;
        }

        private void LevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LevelComboBox.SelectedIndex < 0)
                return;

            var level = LevelComboBox.SelectedItem as EmployeeLevelModel;
            LevelId = level.LevelId;
        }

        private void DepartmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DepartmentComboBox.SelectedIndex < 0)
                return;

            var department = DepartmentComboBox.SelectedItem as DepartmentModel;
            DepartmentId = department.DepartmentId;
        }

        private void SectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SectionComboBox.SelectedIndex < 0)
                return;

            var section = SectionComboBox.SelectedItem as SectionModel;
            SectionId = section.SectionId;
        }

        private void ShiftComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ShiftComboBox.SelectedIndex < 0)
                return;

            var shift = ShiftComboBox.SelectedItem as ShiftModel;
            ShiftId = shift.ShiftId;
        }

        private void BusStationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BusStationComboBox.SelectedIndex < 0)
                return;

            var bus = BusStationComboBox.SelectedItem as BusStationModel;
            BusStationId = bus.BusStationId;
        }

        private void TitleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ShiftComboBox.SelectedIndex < 0)
                return;

            Title = TitleComboBox.Text.Trim();
        }

        private void MaleGenderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MaleGenderRadioButton.Checked)
            {
                Gender = "M";
            }
        }

        private void FemaleGenderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (FemaleGenderRadioButton.Checked)
            {
                Gender = "F";
            }
        }


    }
}
