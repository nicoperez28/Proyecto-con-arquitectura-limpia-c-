

namespace LogicaDeNegocio.EntidadesDeNegocio
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Usuario> usuarios { get; private set; }
    }
}
