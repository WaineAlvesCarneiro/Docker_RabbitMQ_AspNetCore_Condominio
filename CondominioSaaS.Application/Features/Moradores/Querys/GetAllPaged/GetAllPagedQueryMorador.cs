using CondominioSaaS.Application.DTOs;
using CondominioSaaS.Domain.Common;
using MediatR;

namespace CondominioSaaS.Application.Features.Moradores.Queries.GetAllPaged;

public record GetAllPagedQueryMorador(
    int Page = 1,
    int PageSize = 5,
    string? SortBy = "Id",
    string Direction = "ASC",
    long? EmpresaId = null,
    string? Nome = null)
        : IRequest<Result<PagedResult<MoradorDto>>>
{
    public int ActualPage => Page < 1 ? 1 : Page;
    public int ActualPageSize => PageSize < 1 ? 5 : PageSize;
    public string ActualSortBy => !string.IsNullOrWhiteSpace(SortBy) ? SortBy : "Id";
    public string ActualDirection => Direction;
}