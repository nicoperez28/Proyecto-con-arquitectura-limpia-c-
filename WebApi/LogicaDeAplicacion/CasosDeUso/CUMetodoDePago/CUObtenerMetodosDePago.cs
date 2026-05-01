using CasosDeUsos.InterfacesCU.MetodoDePagoCU;
using LogicaDeNegocio.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.CUMetodoDePago
{
    public class CUObtenerMetodosDePago : ICUObtenerEnum
    {
        public string[] Ejecutar()
        {
            return Enum.GetNames(typeof(MetodoDePago));
        }

    }
}
