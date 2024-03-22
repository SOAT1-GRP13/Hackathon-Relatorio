using Domain.Pontos;
using Domain.Base.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Pontos.Repository
{
    public class PontoRepository : IPontoRepository
    {
        private readonly PontosContext _context;

        public PontoRepository(PontosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Ponto>> ObterEspelhoDePonto(Guid userId, int mes, int ano)
        {
            return await _context.Pontos
                            .Where(p => p.UserId == userId
                                    && p.DataHora.Month == mes
                                    && p.DataHora.Year == ano)
                            .ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
