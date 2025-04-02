using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceWeb.Domain.Constants;

namespace ECommerceWeb.Domain
{
    public class Orders
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
