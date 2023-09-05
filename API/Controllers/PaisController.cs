

using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class PaisController: BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
       this._unitOfWork = unitOfWork;
       this._mapper = mapper;
    } 

    //Get
    /*[HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Pais>>> Get()
    {
        var departamentos = await _unitOfWork.Paises.GetAllAsync();
        return Ok(departamentos);
    }*/

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
    {
        var paises = await _unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<PaisDto>>(paises);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<PaisxDepDto>>> Get11([FromQuery] Params paisParams)
    {
        var pais = await _unitOfWork.Paises.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var paisesDto =  _mapper.Map<List<PaisxDepDto>>(pais.registros);
        return new Pager<PaisxDepDto>(paisesDto, pais.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }

    /*[HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Get(string id)
    {
        var departamento = await _unitOfWork.Paises.GetByIdAsync(id);
        return Ok(departamento);
    }*/

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PaisDto>> Get(string id)
    {
        var pais = await this._unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        return this._mapper.Map<PaisDto>(pais);
    }

   /* [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pais>> Post(Pais pais)
    {
        this._unitOfWork.Paises.Add(pais);
        await _unitOfWork.SaveAsync();
        if(pais == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new {id= pais.Id}, pais);
    }*/
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pais>> Post(PaisDto paisDto)
    {
        var pais = _mapper.Map<Pais>(paisDto);
        this._unitOfWork.Paises.Add(pais);
        await _unitOfWork.SaveAsync();
        if(pais == null)
        {
            return BadRequest();
        }
        paisDto.Id = pais.Id;
        return CreatedAtAction(nameof(Post), new {id= pais.Id}, pais);
    }
    /*
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pais>> Put(string id, [FromBody]Pais pais)
    {
        if(pais == null)
        {
            return NotFound();
        }
        _unitOfWork.Paises.Update(pais);
        await _unitOfWork.SaveAsync();
        return pais;
    }*/
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Put(string id, [FromBody]PaisDto paisDto)
    {
        if(paisDto == null){
            return NotFound();
        }
        var pais = this._mapper.Map<Pais>(paisDto);
        this._unitOfWork.Paises.Update(pais);
        await this._unitOfWork.SaveAsync();
        return paisDto;
    }
    /*[HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> Delete(string id)
    {
        var pais = await _unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null)
        {
            return NotFound();
        }
        _unitOfWork.Paises.Remove(pais);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }*/
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(string id)
    {
        var pais = await this._unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        this._unitOfWork.Paises.Remove(pais);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }


}
