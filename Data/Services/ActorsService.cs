﻿using eTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicketApp.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            return actor;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }
    }
}
