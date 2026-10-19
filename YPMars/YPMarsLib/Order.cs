using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private OrderStatus _status;

        [DisplayName("Номер договора")]
        public string ContractNumber { get; set; }

        [DisplayName("Дата заказа")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Контрагент")]
        public string CounterpartyName { get; set; }

        [Browsable(false)]
        public OrderStatus Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(StatusText)); // Уведомляем таблицу, что текстовый статус тоже изменился
                }
            }
        }

        [DisplayName("Статус")]
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case OrderStatus.New:
                        return "Новый";
                    case OrderStatus.InProgress:
                        return "В работе";
                    case OrderStatus.ReadyForShipment:
                        return "Готов к отгрузке";
                    case OrderStatus.Shipment:
                        return "Отгружен";
                    case OrderStatus.Completed:
                        return "Завершен";
                    case OrderStatus.Cancelled:
                        return "Отменен";
                    default:
                        return Status.ToString();
                }
            }
        }

        [DisplayName("План. отгрузка")]
        public DateTime PlannedShipmentDate { get; set; }

        [Browsable(false)]
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        [DisplayName("Кол-во позиций")]
        public int PositionCount => Items.Count;

        [DisplayName("Итоговая сумма")]
        public decimal TotalAmount
        {
            get
            {
                decimal sum = 0;
                foreach (var item in Items)
                {
                    sum += item.TotalPrice;
                }
                return sum;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
