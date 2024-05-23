using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortal.Application.Repositories.Entities;
using PatientInformationPortal.Application.ViewModels.VmEntities;
using PatientInformationPortal.SharedKernel.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientInformationPortal.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientController(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    // GET: api/<PatientController>
    [HttpGet]
    public async Task<IEnumerable<PatientVm>> Get()
    {
        var list = await _patientRepository.GetAllAsync(x => x.Disease, x => x.NCDDetails, x => x.AllergiesDetails);
        return _mapper.Map<List<PatientVm>>(list);
    }

    // GET api/<PatientController>/5
    [HttpGet("{id}")]
    public async Task<PatientVm> Get(long id)
    {
        var patient = await _patientRepository.FirstOrDefaultAsync(id, x => x.Disease, x => x.NCDDetails, x => x.AllergiesDetails);
        return _mapper.Map<PatientVm>(patient);
    }

    // POST api/<PatientController>
    [HttpPost]
    public async Task<PatientVm> Post([FromBody] PatientVm value)
    {
        var entity = _mapper.Map<Patient>(value);
        var result = await _patientRepository.InsertAsync(entity);
        return _mapper.Map<PatientVm>(result);
    }

    // PUT api/<PatientController>/5
    [HttpPut("{id}")]
    public async Task<PatientVm> Put(long id, [FromBody] PatientVm value)
    {
        var entity = _mapper.Map<Patient>(value);
        var result = await _patientRepository.UpdateAsync(id, entity);
        return _mapper.Map<PatientVm>(result);
    }

    // DELETE api/<PatientController>/5
    [HttpDelete("{id}")]
    public async Task<PatientVm> Delete(long id)
    {
        var result = await _patientRepository.DeleteAsync(id);
        return _mapper.Map<PatientVm>(result);
    }
}
