using CellTechApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellTechApi.Repository
{
    public interface ICellPhoneRepository
    {
        void InsertCellPhone(CellPhone cellPhone);
        void UpdateCellPhone(CellPhone cellPhone);
        void DeleteCellPhone(int cellPhoneId);
        CellPhone GetCellPhoneById(int id);
        IEnumerable<CellPhone> GetCellPhones();
    }
}
