namespace Jellyfish.Forms
{
    /// <summary>
    ///     Any user input form's input field
    /// </summary>
    public interface IFormInput<T>
    {
        /// <summary>
        ///     The text or question to display next to the input field
        /// </summary>
        string Text { get; set; }
    }
}
