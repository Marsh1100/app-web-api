

using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace API.Controllers;

public class CiudadController: BaseApiController
{
     private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CiudadController(IUnitOfWork unitOfWork, IMapper mapper)
    {
       this._unitOfWork = unitOfWork;
       this._mapper = mapper;
    }  

     [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CiudadDto>>> Get()
        {
            var ciudad = await this._unitOfWork.Ciudades.GetAllAsync();
            return _mapper.Map<List<CiudadDto>>(ciudad);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadDto>> Get(string id)
        {
            var ciudad = await this._unitOfWork.Ciudades.GetByIdAsync(id);
            if(ciudad == null){
                return NotFound();
            }
            return this._mapper.Map<CiudadDto>(ciudad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ciudad>> Post(CiudadDto ciuDto)
        {
            var ciudad = this._mapper.Map<Ciudad>(ciuDto);
            this._unitOfWork.Ciudades.Add(ciudad);
            await this._unitOfWork.SaveAsync();
            if(ciudad == null){
                return BadRequest();
            }
            ciuDto.Id = ciudad.Id;
            return CreatedAtAction(nameof(Post), new { id = ciuDto.Id }, ciuDto);
        }

         [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CiudadDto>> Put(string id, [FromBody]CiudadDto ciuDto)
        {
            if(ciuDto == null){
                return NotFound();
            }
            var ciudad = this._mapper.Map<Ciudad>(ciuDto);
            this._unitOfWork.Ciudades.Update(ciudad);
            await this._unitOfWork.SaveAsync();
            return ciuDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var ciudad = await this._unitOfWork.Ciudades.GetByIdAsync(id);
            if(ciudad == null){
                return NotFound();
            }
            this._unitOfWork.Ciudades.Remove(ciudad);
            await this._unitOfWork.SaveAsync();
            return NoContent();
        }


}
