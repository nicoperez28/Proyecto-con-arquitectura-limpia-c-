using CasosDeUsos.DTOs.UsuarioDTO;
using CasosDeUsos.InterfacesCU.UsuarioCU;
using ExcepcionesPropias.ExcepcionesEntidades;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.EntidadesDeNegocio;
using LogicaDeNegocio.InterfacesDeRepositorio;
using LogicaDeNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.CUUsuario
{
    public class CUModificarContrasenia : ICUModificarContrasenia
    {
        public IRepositorioUsuario RepoUsuario { get; set; }

        public CUModificarContrasenia(IRepositorioUsuario repositorioUsuario)
        {
            RepoUsuario = repositorioUsuario;
        }

        public void Ejecutar(int id, ContraseniaDto contraseniaDto)
        {
            Usuario usuario=RepoUsuario.GetById(id);
            if (usuario == null)
            {
                throw new UsuarioException("Usuario no encontrado");
            }
            usuario.Contrasenia = new Contrasenia(contraseniaDto.Contrasenia);
            RepoUsuario.ModificarContrasenia(id, usuario);
        }
    }
}
