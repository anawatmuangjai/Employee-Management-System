using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class EducationMajorPresenter : Presenter<IEducationMajorView>
    {
        private readonly IEducationMajorService _majorService;
        private readonly IEducationDegreeService _degreeService;

        public EducationMajorPresenter(
            IEducationMajorView view,
            IEducationMajorService majorService,
            IEducationDegreeService degreeService)
            : base(view)
        {
            View.Presenter = this;
            _majorService = majorService;
            _degreeService = degreeService;
        }

        public async Task GetDegreeAsync()
        {
            View.EducationDegrees = await _degreeService.GetAllAsync();
        }

        public async Task ViewAllAsync()
        {
            View.EducationMajors = await _majorService.GetAllAsync();
        }

        public async Task SaveAsync()
        {
            var majorModel = new EducationMajorModel
            {
                MajorId = View.MajorId,
                DegreeId = View.DegreeId,
                MarjorName = View.MajorName,
                MajorNameThai = View.MajorNameThai
            };

            if (majorModel.MajorId > 0)
                await _majorService.UpdateAsync(majorModel);
            else
                await _majorService.AddAsync(majorModel);
        }

        public async Task DeleteAsync()
        {
            await _majorService.DeleteAsync(View.SelectedMajor);
        }
    }
}
