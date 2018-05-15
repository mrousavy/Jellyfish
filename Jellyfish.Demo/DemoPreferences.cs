namespace Jellyfish.Demo
{
    public class DemoPreferences : Preferences
    {
        public DemoPreferences(string path) : base(path)
        {
        }


        public int SomeInt { get; set; } = 400;
        public string SomeString { get; set; } = "test string";
        public bool SomeBool { get; set; } = false;

        public object SomeObject { get; set; } = new
        {
            Name = "Marc",
            IsValid = true
        };
    }
}
