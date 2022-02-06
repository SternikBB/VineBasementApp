using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VineBasementHelpers.Interfaces;
using VineBasementHelpers.Models.VineModels.GET;
using VineBasementHelpers.Models.VineModels.POST;
using VineBasementHelpers.Models.VineModels.PUT;

namespace VineBasementWebApi.Controllers
{
    [ApiController]
    [Route("api/Vines")]
    public class VineController: ControllerBase
    {
        private readonly IVineRepositoryAsync _vineRepository;
        private readonly IVineyardRepositoryAsync _vineyardRepository;
        private readonly ILogger<VineController> _logger;
        private readonly IMapper _mapper;
        public VineController(IVineRepositoryAsync vineRepository, IVineyardRepositoryAsync vineyardRepository, ILogger<VineController> logger, IMapper mapper)
        {
            _vineRepository = vineRepository;
            _vineyardRepository = vineyardRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var allVines = _vineRepository.GetByCondition(null, null, c => c.Include(c => c.Vineyard));
            var model = _mapper.Map<IEnumerable<GetAllVines>>(allVines);

            return Ok(model);
        }

        [HttpGet("{vineId}")]
        public async Task<IActionResult> GetVineById(int vineId)
        {
            var vine = await _vineRepository.GetByIdAsync(vineId).ConfigureAwait(false);
            return Ok(vine);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVine([FromBody] AddNewVine dto)
        {
            var vine = _mapper.Map<Vine>(dto);
            await _vineRepository.AddAsync(vine).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetVineById), new { vineId = vine.VineId }, vine);
        }

        [HttpPut("{vineId}")]
        public async Task<IActionResult> UpdateVine([FromBody] EditVineApi dto, int vineId)
        {
            var user = _mapper.Map<Vine>(dto, opt => opt.Items["VineId"] = vineId);
            await _vineRepository.UpdateAsync(user).ConfigureAwait(false);
            return Ok();
        }

        [HttpDelete("{vineId}")]
        public async Task<IActionResult> DeleteVine(int vineId)
        {
            var stationToDelete = await _vineRepository.GetByIdAsync(vineId).ConfigureAwait(false);
            await _vineRepository.DeleteAsync(stationToDelete).ConfigureAwait(false);
            return Ok("Obiekt usunięty");
        }
    }
}
