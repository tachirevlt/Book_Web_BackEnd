// File: Application/Queries/GetJokeQuery.cs
using MediatR;
using Core.Models; // Namespace chứa JokeModel

namespace Application.Queries
{
    // Record này định nghĩa yêu cầu lấy một câu đùa (joke).
    // Không cần tham số đầu vào.
    // Kế thừa IRequest<JokeModel> để chỉ định kiểu dữ liệu trả về.
    public record GetJokeQuery() : IRequest<JokeModel?>;
}