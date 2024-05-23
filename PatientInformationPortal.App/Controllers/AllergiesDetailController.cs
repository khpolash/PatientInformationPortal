using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientInformationPortal.Application.Repositories.Entities;
using PatientInformationPortal.Application.ViewModels.VmEntities;
using PatientInformationPortal.SharedKernel.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientInformationPortal.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AllergiesDetailController : ControllerBase
{
    private readonly IAllergiesDetailRepository _allergiesDetailRepository;
    private readonly IMapper _mapper;

    public AllergiesDetailController(IAllergiesDetailRepository allergiesDetailRepository, IMapper mapper)
    {
        _allergiesDetailRepository = allergiesDetailRepository;
        _mapper = mapper;
    }



    // GET: api/<AllergiesDetailController>
    [HttpGet]
    public async Task<IEnumerable<AllergiesDetailVm>> Get()
    {
        var list = await _allergiesDetailRepository.GetAllAsync();
        return _mapper.Map<List<AllergiesDetailVm>>(list);
    }

    // GET api/<AllergiesDetailController>/5
    [HttpGet("{id}")]
    public async Task<AllergiesDetailVm> Get(long id)
    {
        var allergiesDetail = await _allergiesDetailRepository.FirstOrDefaultAsync(id);
        return _mapper.Map<AllergiesDetailVm>(allergiesDetail); ;
    }

    // POST api/<AllergiesDetailController>
    [HttpPost]
    public async Task<AllergiesDetailVm> Post([FromBody] AllergiesDetailVm value)
    {
        var entity = _mapper.Map<AllergiesDetail>(value);
        var result = await _allergiesDetailRepository.InsertAsync(entity);
        return _mapper.Map<AllergiesDetailVm>(result);
    }

    // PUT api/<AllergiesDetailController>/5
    [HttpPut("{id}")]
    public async Task<AllergiesDetailVm> PutAsync(long id, [FromBody] AllergiesDetailVm value)
    {
        var entity = _mapper.Map<AllergiesDetail>(value);
        var result = await _allergiesDetailRepository.UpdateAsync(id, entity);
        return _mapper.Map<AllergiesDetailVm>(result);
    }

    // DELETE api/<AllergiesDetailController>/5
    [HttpDelete("{id}")]
    public async Task<AllergiesDetailVm> Delete(long id)
    {
        var result = await _allergiesDetailRepository.DeleteAsync(id);
        return _mapper.Map<AllergiesDetailVm>(result);
    }
}
