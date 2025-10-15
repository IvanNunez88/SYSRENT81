using FluentValidation;
using SYSRENT.Application.Contract;
using SYSRENT.Domain.Horario.Entity;

namespace SYSRENT.Application.Features.Horario.Validator;

public class HorarioValidator : AbstractValidator<HORARIO>
{
    private readonly IUnitOfWork _unitOfWork;

    public HorarioValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Descrip).Cascade(CascadeMode.Stop).MinimumLength(4).WithMessage("Debes escribir una descripción del horario");
        RuleFor(x => x.Minutos).Cascade(CascadeMode.Stop).GreaterThan(0).WithMessage("Los minutos deben ser mayor a 0");

    }

}
