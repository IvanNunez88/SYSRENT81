namespace SYSRENT.Domain.Horario.DTO;

public sealed record DtoConsulCatHorario
(
  byte IdHorario,
  string Descrip,
  byte Minutos
);
