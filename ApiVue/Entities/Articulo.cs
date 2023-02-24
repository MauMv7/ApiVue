namespace ApiVue.Entities
{
    public class Articulo
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string proveedor { get; set; } = string.Empty;
        public string precio { get; set; } = string.Empty;
    }
}