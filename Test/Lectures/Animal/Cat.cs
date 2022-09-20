namespace Animals
{
    public class Cat : Animal
    {
        [Obsolete("For ORM only", true)]
        protected Cat()
            : base()
        {
        }

        public Cat(string name, Gender gender, DateOnly birthDate)
            : base(name, gender, birthDate)
        {
        }

        public override string Voice() => "Мяу!";
    }
}
