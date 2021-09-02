namespace Hang.ViewModels.Interface
{
    public interface IIndexViewModel
    {
        string ErrorMessage { get; set; }
        int HangSeconds { get; set; }
        int RestSeconds { get; set; }
        int Reps { get; set; }
        bool Hanging { get; set; }
        bool IsValid();
    }
}
