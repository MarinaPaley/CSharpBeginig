
namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, bool gender, DateTime birthDate) : base(name, gender, birthDate)
        {
        }

        protected override string Voice() => "Мяу!";

    }
}
