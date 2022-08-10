namespace AlAnon.Models.Dtos
{
	public class InicioDto
	{
		public string ImagenDeInicio { get; set; } = string.Empty;
		public string Titulo { get; set; } = string.Empty;
		public string ParrafoPrincipal { get; set; } = string.Empty;
		public bool EsValida { get; set; }
		public DateTime DiaInsertada { get; set; }
		public DateTime DiaCerrada { get; set; }
		public string UsuarioId { get; set; } = string.Empty;
	}
}
