namespace Jellyfish.Demo.Injection
{
    public class User : ObservableObject, IUser
    {
        private string _firstName = "John";

        private string _lastName = "Smith";

        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }

        public User() { }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}