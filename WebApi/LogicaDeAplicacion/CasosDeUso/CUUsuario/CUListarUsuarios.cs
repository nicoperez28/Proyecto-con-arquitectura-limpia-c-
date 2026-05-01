using CasosDeUsos.DTOs.UsuarioDTO;
using CasosDeUsos.InterfacesCU.UsuarioCU;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.CUUsuario
{
    public class CUListarUsuarios : ICUListarUsuarios
    {
        public IRepositorioUsuario RepoUsuario { get; set; }
        public CUListarUsuarios (IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }
        public IEnumerable<UsuarioListadoDto> Ejecutar()
        {
            IEnumerable<Usuario> usuarios = RepoUsuario.GetAll();
            return UsuarioMapper.UsuarioListadoToUsuarioListadoDto(usuarios);

        }
    }
}
