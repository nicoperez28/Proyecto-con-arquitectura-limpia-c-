
namespace LogicaDeNegocio.EntidadesDeNegocio
{
    public class Rol
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public Rol(string tipo)
        {
            Tipo = tipo;
        }
    }
}
