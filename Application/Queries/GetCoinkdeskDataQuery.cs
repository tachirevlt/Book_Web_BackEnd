// File: Application/Queries/GetCoinkdeskDataQuery.cs
using MediatR;
using Core.Models; // Namespace chứa CoindeskData

namespace Application.Queries
{
    // Record này định nghĩa yêu cầu lấy dữ liệu Coindesk.
    // Vì không cần tham số đầu vào, record này trống.
    // Nó kế thừa IRequest<CoindeskData> để chỉ định kiểu dữ liệu trả về.
    public record GetCoinkdeskDataQuery() : IRequest<CoindeskData>;
}