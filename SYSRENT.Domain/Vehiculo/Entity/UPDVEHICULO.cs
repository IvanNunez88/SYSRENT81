namespace SYSRENT.Domain.Vehiculo.Entity;

public sealed record UPDVEHICULO
(
    int IdVehiculo,
    string Descrip,
    int IdTamaño,
    int Capacidad,
    decimal PRenta,
    bool IsEstado
);
