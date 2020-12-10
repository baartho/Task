using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskableChallenge.Model.Common;

namespace TaskableChallenge.Model.ShippingSlips.Infrastructure
{
    public interface IShippingSlipRepository : IRepository<ShippingSlip>
    {
        ShippingSlip Add(ShippingSlip ShippingSlip);
        ShippingSlip Update(ShippingSlip ShippingSlip);
        Task<ShippingSlip> FindByIdAsync(int id);
        Task<ShippingSlip> FindByOrderIdAsync(int id);
    }
}
