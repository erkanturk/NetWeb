namespace _12_Dependency_Injection.Services
{
    public class SingletonRandomNumberService
    {
        private readonly int _randomNumber;
        public SingletonRandomNumberService()
        {
            _randomNumber=new Random().Next(1,1000);
        }
        public int GetRandomNumber()
        {
            return _randomNumber;
        }
    }
}
