using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib.Validation
{
    public class WarehouseValidate
    {
        public static  bool ValidateReceipt(WarehouseItem receiptItem, out string error)
        {
            error = string.Empty;

            if (receiptItem == null)
            {
                error = "Данные поступления не переданы.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(receiptItem.NomenclatureName))
            {
                error = "Необходимо указать наименование номенклатуры.";
                return false;
            }

            if (receiptItem.TotalQuantity <= 0)
            {
                error = "Количество поступления должно быть больше нуля.";
                return false;
            }

            if (receiptItem.UnitPrice < 0)
            {
                error = "Цена за единицу не может быть отрицательной.";
                return false;
            }

            return true;
        }
        public static bool ValidateWriteOff(WarehouseItem writeOffItem, out string error)
        {
            error = string.Empty;

            if (writeOffItem == null)
            {
                error = "Данные списания не переданы.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(writeOffItem.NomenclatureName))
            {
                error = "Необходимо указать наименование номенклатуры.";
                return false;
            }
            if (writeOffItem.TotalQuantity <= 0)
            {
                error = "Количество списания должно быть больше нуля.";
                return false;
            }
            if (writeOffItem.UnitPrice < 0)
            {
                error = "Цена за единицу не может быть отрицательной.";
                return false;
            }
            return true;
        }
    }
}
