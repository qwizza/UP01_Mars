using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class OrderValidator
    {
        public string Validate(Order order)
        {
            if (order == null || string.IsNullOrWhiteSpace(order.CounterpartyName))
            {
                return "Выберите контрагента";
            }

            if (order.Items == null || order.Items.Count == 0)
            {
                return "Добавьте хотя бы одну позицию в заказ";
            }

            foreach (var item in order.Items)
            {
                if (string.IsNullOrWhiteSpace(item.NomenclatureName))
                {
                    return "Необходимо выбрать номенклатуру из списка";
                }

                if (item.Quantity <= 0)
                {
                    return "Количество должно быть больше нуля";
                }

                if (item.UnitPrice <= 0)
                {
                    return "Не удалось определить цену для выбранной номенклатуры";
                }
            }

            return string.Empty;
        }
    }
}
