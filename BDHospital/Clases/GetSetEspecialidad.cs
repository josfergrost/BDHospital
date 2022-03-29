namespace BDHospital.Clases
{
    public class GetSetEspecialidad
    {public GetSetEspecialidad(int id, string nom, string desc)
        {
            this.idespecialidad = id;
            this.nombre = nom;
            this.descripcion = desc;
        }
        public GetSetEspecialidad() { }
        public int idespecialidad { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }


    }
}
