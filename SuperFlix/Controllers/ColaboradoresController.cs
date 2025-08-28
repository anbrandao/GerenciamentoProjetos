using AutoMapper;
using ControleProjetos.Data.Dtos.ColaboradorDto;
using ControleProjetos.Data.Dtos.FilmeDto;
using ControleProjetos.Models;
using ControleProjetos.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ControleColaboradores.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMapper _mapper;

        public ColaboradoresController(IColaboradorRepository colaboradorRepository, IMapper mapper)
        {
            _colaboradorRepository = colaboradorRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ICollection<ReadColaboradorDto>> GetColaboradores()
        {
            var listaDeColaboradores = await _colaboradorRepository.GetAllAsync();
            var listaDecolaboradorsMapeadosParaReadColaboradorsDtos = _mapper.Map<ICollection<ReadColaboradorDto>>(listaDeColaboradores);
            return listaDecolaboradorsMapeadosParaReadColaboradorsDtos;
        }

        // GET: api/Filmes/5
        [HttpGet("{id}")]
        public async Task<IResult> GetColaborador(int id)
        {
            var colaborador = await _colaboradorRepository.GetAsync(id);

            if (colaborador == null)
            {
                return Results.NotFound();
            }
            var colaboradorMapeado = _mapper.Map<ReadColaboradorDto>(colaborador);
            return Results.Ok(colaboradorMapeado);
        }

        [HttpGet("colaborador/detalhe/{id}")]
        public async Task<IResult> GetDetalhesDoProjeto(int id)
        {
            var colaborador = await _colaboradorRepository.GetColaboradorDetailsAsync(id);
            if (colaborador == null)
            {
                return Results.NotFound();
            }
            var colaboradorMapeado = _mapper.Map<ReadColaboradorDto>(colaborador);
            return Results.Ok(colaboradorMapeado);

        }

        // PUT: api/Filmes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFilme(Guid id, Filme filme)
        //{
        //    if (id != filme.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(filme).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FilmeExists(id))
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

        [HttpGet("colaborador/projetos/{id}")]
        public async Task<IResult> GetProjetosDosColaborador(int id)
        {
            var projetosDoColaborador = await _colaboradorRepository.GetNomesProjetosDoColaboradorAsync(id);
            if (projetosDoColaborador == null)
            {
                return Results.NotFound();
            }
            var listaDeReadProjetosDtos = _mapper.Map<List<ReadProjetoDto>>(projetosDoColaborador);
            return Results.Ok(listaDeReadProjetosDtos);

        }


        [HttpPost]
        public async Task<IResult> PostFilme([FromBody] CreateColaboradorDto createColaboradorDto)
        {
            var colaboradorDtoMapeadoParaColaborador = _mapper.Map<Colaborador>(createColaboradorDto);
            await _colaboradorRepository.AddAsync(colaboradorDtoMapeadoParaColaborador);
            return Results.Created($"/{colaboradorDtoMapeadoParaColaborador.Id}", colaboradorDtoMapeadoParaColaborador);
        }

        // DELETE: /Filmes/5
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteFilme(int id)
        {
            var colaborador = await _colaboradorRepository.GetAsync(id);
            if (colaborador == null)
            {
                return Results.NotFound();
            }
            await _colaboradorRepository.DeleteAsync(colaborador.Id);
            return Results.NoContent();
        }

        private async Task<bool> FilmeExists(int id)
        {
            return await _colaboradorRepository.Exists(id);
        }
    }

}

