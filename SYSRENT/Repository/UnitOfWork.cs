using SYSRENT.Application.Contract;
using SYSRENT.Application.Data;

namespace SYSRENT.Infrastructure.Repository;

public class UnitOfWork(ISqlDbConnection sqlDbConnection) : IUnitOfWork
{
    private readonly ISqlDbConnection _sqlDbConnection = sqlDbConnection;

    private IHorarioRepository? _horarioRepository;


    public IHorarioRepository HorarioRepository => _horarioRepository ??= new HorarioRepository(_sqlDbConnection);
}
