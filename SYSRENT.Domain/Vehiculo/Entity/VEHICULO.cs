namespace SYSRENT.Domain.Vehiculo.Entity;

public sealed record VEHICULO
(
    string Descrip,
    int IdTamaño,
    int Capacidad,
    decimal PRenta
);
