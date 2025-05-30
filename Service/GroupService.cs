using AlAnonFront.Models.Dtos;
using AlAnonFront.Service.IService;
using Newtonsoft.Json;

namespace AlAnonFront.Service
{
	public class GroupService : IGroupService
	{
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string AlAnonBaseServerUrl;

        public GroupService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            AlAnonBaseServerUrl = configuration.GetValue<string>("AlAnonBaseServerUrl");
        }

        public Task<RespuestaDto<GroupDto>> Crear(GroupDto GroupDto)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<List<GroupDto>>> Obtener()
        {
            var response = await _httpClient.GetAsync("/api/Group/Obtener");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaDto<List<GroupDto>>>(content);

                return respuesta;
            }
            var respuestaError = new RespuestaDto<List<GroupDto>>();
            respuestaError.Error = "Error en GroupService: Could not get api/Group/Obtener";
            respuestaError.Exito = false;
            return respuestaError;
        }
    }
}
