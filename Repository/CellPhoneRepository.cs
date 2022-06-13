using CellTechApi.DbContexts;
using CellTechApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellTechApi.Repository
{
    public class CellPhoneRepository : ICellPhoneRepository
    {
        private readonly CellPhoneContext _dbContext;

        public CellPhoneRepository(CellPhoneContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteCellPhone(int cellPhoneId)
        {
            var cellPhone = _dbContext.CellPhones.Find(cellPhoneId);
            _dbContext.Remove(cellPhone);
            Save();
        }

        public CellPhone GetCellPhoneById(int id)
        {
            var cellPhone = _dbContext.CellPhones.Find(id);
            return cellPhone;
        }

        public IEnumerable<CellPhone> GetCellPhones()
        {
            return _dbContext.CellPhones.ToList();
        }

        public void InsertCellPhone(CellPhone cellPhone)
        {
            _dbContext.Add(cellPhone);
            Save();
        }

        public void UpdateCellPhone(CellPhone cellPhone)
        {
            _dbContext.Entry(cellPhone).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
