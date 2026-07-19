namespace AlAnonFront.Models.Dtos
{
    public class BoletinDto
    {
        public int Id { get; set; }
        public string Pagina1 { get; set; }
        public string Pagina2 { get; set; }
        public DateTime DiaDeBoletin { get; set; }
        public bool EsValida { get; set; }
        public string? NombreDocumento { get; set; }
        public bool EsActual { get; set; }
        public DateTime? FechaSubida { get; set; }
        public string? BlobKey { get; set; }
        public string? PdfUrl { get; set; }
    }
}
