namespace ICA.ViewModel
{
    public class EditDriverViewModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public IFormFile? Photo1File { get; set; }
        public string? Photo1 { get; set; }
        public double DigitSurce { get; set; }
        public IFormFile? Photo2File { get; set; }
        public string? Photo2 { get; set; }
        public double DigitDes { get; set; }
        public string? Source { get; set; }
        public string? Des { get; set; }
        public DateTime TIME { get; set; }
        public bool? Check { get; set; }

    }
}
