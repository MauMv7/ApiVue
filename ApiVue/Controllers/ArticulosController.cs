using ApiVue.Entities;
using Microsoft.AspNetCore.Mvc;
namespace ApiVue.Controllers
{
    [ApiController]
    [Route("articulos")]
    public class ArticulosController : ControllerBase
    {

        private readonly ILogger<ArticulosController> _logger;
        private readonly DataContext _context;

        public ArticulosController(ILogger<ArticulosController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Articulo> Get()
        {
            return _context.Articulos;

        }

        [HttpGet("{id}")]
        public Articulo Get(int id)
        {
            return _context.Articulos.FirstOrDefault(s => s.id == id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Articulo articulo)
        {
            var articuloo = await _context.Articulos.FindAsync(id);

            if (articuloo != null)
            {
                articuloo.name = articulo.name;
                articuloo.proveedor = articulo.proveedor;
                articuloo.precio = articulo.precio;

                await _context.SaveChangesAsync();

                return Ok(articuloo);
            };

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Articulo articulo)
        {
            var res = new Articulo
            {
                name = articulo.name,
                proveedor = articulo.proveedor,
                precio = articulo.precio
            };

            _context.Add(res);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("borrar/{id}")]
        public IActionResult Delete(int id)
        {
            var articulo = _context.Articulos.FirstOrDefault(s => s.id == id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
                _context.SaveChanges();
            }
            return Ok();
        }
        // [HttpGet]
        // [Route("listar")]
        // public async Task<IActionResult> Get()
        // {
        //     var articulos = new List<Articulo>
        //     {
        //         new Articulo { id = 1, name = "Hola", proveedor = "juan", precio = "12"}
        //     };

        //     return Ok(articulos);
        // }

    }
}