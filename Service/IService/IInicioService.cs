
using AlAnonFront.Models.Dtos;

namespace AlAnonFront.Service.IService
{
	public interface IInicioService
	{
		public Task<RespuestaDto<InicioDto>> Obterner();
		public Task<RespuestaDto<InicioDto>> Crear(InicioDto inicioDto);
	}
}
