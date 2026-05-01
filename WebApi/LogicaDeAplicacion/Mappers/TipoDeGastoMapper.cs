

using CasosDeUsos.DTOs.TipoDeGastoDTO;
using LogicaDeNegocio.EntidadesDeNegocio;

namespace LogicaDeAplicacion.Mappers
{
    public class TipoDeGastoMapper
    {
        
        public static IEnumerable<TipoDeGastoListadoDto>
            TipoDeGastoListadoToTipoDeGastoListadoDto(IEnumerable<TipoDeGasto> TipoDeGastos)
        {
            List<TipoDeGastoListadoDto> tipoDeGastoListado = new List<TipoDeGastoListadoDto>();
            foreach (TipoDeGasto tipoDeGasto in TipoDeGastos)
            {
                tipoDeGastoListado.Add(new TipoDeGastoListadoDto()
                {
                    Id = tipoDeGasto.Id,
                    Nombre = tipoDeGasto.Nombre,
                    Descripcion = tipoDeGasto.Descripcion,
                });
            }
            return tipoDeGastoListado;

        }

        public static TipoDeGastoListadoDto TipoDeGastoToTipoDeGastoListadoDto(TipoDeGasto tipoDeGasto)
        {
            if (tipoDeGasto == null)
            {
                throw new ArgumentNullException("Error en los datos");
            }

            return new TipoDeGastoListadoDto()
            {
                Id = tipoDeGasto.Id,
                Nombre = tipoDeGasto.Nombre,
                Descripcion = tipoDeGasto.Descripcion,
            };
        }
    }
}
