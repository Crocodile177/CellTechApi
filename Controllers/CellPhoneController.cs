using CellTechApi.Models;
using CellTechApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CellTechApi.Controllers
{
    [Produces("application/json")]
    [Route("api/CellPhone")]
    [ApiController]
    public class CellPhoneController : Controller
    {
        private readonly ICellPhoneRepository _cellPhoneRepository;

        public CellPhoneController(ICellPhoneRepository cellPhoneRepository)
        {
            _cellPhoneRepository = cellPhoneRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cellPhones = _cellPhoneRepository.GetCellPhones();
            return new OkObjectResult(cellPhones);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var cellPhone = _cellPhoneRepository.GetCellPhoneById(id);
            return new OkObjectResult(cellPhone);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CellPhone cellPhone)
        {
            using (var scope = new TransactionScope())
            {
                _cellPhoneRepository.InsertCellPhone(cellPhone);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = cellPhone.Id }, cellPhone);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CellPhone cellPhone)
        {
            if (cellPhone != null)
            {
                using (var scope = new TransactionScope())
                {
                    _cellPhoneRepository.UpdateCellPhone(cellPhone);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cellPhoneRepository.DeleteCellPhone(id);
            return new OkResult();
        }
    }
}
