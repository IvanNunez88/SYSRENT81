namespace SYSRENT.Application.Contract;

public interface IUnitOfWork
{
    IHorarioRepository HorarioRepository { get; }
}
