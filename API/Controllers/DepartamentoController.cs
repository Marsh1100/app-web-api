

using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class DepartamentoController: BaseApiController
{
     private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
       this._unitOfWork = unitOfWork;
       this._mapper = mapper;
    }  

        [HttpGet]
        [MapToApiVersion("1.0")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
        {
            var Dep = await this._unitOfWork.Departamentos.GetAllAsync();
            return _mapper.Map<List<DepartamentoDto>>(Dep);
        }
    
        [HttpGet]
        [MapToApiVersion("1.1")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DepxCiudadesDto>>> Get1()
        {
            var Dep = await this._unitOfWork.Departamentos.GetAllAsync();
            return _mapper.Map<List<DepxCiudadesDto>>(Dep);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoDto>> Get(string id)
        {
            var dep = await this._unitOfWork.Departamentos.GetByIdAsync(id);
            if(dep == null){
                return NotFound();
            }
            return this._mapper.Map<DepartamentoDto>(dep);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Departamento>> Post(DepartamentoDto depDto)
        {
            var dep = this._mapper.Map<Departamento>(depDto);
            this._unitOfWork.Departamentos.Add(dep);
            await this._unitOfWork.SaveAsync();
            if(dep == null){
                return BadRequest();
            }
            depDto.Id = dep.Id;
            return CreatedAtAction(nameof(Post), new { id = depDto.Id }, depDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartamentoDto>> Put(string id, [FromBody]DepartamentoDto depDto)
        {
            if(depDto == null){
                return NotFound();
            }
            var dep = this._mapper.Map<Departamento>(depDto);
            this._unitOfWork.Departamentos.Update(dep);
            await this._unitOfWork.SaveAsync();
            return depDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var dep = await this._unitOfWork.Departamentos.GetByIdAsync(id);
            if(dep == null){
                return NotFound();
            }
            this._unitOfWork.Departamentos.Remove(dep);
            await this._unitOfWork.SaveAsync();
            return NoContent();
        }


}
