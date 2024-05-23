using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortal.Application.Repositories.Entities;
using PatientInformationPortal.Application.ViewModels.VmEntities;
using PatientInformationPortal.SharedKernel.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientInformationPortal.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiseaseController : ControllerBase
{
    private IDiseaseRepository _diseaseRepository;
    private IMapper _mapper;

    public DiseaseController(IDiseaseRepository diseaseRepository, IMapper mapper)
    {
        _diseaseRepository = diseaseRepository;
        _mapper = mapper;
    }

    // GET: api/<DiseaseController>
    [HttpGet]
    public async Task<IEnumerable<DiseaseVm>> Get()
    {
        var list = await _diseaseRepository.GetAllAsync();
        return _mapper.Map<List<DiseaseVm>>(list);
    }

    // GET api/<DiseaseController>/5
    [HttpGet("{id}")]
    public async Task<DiseaseVm> Get(long id)
    {
        var disease = await _diseaseRepository.FirstOrDefaultAsync(id);
        return _mapper.Map<DiseaseVm>(disease);
    }

    // POST api/<DiseaseController>
    [HttpPost]
    public async Task<DiseaseVm> Post([FromBody] DiseaseVm value)
    {
        var entity = _mapper.Map<Disease>(value);
        var result = await _diseaseRepository.InsertAsync(entity);
        return _mapper.Map<DiseaseVm>(result);
    }

    // PUT api/<DiseaseController>/5
    [HttpPut("{id}")]
    public async Task<DiseaseVm> Put(long id, [FromBody] DiseaseVm value)
    {
        var entity = _mapper.Map<Disease>(value);
        var result = await _diseaseRepository.UpdateAsync(id, entity);
        return _mapper.Map<DiseaseVm>(result);
    }

    // DELETE api/<DiseaseController>/5
    [HttpDelete("{id}")]
    public async Task<DiseaseVm> Delete(long id)
    {
        var result = await _diseaseRepository.DeleteAsync(id);
        return _mapper.Map<DiseaseVm>(result);
    }
}
