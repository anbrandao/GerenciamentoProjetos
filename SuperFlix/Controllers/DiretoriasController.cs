using AutoMapper;
using ControleProjetos.Data.Dtos.ColaboradorDto;
using ControleProjetos.Data.Dtos.DiretoriaDto;
using ControleProjetos.Models;
using ControleProjetos.Repositories.Contracts;
using ControleProjetos.Repositories.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleProjetos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiretoriasController : ControllerBase
    {
    
        private readonly IDiretoriaRepository _diretoriaRepository;
        private readonly IMapper _mapper;

        public DiretoriasController(IDiretoriaRepository diretoriaRepository, IMapper mapper)
        {
            _diretoriaRepository = diretoriaRepository;
            _mapper = mapper;
        }
       

        // GET: api/Diretorias
        [HttpGet]
        public async Task<ICollection<ReadDiretoriaDto>> GetDiretorias()
        {
            var diretorias = await _diretoriaRepository.GetAllAsync();
            var diretoriasMapeadasParaDiretoriasDtos = _mapper.Map<ICollection<ReadDiretoriaDto>>(diretorias);
            return diretoriasMapeadasParaDiretoriasDtos;
        }

        // GET: api/Diretorias/5
        [HttpGet("{id}")]
        public async Task<IResult> GetDiretoria(int id)
        {
            var diretoria = await _diretoriaRepository.GetAsync(id);

            if (diretoria == null)
            {
                return Results.NotFound();
            }
            var readDiretoriaDto = _mapper.Map<ReadDiretoriaDto>(diretoria);
            return Results.Ok(readDiretoriaDto);
        }

        // PUT: api/Diretorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDiretoria(int id, Diretoria diretoria)
        //{
        //    if (id != diretoria.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(diretoria).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DiretoriaExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Diretorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IResult> PostDiretoria([FromBody] CreateDiretoriaDto createDiretoriaDto)
        {
            var diretoria = _mapper.Map<Diretoria>(createDiretoriaDto);
           await _diretoriaRepository.AddAsync(diretoria);

            return Results.Created($"/{diretoria.Id}", diretoria);
        }

        // DELETE: api/Diretorias/5
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteDiretoria(int id)
        {
            var diretoria = await _diretoriaRepository.GetAsync(id);
            if (diretoria == null)
            {
                return Results.NotFound();
            }

            await _diretoriaRepository.DeleteAsync(diretoria.Id);
            return Results.NoContent();
        }

        private async Task<bool> DiretoriaExists(int id)
        {
            return await _diretoriaRepository.Exists(id);
        }

        [HttpGet("diretoria/detalhes/{id}")]
        public async Task<IResult> GetDetalhesDaDiretoria(int id)
        {

            var diretoria = await _diretoriaRepository.GetDiretoriaDetailsAsync(id);
            if (diretoria == null)
            {
                return Results.NotFound();
            }
            var readDiretoriaDto = _mapper.Map<ReadDiretoriaDto>(diretoria);
            return Results.Ok( readDiretoriaDto);
        }

        [HttpGet("diretoria/colaboradoresDaDiretoria/{id}")]
        public async Task<IResult> GetColaboradoresDaDiretoria(int id)
        {

            var colaboradores = await _diretoriaRepository.GetColaboradoresDaDiretoriaAsync(id);
            if (colaboradores == null)
            {
                return Results.NotFound();
            }
            var readColaboradoresDto = _mapper.Map<List<ReadColaboradorDto>>(colaboradores);
            return Results.Ok(readColaboradoresDto);
        }

    }
}
