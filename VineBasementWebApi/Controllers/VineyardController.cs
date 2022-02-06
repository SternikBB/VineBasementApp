using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using VineBasementHelpers.Interfaces;
using VineBasementHelpers.Models.VineyardModels.GET;
using VineBasementHelpers.Models.VineyardModels.POST;
using VineBasementHelpers.Models.VineyardModels.PUT;

namespace VineBasementWebApi.Controllers
{
    [ApiController]
    [Route("api/Vineyards")]
    public class VineyardController:ControllerBase
    {
        private readonly IVineyardRepositoryAsync _vineyardRepository;
        private readonly ILogger<VineyardController> _logger;
        private readonly IMapper _mapper;
        public VineyardController(IVineyardRepositoryAsync vineyardRepository, ILogger<VineyardController> logger, IMapper mapper)
        {
            _vineyardRepository = vineyardRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var allVines = await _vineyardRepository.GetAllAsync();
            var model = _mapper.Map<IEnumerable<GetAllVineyards>>(allVines);
            return Ok(model);
        }

        [HttpGet("{vineyardId}")]
        public async Task<IActionResult> GetVineyardById(int vineyardId)
        {
            var vineyard = await _vineyardRepository.GetByIdAsync(vineyardId).ConfigureAwait(false);
            return Ok(vineyard);
        }

        [HttpDelete("{vineyardId}")]
        public async Task<IActionResult> DeleteVineyard(int vineyardId)
        {
            var stationToDelete = await _vineyardRepository.GetByIdAsync(vineyardId).ConfigureAwait(false);
            await _vineyardRepository.DeleteAsync(stationToDelete).ConfigureAwait(false);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVineyard([FromBody] AddNewVineyard dto)
        {
            var vineyard = _mapper.Map<Vineyard>(dto);
            await _vineyardRepository.AddAsync(vineyard).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetVineyardById), new { vineyardId = vineyard.VineyardId }, vineyard);
        }

        [HttpPut("{vineyardId}")]
        public async Task<IActionResult> UpdateVineyard([FromBody] EditVineyardForApi dto, int vineyardId)
        {
            var vineyard = _mapper.Map<Vineyard>(dto, opt => opt.Items["VineyardId"] = vineyardId);
            await _vineyardRepository.UpdateAsync(vineyard).ConfigureAwait(false);
            return Ok();
        }

    }
}
