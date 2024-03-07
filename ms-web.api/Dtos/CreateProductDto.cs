using System.ComponentModel.DataAnnotations;

namespace ms_web.api.Dtos;

public record class CreateProductDto(
    [Required][StringLength(50)] string Name,
    [Required][Range(100, 10000)] decimal Price
);
