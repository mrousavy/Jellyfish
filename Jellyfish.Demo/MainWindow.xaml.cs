using System;
using System.Threading;

namespace Jellyfish.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            var timer = new Timer(TimerCallback);
        }

        private void TimerCallback(object state)
        {
            int random = _random.Next(1);
            TestProperty = random == 0 ? "zero" : "one";
        }

        [Property]
        public string TestProperty { get; set; }
    }
}
