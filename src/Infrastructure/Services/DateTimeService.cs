using CentroEspecialidadesDentales.Application.Common.Interfaces;

namespace CentroEspecialidadesDentales.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
