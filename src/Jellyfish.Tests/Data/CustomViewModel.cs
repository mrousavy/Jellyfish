namespace Jellyfish.Tests.Data
{
    public class CustomViewModel : ViewModel
    {
        private IUser _user;
        public IUser User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public CustomViewModel(string firstName, string lastName)
        {
            User = new User(firstName, lastName);
        }

        public CustomViewModel(IUser user)
        {
            User = user;
        }
    }
}
