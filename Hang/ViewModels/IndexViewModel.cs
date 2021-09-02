using Hang.ViewModels.Interface;

namespace Hang.ViewModels
{
    public class IndexViewModel : IIndexViewModel
    {
        public int HangSeconds { get; set; }
        public int RestSeconds { get; set; }
        public int Reps { get; set; }
        public bool Hanging { get; set; }
        public string ErrorMessage { get; set; }

        public bool IsValid()
        {
            return HangSeconds >= 1 && RestSeconds >= 1 && Reps >= 1;
        }
    }
}
