namespace NumbersApp_ASP.NET_Core_MVC.Services
{
    public class NumbersService : INumbersService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string NumbersSessionKey = "Numbers";
        private const string SumSessionKey = "Sum";
        
        private List<int> numbers;
        private int? sum;

        public NumbersService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            numbers = new List<int>();
        }

        private List<int> Numbers
        {
            get
            {
                if (!numbers.Any())
                {
                    var sessionData = _httpContextAccessor?.HttpContext?.Session.GetString(NumbersSessionKey);
                    if (!string.IsNullOrEmpty(sessionData))
                    {

                        numbers = System.Text.Json.JsonSerializer.Deserialize<List<int>>(sessionData);
                    }
                }

                return numbers;
            }
            set
            {
                numbers = value;
            }
        }

        private int? Sum
        {
            get
            {
                if (!sum.HasValue)
                {
                    var sessionData = _httpContextAccessor?.HttpContext?.Session.GetString(SumSessionKey);
                    if (!string.IsNullOrEmpty(sessionData))
                    {
                        sum = System.Text.Json.JsonSerializer.Deserialize<int?>(sessionData);
                    }
                }

                return sum;
            }
            set
            {
                sum = value;
            }
        }

        public List<int> GetNumbers()
        {
            return Numbers;
        }

        public int? GetSum()
        {
            return Sum;
        }

        public void AddNumber()
        {            
            var random = new Random();
            Numbers.Add(random.Next(1000));
            _httpContextAccessor?.HttpContext?.Session.SetString(NumbersSessionKey, System.Text.Json.JsonSerializer.Serialize(Numbers));
        }

        public void ClearNumbers()
        {
            var emptyList = new List<int>();
            var defaultNullableInt = default(int?);
            _httpContextAccessor?.HttpContext?.Session.SetString(NumbersSessionKey, System.Text.Json.JsonSerializer.Serialize(emptyList));
            _httpContextAccessor?.HttpContext?.Session.SetString(SumSessionKey, System.Text.Json.JsonSerializer.Serialize(defaultNullableInt));
            Numbers = emptyList;
            Sum = defaultNullableInt;
        }

        public void SumNumbers()
        {
            Sum = Numbers.Sum();
            _httpContextAccessor?.HttpContext?.Session.SetString(SumSessionKey, System.Text.Json.JsonSerializer.Serialize(Sum));
        }
    }
}
