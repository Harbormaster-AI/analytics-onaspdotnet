using analyticsonaspdotnet.Domain;
using Microsoft.EntityFrameworkCore;

namespace analyticsonaspdotnet.Persistence;

public class ReportRepository : IReportRepository
{
    private readonly ApplicationDbContext _db;

    public ReportRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Report?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Reports
            .Include(x => x.Workspace)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Report>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _db.Reports
            .AsNoTracking()
            .Include(x => x.Workspace)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(Report report, CancellationToken cancellationToken)
    {
        _db.Reports.Add(report);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Report report, CancellationToken cancellationToken)
    {
        _db.Reports.Update(report);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Report report, CancellationToken cancellationToken)
    {
        _db.Reports.Remove(report);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
