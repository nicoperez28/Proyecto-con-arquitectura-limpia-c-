using CasosDeUsos.DTOs.EquipoDTO;
using CasosDeUsos.DTOs.TipoDeGastoDTO;
using LogicaDeNegocio.EntidadesDeNegocio;

namespace LogicaDeAplicacion.Mappers
{
    public class EquipoMapper
    {
        public static IEnumerable<EquipoListadoDto>
            EquipoListadoToEquipoListadoDto(IEnumerable<Equipo> equipos)
        {
            List<EquipoListadoDto> equipoListado = new List<EquipoListadoDto>();
            foreach (Equipo equipo in equipos)
            {
                equipoListado.Add(new EquipoListadoDto()
                {
                    Id=equipo.Id,
                    Nombre = equipo.Nombre,
                });
            }
            return equipoListado;

        }
    }
}
