using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PersonaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet]
    [HttpGet]
    [MapToApiVersion("1.0")]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Persona>>> Get()
    {
        var persona = await this._unitOfWork.Personas.GetAllAsync();
        return _mapper.Map<List<Persona>>(persona);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<Persona>> Get(string id)
    {
        var persona = await this._unitOfWork.Personas.GetByIdAsync(id);
        if(persona == null){
            return NotFound();
        }
        return this._mapper.Map<Persona>(persona);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pais>> Post(Persona personaDto)
    {
        var persona = _mapper.Map<Persona>(personaDto);
        this._unitOfWork.Personas.Add(persona);
        await _unitOfWork.SaveAsync();
        if(persona == null)
        {
            return BadRequest();
        }
        personaDto.Id = persona.Id;
        return CreatedAtAction(nameof(Post), new {id= persona.Id}, persona);
    }
}
