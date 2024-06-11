namespace NumbersApp_ASP.NET_Core_MVC.ViewModels
{
    public class NumbersViewModel
    {
        public List<int> Numbers { get; set; }

        public int? Sum { get; set; }

        public NumbersViewModel()
        {
            Numbers = new List<int>();
        }
    }
}
