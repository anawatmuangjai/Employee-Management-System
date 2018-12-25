using System.ComponentModel.DataAnnotations;

namespace EMS.WebCore.ViewModels.Level
{
    public class LevelEditViewModel
    {
        public int LevelId { get; set; }

        [Required, StringLength(30)]
        public string LevelName { get; set; }

        [Required, StringLength(10)]
        public string LevelCode { get; set; }
    }
}