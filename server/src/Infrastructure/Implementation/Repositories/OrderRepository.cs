using Domain.Entities;
using Infrastructure.Interfaces.IRepository;

namespace Infrastructure.Implementation.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext db) : base(db) { }
}
