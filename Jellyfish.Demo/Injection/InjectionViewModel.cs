using System.Windows.Input;

namespace Jellyfish.Demo.Injection
{
    public class InjectionViewModel : ViewModel
    {
        private IUser _user;

        public IUser User
        {
            get => _user;
            set
            {
                Set(ref _user, value);
                Notify(nameof(MemoryAddress));
            }
        }

        public string MemoryAddress => User?.ToString() ?? "{null}";

        public InjectionModel Model { get; } = new InjectionModel();

        public ICommand TemplateCommand => new RelayCommand(TemplateAction);
        public ICommand DefineCommand => new RelayCommand(DefineAction);
        public ICommand BindCommand => new RelayCommand(BindAction);
        public ICommand ResetCommand => new RelayCommand(ResetAction);

        private void ResetAction(object o)
        {
            User = null;
        }
        private void TemplateAction(object o)
        {
            User = Model.TemplateUser();
        }
        private void DefineAction(object o)
        {
            User = Model.DefineUser();
        }
        private void BindAction(object o)
        {
            User = Model.BindUser();
        }
    }
}
