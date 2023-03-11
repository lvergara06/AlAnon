﻿using AlAnonFront.Models.Dtos;
using AlAnonFront.Service.IService;
using Newtonsoft.Json;
using System.Net.Http;

namespace AlAnonFront.Service
{
    public class InvitacionService : IInvitacionService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private string AlAnonBaseServerUrl;

        public InvitacionService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            AlAnonBaseServerUrl = configuration.GetValue<string>("AlAnonBaseServerUrl");
        }

        public async Task<RespuestaDto<InvitacionDto>> ObtenerInvitacion(int idDeInvitacion)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitaciones()
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesActuales(string offset)
        {
            var response = await _httpClient.GetAsync("/api/Invitacion/ObtenerActuales" + (int.Parse(offset) * -1).ToString() );
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaDto<List<InvitacionDto>>>(content);

                return respuesta;
            }
            var respuestaError = new RespuestaDto<List<InvitacionDto>>();
            respuestaError.Error = "($Error en InvitacionService: Could not get api/Invitacion/ObtenerActuales/{offset})";
            respuestaError.Exito = false;
            return respuestaError;
        }

        public async Task<RespuestaDto<List<InvitacionDto>>> ObtenerInvitacionesDelMes(DateTime firstDayOfMonth)
        {
            throw new NotImplementedException();
        }
    }
}
