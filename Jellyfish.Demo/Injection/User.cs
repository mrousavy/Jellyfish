namespace Jellyfish.Demo.Injection
{
    public class User : ObservableObject, IUser
    {
        private string _firstName = "John";

        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        private string _lastName = "Smith";

        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }
    }
}
