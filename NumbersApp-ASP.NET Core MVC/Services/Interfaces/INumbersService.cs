namespace NumbersApp_ASP.NET_Core_MVC.Services
{
    public interface INumbersService
    {
        List<int> GetNumbers();
        int? GetSum();
        void AddNumber();
        void ClearNumbers();
        void SumNumbers();
    }
}
