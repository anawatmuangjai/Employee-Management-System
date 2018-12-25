namespace EMS.WebCore.Models.Dashboard
{
    public class AttendanceJob
    {
        public string FunctionName { get; set; }
        public int TotalPerson { get; set; }
        public int ActivePerson { get; set; }
        public int AbsentPerson { get; set; }
    }
}