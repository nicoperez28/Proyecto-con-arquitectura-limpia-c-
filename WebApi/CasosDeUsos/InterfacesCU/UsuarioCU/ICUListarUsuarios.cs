using CasosDeUsos.DTOs.UsuarioDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasosDeUsos.InterfacesCU.UsuarioCU
{
    public interface ICUListarUsuarios
    {
        IEnumerable<UsuarioListadoDto> Ejecutar(); 
    }
}
