namespace LogicaDeNegocio.EntidadesDeNegocio
{
    public class Auditoria
    {
        public int Id { get; set; }
        public TipoDeGasto TipoDeGasto { get; set; }
        public string Mail { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }

        public Auditoria()
        {
        }

        public Auditoria(string mail, string accion)
        {
            Mail = mail;
            Accion = accion;
            Fecha = DateTime.Now;
        }
    }
}
