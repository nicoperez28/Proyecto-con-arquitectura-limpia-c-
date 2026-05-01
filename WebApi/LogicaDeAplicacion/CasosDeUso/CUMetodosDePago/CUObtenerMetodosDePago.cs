using CasosDeUsos.InterfacesCU.MetodoDePagoCU;
using LogicaDeNegocio.EntidadesDeNegocio;

namespace LogicaDeAplicacion.CasosDeUso.CUMetodosDePago
{
    public class CUObtenerMetodosDePago : ICUObtenerEnum
    {
        public string[] Ejecutar()
        {
            return Enum.GetNames(typeof(MetodoDePago));
        }

    }
}
