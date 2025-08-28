using AutoMapper;
using ControleProjetos.Data.Dtos.ColaboradoresProjetosDto;
using ControleProjetos.Models;
using ControleProjetos.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ControleProjetos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColaboradoresProjetosController : ControllerBase
    {
        private readonly IColaboradoresProjetosRepository _colaboradoresProjetosRepository;
        private readonly IMapper _mapper;

        public ColaboradoresProjetosController(IColaboradoresProjetosRepository repository, IMapper mapper)
        {
            _colaboradoresProjetosRepository = repository;
            _mapper = mapper;
        }

        // GET: api/ColaboradoresProjetos
        [HttpGet]
        public async Task<ICollection<ReadColaboradoresProjetosDto>> GetColaboradoresProjetos()
        {
            var colaboradores = await _colaboradoresProjetosRepository.GetAllAsync();
            var readcolaboradoresDtos = _mapper.Map<ICollection<ReadColaboradoresProjetosDto>>(colaboradores);
            return  readcolaboradoresDtos;
        }

        // GET: api/ColaboradoresProjetos/5
        [HttpGet("{colaboradorId}/{projetoId}")]
        public async Task<IResult> GetColaboradoresProjetos(int colaboradorId, int projetoId)
        {
            var colaboradoresProjetos = await _colaboradoresProjetosRepository.GetColaboradoresProjetosPorIdsAsync(colaboradorId, projetoId);

            if (colaboradoresProjetos == null)
            {
                return Results.NotFound();
            }
            var readColaboradoresProjetos = _mapper.Map<ReadColaboradoresProjetosDto>(colaboradoresProjetos);
            return Results.Ok(readColaboradoresProjetos);
        }

        // PUT: api/ColaboradoresProjetos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutColaboradoresProjetos(int id, ColaboradoresProjetos colaboradoresProjetos)
        //{
        //    if (id != colaboradoresProjetos.ColaboradorId)
        //    {
        //        return BadRequest();
        //    }

        //    _colaboradoresProjetosRepository.Entry(colaboradoresProjetos).State = EntityState.Modified;

        //    try
        //    {
        //        await _colaboradoresProjetosRepository.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ColaboradoresProjetosExists(id))
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

        // POST: api/ColaboradoresProjetos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IResult> PostColaboradoresProjetos([FromBody] CreateColaboradoresProjetosDto createColaboradoresProjetos)
        {
            var colacobradoresProjetos = _mapper.Map<ColaboradoresProjetos>(createColaboradoresProjetos);
            await _colaboradoresProjetosRepository.AddAsync(colacobradoresProjetos);
            
            return Results.Created($"/{colacobradoresProjetos.ColaboradorId}/{colacobradoresProjetos.ProjetoId}", colacobradoresProjetos);
        }

        // DELETE: api/ColaboradoresProjetos/5
        [HttpDelete("{colaboradorId}/{projetoId}")]
        public async Task<IResult> DeleteColaboradoresProjetos(int colaboradorId, int projetoId)
        {
            var colaboradoresProjetos = await _colaboradoresProjetosRepository.GetColaboradoresProjetosPorIdsAsync(colaboradorId, projetoId);
            if (colaboradoresProjetos == null)
            {
                return Results.NotFound();
            }

           await _colaboradoresProjetosRepository.DeleteEntityAsync(colaboradoresProjetos);
           return Results.NoContent();

        }

        //private bool ColaboradoresProjetosExists((int colaboradorId, int projetoId)
        //{
        //    return await _colaboradorRepository.Exists(colaboradorId, projetoId);
        //}
    }
}
