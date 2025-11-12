using FluentValidation;
using SYSRENT.Application.Contract;
using SYSRENT.Domain.Vehiculo.Entity;

namespace SYSRENT.Application.Features.Vehiculo.Validator;

public class VehiculoValidator : AbstractValidator<VEHICULO>
{
    private readonly IUnitOfWork _unitOfWork;


    public VehiculoValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(x => x.Descrip).Cascade(CascadeMode.Stop).MinimumLength(4).WithMessage("Debe escribir una descripción del vehículo.");
        RuleFor(x => x.IdTamaño).Cascade(CascadeMode.Stop).GreaterThan(0).WithMessage("Debe seleccionar un tamaño");
        RuleFor(x => x.Capacidad).Cascade(CascadeMode.Stop).GreaterThan(0).WithMessage("Debe la capacidad no debe ser menor o igual a 0");
        RuleFor(x => x.PRenta).Cascade(CascadeMode.Stop).GreaterThan(0).WithMessage("El precio de renta no puede ser menor o igual a 0");
    }
}
