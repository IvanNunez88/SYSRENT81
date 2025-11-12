using FluentValidation;
using SYSRENT.Application.Contract;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Application.Features.Vehiculo.Validator;

#region Command
public class UpdVehiculoValidator : AbstractValidator<UPDVEHICULO>
{
    private readonly IUnitOfWork _unitOfWork;


    public UpdVehiculoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Descrip).Cascade(CascadeMode.Stop).MinimumLength(4).WithMessage("Debe escribir una descripción del vehículo.");
        RuleFor(x => x.IdTamaño).Cascade(CascadeMode.Stop).GreaterThan(0).WithMessage("Debe seleccionar un tamaño");
        RuleFor(x => x.Capacidad).Cascade(CascadeMode.Stop).GreaterThan(0).WithMessage("Debe la capacidad no debe ser menor a 0");
        RuleFor(x => x.PRenta).Cascade(CascadeMode.Stop).GreaterThan(0).WithMessage("El precio de renta no puede ser menora 0");
    }
}

#endregion
