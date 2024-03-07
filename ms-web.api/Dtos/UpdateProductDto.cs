using System.ComponentModel.DataAnnotations;

namespace ms_web.api.Dtos;

public record class UpdateProductDto(
    [Required][StringLength(50)] string Name,
    [Range(100, 10000)] decimal Price
);