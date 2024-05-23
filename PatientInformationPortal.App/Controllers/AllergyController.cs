using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortal.Application.Repositories.Entities;
using PatientInformationPortal.Application.ViewModels.VmEntities;
using PatientInformationPortal.SharedKernel.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientInformationPortal.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AllergyController : ControllerBase
{
    private readonly IAllergyRepository _allergyRepository;
    private readonly IMapper _mapper;

    public AllergyController(IAllergyRepository allergyRepository, IMapper mapper)
    {
        _allergyRepository = allergyRepository;
        _mapper = mapper;
    }

    // GET: api/<AllergyController>
    [HttpGet]
    public async Task<IEnumerable<AllergyVm>> Get()
    {
        var result = await _allergyRepository.GetAllAsync();
        return _mapper.Map<List<AllergyVm>>(result);
    }

    // GET api/<AllergyController>/5
    [HttpGet("{id}")]
    public async Task<AllergyVm> Get(long id)
    {
        var result = await _allergyRepository.FirstOrDefaultAsync(id);
        return _mapper.Map<AllergyVm>(result);
    }

    // POST api/<AllergyController>
    [HttpPost]
    public async Task<AllergyVm> Post([FromBody] AllergyVm value)
    {
        var entity = _mapper.Map<Allergy>(value);
        var result = await _allergyRepository.InsertAsync(entity);
        return _mapper.Map<AllergyVm>(result);
    }

    // PUT api/<AllergyController>/5
    [HttpPut("{id}")]
    public async Task<AllergyVm> Put(long id, [FromBody] AllergyVm value)
    {
        var entity = _mapper.Map<Allergy>(value);
        var result = await _allergyRepository.UpdateAsync(id, entity);
        return _mapper.Map<AllergyVm>(result);
    }

    // DELETE api/<AllergyController>/5
    [HttpDelete("{id}")]
    public async Task<AllergyVm> Delete(long id)
    {
        var result = await _allergyRepository.DeleteAsync(id);
        return _mapper.Map<AllergyVm>(result);
    }
}
