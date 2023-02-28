using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext db) : base(db) { }
}
