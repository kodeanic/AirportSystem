﻿using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class FlightRepository : GenericRepository<Flight>, IFlightRepository
{
    public FlightRepository(ApplicationDbContext db) : base(db) { }

    public async Task<List<Flight>> GetFlightsByCompany(string company) =>
        await _dbSet.Where(f => f.Company == company).ToListAsync();

    public async Task<List<Flight>> GetFlightsByDepartureCity(string departureCity) =>
        await _dbSet.Where(f => f.DepartureCity == departureCity).ToListAsync();

    public async Task<List<Flight>> GetFlightsByArriveCity(string arriveCity) =>
        await _dbSet.Where(f => f.ArriveCity == arriveCity).ToListAsync();
}
