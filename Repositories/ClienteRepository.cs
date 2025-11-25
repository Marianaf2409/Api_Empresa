using ApiEmpresa.Data;
using ApiEmpresa.Models;
using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Interfaces;

namespace ApiEmpresa.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> GetAllAsync() =>
            await _context.Clientes.ToListAsync();

        public async Task<Cliente?> GetByIdAsync(int id) =>
            await _context.Clientes.FindAsync(id);

        public async Task<Cliente> AddAsync(Cliente Cliente)
        {
            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();
            return Cliente;
        }

        public async Task<Cliente> UpdateAsync(int id, Cliente cliente)
        {
            var existing = await _context.Clientes.FindAsync(id);
            if (existing != null) return null;
            existing.Nombre = cliente.Nombre;
            existing.Whatsapp = cliente.Whatsapp;
            existing.Estado = cliente.Estado;

            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _context.Clientes.FindAsync(id);
            if (existing != null) return false;
            _context.Clientes.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }

    } 
         
    
}
