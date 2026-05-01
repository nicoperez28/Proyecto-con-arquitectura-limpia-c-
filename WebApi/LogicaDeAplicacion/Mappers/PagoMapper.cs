using CasosDeUsos.DTOs.EquipoDTO;
using CasosDeUsos.DTOs.PagoDto;
using LogicaDeNegocio.EntidadesDeNegocio;

namespace LogicaDeAplicacion.Mappers
{
    public class PagoMapper
    {
        public static Pago PagoDtoToPago(PagoDto pagoDto)
        {
            var metodo = Enum.Parse<MetodoDePago>(pagoDto.MetodoDePago, ignoreCase: true);
            if (pagoDto.TipoDePago == "Unico")
            {
                return new PagoUnico(metodo, pagoDto.Descripcion, pagoDto.Monto,
                                    pagoDto.TipoDeGastoId, pagoDto.UsuarioId);
            }
            else
            {
                return new Recurrente(metodo, pagoDto.Descripcion, pagoDto.Monto,
                                      pagoDto.TipoDeGastoId, pagoDto.UsuarioId, pagoDto.FechaHasta);
            }
        }
        public static IEnumerable<PagoListadoDto>
        PagoListadoToPagoListadoDto(IEnumerable<Pago> Pagos)
        {
            List<PagoListadoDto> pagoListado = new List<PagoListadoDto>();
            foreach (Pago pago in Pagos)
            {
                pagoListado.Add(new PagoListadoDto()
                {
                    Id = pago.Id,
                    MetodoDePago = pago.MetodoDePago.ToString(),
                    Monto = pago.Monto,
                    UsuarioId = pago.UsuarioId,
                    TipoDeGasto = pago.TipoDeGasto.Nombre,
                    SaldoAPagar = pago.CalcularMontoTotal(),
                });
            }
            return pagoListado;
        }

        public static IEnumerable<PagoFiltradoDto>
        PagoFiltradoToPagoFiltradoDto(IEnumerable<Pago> pagosUnicos, IEnumerable<Pago> pagosRecurrentes)
        {
            List<PagoFiltradoDto> pagoListado = new List<PagoFiltradoDto>();

            foreach (Pago pago in pagosUnicos)
            {
                pagoListado.Add(new PagoFiltradoDto()
                {
                    Id = pago.Id,
                    MetodoDePago = pago.MetodoDePago.ToString(),
                    Monto = pago.Monto,
                    UsuarioId = pago.UsuarioId,
                    TipoDeGasto = pago.TipoDeGasto.Nombre,
                    SaldoAPagar = pago.CalcularMontoTotal(),
                });
            }

            // Mapeo de pagos recurrentes
            foreach (Pago pago in pagosRecurrentes)
            {
                pagoListado.Add(new PagoFiltradoDto()
                {
                    Id = pago.Id,
                    MetodoDePago = pago.MetodoDePago.ToString(),
                    Monto = pago.Monto,
                    UsuarioId = pago.UsuarioId,
                    TipoDeGasto = pago.TipoDeGasto.Nombre,
                    SaldoAPagar = pago.CalcularMontoTotal(),
                });
            }

            return pagoListado;
        }
        public static IEnumerable<PagoFiltradoMontoDto>
        PagoFiltradoMontoToPagoFiltradoMontoDto(IEnumerable<Pago> pagosUnicos)
        {
            List<PagoFiltradoMontoDto> pagoListado = new List<PagoFiltradoMontoDto>();

            foreach (Pago pago in pagosUnicos)
            {
                pagoListado.Add(new PagoFiltradoMontoDto()
                {
                    Id = pago.Id,
                    Monto = pago.Monto,
                    UsuarioId = pago.UsuarioId,
                    NombreUsuario = pago.Usuario.Nombre,
                    ApellidoUsuario = pago.Usuario.Apellido
                });
            }
            return pagoListado;
        }

        public static PagoDetalleDto PagoToPagoDetalleDto(Pago pago)
        {
            if (pago == null)
            {
                throw new ArgumentNullException("Error en los datos");
            }
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;
            string tipoDePago = "";
            if (pago is Recurrente recurrente)
            {
                fechaDesde = recurrente.FechaDesde;
                fechaHasta = recurrente.FechaHasta;
                tipoDePago = "Recurrente";
            }
            else if (pago is PagoUnico unico)
            {
                fechaDesde = unico.FechaDePago; // lo guardamos en FechaDesde
                tipoDePago = "Pago Unico";
            }
            
            return new PagoDetalleDto()
            {
                Id = pago.Id,
                TipoDePago = tipoDePago,
                MetodoDePago = pago.MetodoDePago.ToString(),
                Descripcion = pago.Descripcion,
                Monto = pago.Monto,
                TipoDeGasto = pago.TipoDeGasto.Nombre,
                UsuarioNombre = pago.Usuario.Nombre,
                UsuarioApellido = pago.Usuario.Apellido,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta,
            };
        }

        public static IEnumerable<EquipoListadoDto>
        PagoFiltradoMontoToPagoListadoEquipoDto(IEnumerable<Equipo> equipos)
        {
            List<EquipoListadoDto> equipoListado = new List<EquipoListadoDto>();

            foreach (Equipo equipo in equipos)
            {
                equipoListado.Add(new EquipoListadoDto()
                {
                    Id = equipo.Id,
                    Nombre = equipo.Nombre,
                });
            }
            return equipoListado;
        }
    }
}

