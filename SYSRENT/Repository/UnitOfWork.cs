using SYSRENT.Application.Contract;
using SYSRENT.Application.Data;

namespace SYSRENT.Infrastructure.Repository;

public class UnitOfWork(ISqlDbConnection sqlDbConnection) : IUnitOfWork
{
    private readonly ISqlDbConnection _sqlDbConnection = sqlDbConnection;

    private IHorarioRepository? _horarioRepository;
    private IVehiculoRepository? _vehiculoRepository;
    private ITamanoRepository? _tamanoRepository;

    public IHorarioRepository HorarioRepository => _horarioRepository ??= new HorarioRepository(_sqlDbConnection);
    public IVehiculoRepository VehiculoRepository => _vehiculoRepository ??= new VehiculoRepository(_sqlDbConnection);
    public ITamanoRepository TamanoRepository => _tamanoRepository ??= new TamanoRepository(_sqlDbConnection);
}
