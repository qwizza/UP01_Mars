using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class WarehouseManager
    {
        private readonly IWarehouseRepository _repository;

        public WarehouseManager(IWarehouseRepository repository)
        {
            _repository = repository;
        }

        public List<WarehouseItem> GetStock(out string error)
        {
            return _repository.GetWarehouseStock(out error);
        }
    }
}
