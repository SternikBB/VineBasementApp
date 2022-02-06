using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VineBasementHelpers.Extensions;
using VineBasementHelpers.Interfaces;
using VineBasementHelpers.Models.VineModels.GET;
using VineBasementHelpers.Models.VineModels.POST;
using VineBasementHelpers.Models.VineModels.PUT;

namespace VineBasementApp.Controllers
{
    [Route("Vines")]
    public class VineController:Controller
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
            
            return View(model);
        }


        #region POST

        [HttpPost]
        [Route("add/new-vine")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddNewVine model)
        {
            if(ModelState.IsValid)
            {
                var newVine = _mapper.Map<Vine>(model);
                await _vineRepository.AddAsync(newVine);
                return RedirectToAction("GetAll");
            }
            var vineyardsList = await _vineyardRepository.GetAllAsync();
            ViewBag.Vineyards = new SelectList(vineyardsList, "VineyardId", "VineyardName");
            return View("AddVine");
            
        }

        [Route("add")]
        public async Task<IActionResult> AddVine()
        {
            var vineyardsList = await _vineyardRepository.GetAllAsync();
            ViewBag.Vineyards = new SelectList(vineyardsList, "VineyardId", "VineyardName");
            return View();
        }

        #endregion

        #region PUT

        [Route("edit")]
        public async Task<IActionResult> EditVine(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var vine = _vineRepository.GetByCondition(c=>c.VineId==id, null, c => c.Include(c => c.Vineyard)).FirstOrDefault();
            if (vine == null) return NotFound();

            var model = _mapper.Map<EditVine>(vine);

            var vineyardsList = await _vineyardRepository.GetAllAsync();
            ViewBag.Vineyards = new SelectList(vineyardsList, "VineyardId", "VineyardName");
            return View(model);
        }

        [HttpPost]
        [Route("edit/vine")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVine model)
        {
            if (ModelState.IsValid)
            {
                var updatedVine = _mapper.Map<Vine>(model);
                await _vineRepository.UpdateAsync(updatedVine);
                return RedirectToAction("GetAll");
            }
            var vineyardsList = await _vineyardRepository.GetAllAsync();
            ViewBag.Vineyards = new SelectList(vineyardsList, "VineyardId", "VineyardName");
            return View("EditVine");
        }

        #endregion

        #region Delete

        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vineToDelete= await _vineRepository.GetByIdAsync(id);
            await _vineRepository.DeleteAsync(vineToDelete);
            return RedirectToAction("GetAll");
        }

        #endregion



    }
}
