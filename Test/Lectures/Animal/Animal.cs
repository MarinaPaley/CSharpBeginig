namespace Animals
{
    /// <summary>
    /// Абстрактный класс животное.
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// Имя.
        /// </summary>
        private string name;

        protected Animal()
        {
        }

        protected Animal(string name, Gender gender, DateOnly birthDate)
        {
            this.Id = Guid.NewGuid();

            this.Name = name;
            this.Gender = gender;
            this.BirthDate = birthDate;
        }

        public string Name
        {
            get => this.name;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Имя должно быть!");
                }

                this.name = value;
            }
        }

        protected Gender Gender { get; }

        protected Guid Id { get; }

        protected DateOnly BirthDate { get; }

        public abstract string Voice();

        public override string ToString()
        {
            var gender = this.Gender switch
            {
                Gender.Male => "м",
                Gender.Female => "ж",
                _ => throw new ArgumentOutOfRangeException(),
            };

            return $"{this.Name}, {this.BirthDate}, {gender}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return this.Id.Equals((obj as Animal)?.Id);
        }

        public override int GetHashCode() => this.Id.GetHashCode();
    }
}
