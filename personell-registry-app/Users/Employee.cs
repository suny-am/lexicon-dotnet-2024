namespace PersonellRegisterApp
{
    internal class Employee
    {
        protected string? firstName;
        protected string? lastName;
        protected int? wage;

        public string? FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string? LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int? Wage
        {
            get { return wage; }
            set { wage = value; }
        }

        public Employee(string firstName, string lastName, int? wage)
        {
            FirstName = firstName;
            LastName = lastName;
            Wage = wage is null ? 0 : wage;
        }

        public Employee() : this("na", "na", 0) { }
    }
}