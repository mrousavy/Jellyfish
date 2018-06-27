namespace Jellyfish.Demo.Main
{
    public class MainViewModel : ViewModel
    {
        private OperatingSystem _selectedOperatingSystem;

        public OperatingSystem SelectedOperatingSystem
        {
            get => _selectedOperatingSystem;
            set => Set(ref _selectedOperatingSystem, value);
        }
    }
}