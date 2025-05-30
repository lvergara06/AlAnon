using AlAnonFront.Models.Dtos;

namespace AlAnonFront.Service.IService
{
	public interface IGroupService
	{
		public Task<RespuestaDto<List<GroupDto>>> Obtener();
		public Task<RespuestaDto<GroupDto>> Crear(GroupDto GroupDto);
	}
}
