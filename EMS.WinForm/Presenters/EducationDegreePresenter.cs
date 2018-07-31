using EMS.ApplicationCore.Interfaces.Services;
using EMS.ApplicationCore.Models;
using EMS.WinForm.Presenters.Interfaces;
using EMS.WinForm.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.WinForm.Presenters
{
    public class EducationDegreePresenter : Presenter<IEducationDegreeView>
    {
        private readonly IEducationDegreeView _view;
        private readonly IEducationDegreeService _degreeService;

        public EducationDegreePresenter(
            IEducationDegreeView view,
            IEducationDegreeService degreeService)
            : base(view)
        {
            _view = view;
            _view.Presenter = this;
            _degreeService = degreeService;
        }

        public async Task ViewAllAsync()
        {
            _view.EducationDegrees = await _degreeService.GetAllAsync();
        }

        public async Task SaveAsync()
        {
            var degreeModel = new EducationDegreeModel
            {
                DegreeId = _view.DegreeId,
                DegreeName = _view.DegreeName,
                DegreeNameThai = _view.DegreeNameThai
            };

            if (degreeModel.DegreeId > 0)
                await _degreeService.UpdateAsync(degreeModel);
            else
                await _degreeService.AddAsync(degreeModel);
        }

        public async Task DeleteAsync()
        {
            await _degreeService.DeleteAsync(_view.SelectedDegree.DegreeId);
        }
    }
}
