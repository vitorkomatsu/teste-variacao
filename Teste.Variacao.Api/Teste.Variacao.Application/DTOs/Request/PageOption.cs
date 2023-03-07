using System.ComponentModel.DataAnnotations;

namespace Teste.Variacao.Application.DTOs.Request
{
    public class PageOption
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Page { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }
    }
}