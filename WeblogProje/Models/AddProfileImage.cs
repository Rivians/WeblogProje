namespace WeblogProje.Models
{
	public class AddProfileImage
	{
		public int WriterID { get; set; }
		public string WriterName { get; set; }
		public string WriterAbout { get; set; }
		public IFormFile WriterImage { get; set; }  // IFormFile türü genelde webde dosya yükleme gibi durumlarda kullanılır. IFormFile nesnesi, dosyanın adı, içeriği (verileri), boyutu, uzantısı gibi dosya bilgilerini içerir.
		public string WriterEmail { get; set; }
		public string WriterPassword { get; set; }
		public bool WriterStatus { get; set; }
	}
}
