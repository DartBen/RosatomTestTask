using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RosatomTestTask.Domain;
using RosatomTestTask.Infrastructure.Entities;
using RosatomTestTask.Infrastructure.UOW;
using RosatomTestTask.Infrastructure.Mappings;

namespace RosatomTestTask.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly IUnitOfWorks _unitOfWork;

        public MasterController(IUnitOfWorks unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<List<Master>> GetMasters()
        {
            var masterEntities = _unitOfWork.MasterEntities.GetAll()
                .Include(m => m.Details)
                .ToList();

            var masters = masterEntities.Select(m => m.ToDomain()).ToList();
            return Ok(masters);
        }

        [HttpGet("{id}")]
        public ActionResult<Master> GetMaster(int id)
        {
            var masterEntity = _unitOfWork.MasterEntities.GetAll()
                .Include(m => m.Details)
                .FirstOrDefault(m => m.Id == id);

            if (masterEntity == null)
                return NotFound();

            return Ok(masterEntity.ToDomain());
        }

        [HttpPost]
        public async Task<ActionResult<Master>> CreateMaster(Master master)
        {
            var masterEntity = master.ToEntity();
            _unitOfWork.MasterEntities.Add(masterEntity);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMaster), new { id = masterEntity.Id }, masterEntity.ToDomain());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaster(int id, Master masterDto)
        {
            var existing = _unitOfWork.MasterEntities.GetAll()
                .Include(m => m.Details)
                .FirstOrDefault(m => m.Id == id);

            if (existing == null)
                return NotFound();

            // Удаляем старые детали
            foreach (var detail in existing.Details)
            {
                _unitOfWork.DetailEntities.Delete(detail);
            }

            // Обновляем мастер
            existing.Number = masterDto.Number;
            existing.Date = masterDto.Date;
            existing.Amount = masterDto.Amount;
            existing.Note = masterDto.Note;

            // Добавляем новые детали
            if (masterDto.Details != null)
            {
                foreach (var detail in masterDto.Details)
                {
                    var detailEntity = detail.ToEntity();
                    detailEntity.MasterId = id; // гарантируем правильный ID
                    _unitOfWork.DetailEntities.Add(detailEntity);
                }
            }

            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaster(int id)
        {
            var master = _unitOfWork.MasterEntities.GetById(id);
            if (master == null)
                return NotFound();

            _unitOfWork.MasterEntities.Delete(master);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
