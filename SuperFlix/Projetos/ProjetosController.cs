using AutoMapper;
using ControleProjetos.Data.Dtos.ProjetoDto;
using ControleProjetos.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ControleProjetos.Projetos
{
    [ApiController]
    [Route("[Controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetosController(IProjetoRepository projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ICollection<ReadProjetoDto>> GetProjetos()
        {
            var listaDeProjetos = await _projetoRepository.GetAllAsync();
            var listaDeProjetosMapeadosParaReadProjetosDtos = _mapper.Map<ICollection<ReadProjetoDto>>(listaDeProjetos);
            return listaDeProjetosMapeadosParaReadProjetosDtos;
        }

        // GET: api/Filmes/5
        [HttpGet("{id}")]
        public async Task<IResult> GetFilme(int id)
        {
            var projeto = await _projetoRepository.GetAsync(id);

            if (projeto == null)
            {
                return Results.NotFound();
            }
            var projetoMapeado = _mapper.Map<ReadProjetoDto>(projeto);
            return Results.Ok(projetoMapeado);
        }

        [HttpGet("projeto/detalhe/{id}")]
        public async Task<IResult> GetDetalhesDoProjeto(int id)
        {
            var projeto = await _projetoRepository.GetProjetoDetailsAsync(id);
            if (projeto == null)
            {
                return Results.NotFound();
            }
            var projetoMapeado = _mapper.Map<ReadProjetoDto>(projeto);
            return Results.Ok(projetoMapeado);

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

        
        [HttpPost]
        public async Task<IResult> PostFilme([FromBody] CreateProjetoDto createProjetoDto)
        {
            var projetoDtoMapeadoParaProjeto = _mapper.Map<Projeto>(createProjetoDto);
            await _projetoRepository.AddAsync(projetoDtoMapeadoParaProjeto);
            return Results.Created($"/{projetoDtoMapeadoParaProjeto.Id}", projetoDtoMapeadoParaProjeto);
        }

        // DELETE: /Filmes/5
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteFilme(int id)
        {
            var projeto = await _projetoRepository.GetAsync(id);
            if (projeto == null)
            {
                return Results.NotFound();
            }
            await _projetoRepository.DeleteAsync(projeto.Id);
            return Results.NoContent();
        }

        private async Task<bool> FilmeExists(int id)
        {
            return await _projetoRepository.Exists(id);
        }
    }
}
