using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using VineBasementHelpers.Interfaces;
using VineBasementHelpers.Models.VineyardModels.GET;
using VineBasementHelpers.Models.VineyardModels.POST;
using VineBasementHelpers.Models.VineyardModels.PUT;

namespace VineBasementApp.Controllers
{

    [Route("Vineyards")]
    public class VineyardController : Controller
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
            return View(model);
        }

        [HttpPost]
        [Route("add/new-vineyard")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddNewVineyard model)
        {
            if (ModelState.IsValid)
            {
                var newVineyard = _mapper.Map<Vineyard>(model);
                await _vineyardRepository.AddAsync(newVineyard);
                return RedirectToAction("GetAll");
            }
            return View("AddVineyard");
        }


        [Route("add")]
        public async Task<IActionResult> AddVineyard()
        {
            return View();
        }

        [Route("edit")]
        public async Task<IActionResult> EditVineyard(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var vine = await _vineyardRepository.GetByIdAsync(id.Value);
            if (vine == null) return NotFound();

            var model = _mapper.Map<EditVineyard>(vine);
            return View(model);
        }

        [HttpPost]
        [Route("edit/vineyard")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVineyard model)
        {
            if (ModelState.IsValid)
            {
                var updatedVineyard = _mapper.Map<Vineyard>(model);
                await _vineyardRepository.UpdateAsync(updatedVineyard);
                return RedirectToAction("GetAll");
            }
            return View("EditVineyard");
        }


        #region DELETE
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vineToDelete = await _vineyardRepository.GetByIdAsync(id);
            await _vineyardRepository.DeleteAsync(vineToDelete);
            return RedirectToAction("GetAll");
        }

        #endregion


        [Route("search")]
        public async Task<IActionResult> Filter(SearchVineyards filter)
        {
            var elements = await _vineyardRepository.FilterVineyards(filter);
            var model = _mapper.Map<IEnumerable<GetAllVineyards>>(elements);
            return View("GetAll",model);
        }

    }
}
