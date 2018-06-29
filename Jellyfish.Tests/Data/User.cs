namespace Jellyfish.Tests.Data
{
    public class User : ObservableObject
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
    }
}
