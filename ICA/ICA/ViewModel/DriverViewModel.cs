using System.ComponentModel.DataAnnotations;

namespace ICA.ViewModel

{
    public class DriverViewModel
    {


        
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required(ErrorMessage = " قم بتحميل صورة العداد عند الإنطلاق ")]
        public IFormFile? Photo1File { get; set; }
        public string? Photo1 { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "يجب أن يكون الرقم أكبر من صفر")]
        [Required(ErrorMessage = "  قم بتعبئة رقم العداد لحظة الإنطلاق")]
        public double DigitSurce { get; set; }

        [Required(ErrorMessage = "قم بتحميل صورة العداد عند الوصول")]
        public IFormFile? Photo2File { get; set; }
        public string? Photo2 { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "يجب أن يكون الرقم أكبر من صفر")]
        [Required(ErrorMessage = "  قم بتعبئة رقم العداد لحظة الوصول")]
        
        public double DigitDes { get; set; }


        [Required(ErrorMessage = "  أدخل مكان الإنطلاق")]
         public string? Source { get; set; }
        [Required(ErrorMessage = "  أدخل الوجهة")]
        public string? Des { get; set; }
        [Required(ErrorMessage = "  قم بتحديد تاريخ المهمة")]
        public DateTime TIME { get; set; }
        public bool? Check { get; set; }




    }
}
