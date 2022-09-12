namespace Animals
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// Имя.
        /// </summary>
        private string name;
        private bool gender;
        private Guid id;
        private DateTime birthDate;

        protected Animal(string name, bool gender, DateTime birthDate)
        {
            this.Name = name;
            this.gender = gender;
            this.id = Guid.NewGuid();
            this.birthDate = birthDate;
        }

        protected string Name
        { 
            get 
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Имя должно быть!");
                }
                name = value;
            }
        }
        protected bool Gender { get { return gender; }}
        protected Guid Id { get { return id; }}

        protected DateTime BirthDate { get { return birthDate; }}

        protected abstract string Voice();

        public override string ToString()
        {
            string sex;
            if (Gender)
            {
                sex = "м";
            }
            else
            {
                sex = "ж";
            }
            return $"{this.Name}, {this.BirthDate}, {sex}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return this.Id.Equals((obj as Animal)!.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}