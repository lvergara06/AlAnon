using AlAnon.Data;
using AlAnon.Models;
using AlAnon.Models.Dtos;
using AlAnon.Repository.IRepository;
using AutoMapper;

namespace AlAnon.Repository
{
    public class InicioRepository : IInicioRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public InicioRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<RespuestaDto<InicioDto>> CrearEditarInicio(InicioDto nuevoInicioDto)
        {
            // Check if there is a valid info record
            var inicioDeDb = _db.Inicio.FirstOrDefault(u => u.EsValida == true);
            var nuevoInicio = _mapper.Map<InicioDto, Inicio>(nuevoInicioDto);
            var respuesta = new RespuestaDto<InicioDto>();

            if (inicioDeDb != null)
            {
                // Update to invalid
                inicioDeDb.DiaCerrada = DateTime.Now;
                inicioDeDb.EsValida = false;
                _db.Inicio.Update(inicioDeDb);
            }

            // Create
            nuevoInicio.EsValida = true;
            nuevoInicio.DiaInsertada = DateTime.Now;
            nuevoInicio.Titulo = nuevoInicioDto.Titulo;
            nuevoInicio.ParrafoPrincipal = nuevoInicioDto.ParrafoPrincipal;
            nuevoInicio.ImagenDeInicio = nuevoInicioDto.ImagenDeInicio;

            _db.Inicio.Add(nuevoInicio);
            respuesta.Data = _mapper.Map<Inicio, InicioDto>(nuevoInicio);

            await _db.SaveChangesAsync();

            return respuesta;
        }

        public async Task<RespuestaDto<InicioDto>> ObtenerInicio()
        {
            var inicioDeDbDto = _mapper.Map<Inicio, InicioDto>(_db.Inicio.FirstOrDefault(u => u.EsValida == true));
            if (inicioDeDbDto != null)
            {
                return new RespuestaDto<InicioDto>()
                {
                    Data = inicioDeDbDto
                };
            }
            else
            {
                return new RespuestaDto<InicioDto>()
                {
                    Exito = false,
                    Data = new InicioDto(),
                };
            }
        }
    }
}
