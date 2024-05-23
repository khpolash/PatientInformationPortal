using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortal.Application.Repositories.Entities;
using PatientInformationPortal.Application.ViewModels.VmEntities;
using PatientInformationPortal.SharedKernel.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientInformationPortal.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NCDDetailController : ControllerBase
{
    private readonly INCDDetailRepository _repository;
    private readonly IMapper _mapper;

    public NCDDetailController(INCDDetailRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // GET: api/<NCDDetailController>
    [HttpGet]
    public async Task<IEnumerable<NCDDetailVm>> Get()
    {
        var list = await _repository.GetAllAsync(x => x.Disease);
        return _mapper.Map<List<NCDDetailVm>>(list);
    }

    // GET api/<NCDDetailController>/5
    [HttpGet("{id}")]
    public async Task<NCDDetailVm> Get(long id)
    {
        var ncdDetail = await _repository.FirstOrDefaultAsync(id);
        return _mapper.Map<NCDDetailVm>(ncdDetail);
    }

    // POST api/<NCDDetailController>
    [HttpPost]
    public async Task<NCDDetailVm> Post([FromBody] NCDDetailVm value)
    {
        var entity = _mapper.Map<NCDDetail>(value);
        var result = await _repository.InsertAsync(entity);
        return _mapper.Map<NCDDetailVm>(result);
    }

    // PUT api/<NCDDetailController>/5
    [HttpPut("{id}")]
    public async Task<NCDDetailVm> Put(long id, [FromBody] NCDDetailVm value)
    {
        var entity = _mapper.Map<NCDDetail>(value);
        var result = await _repository.UpdateAsync(id, entity);
        return _mapper.Map<NCDDetailVm>(result);
    }

    // DELETE api/<NCDDetailController>/5
    [HttpDelete("{id}")]
    public async Task<NCDDetailVm> DeleteAsync(long id)
    {
        var result = await _repository.DeleteAsync(id);
        return _mapper.Map<NCDDetailVm>(result);
    }
}
