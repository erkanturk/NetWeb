namespace _12_Dependency_Injection.Services
{
    public class ScopedRandomNumberService
    {
        private readonly int _randomNumber;
        public ScopedRandomNumberService()
        {
            _randomNumber=new Random().Next(1,1000);//Dependency injection
        }
        public int GetRandomNumber()
        {
            return _randomNumber;
        }

    }
}
