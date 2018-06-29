using System.Diagnostics;

namespace Jellyfish.Tests.Data
{
    public class User : ObservableObject, IUser
    {
        public User()
        {
            Debug.WriteLine("ctor: User()");
        }
        public User(string firstName, string lastName)
        {
            Debug.WriteLine("ctor: User(string, string)");
            FirstName = firstName;
            LastName = lastName;
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => Set(ref _firstName, value);
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => Set(ref _lastName, value);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IUser user))
                return false;
            return FirstName == user.FirstName && LastName == user.LastName;
        }

        protected bool Equals(IUser other) => FirstName == other.FirstName && LastName == other.LastName;

        public override int GetHashCode()
        {
            return ((FirstName != null ? FirstName.GetHashCode() : 0) * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
        }
    }
}
