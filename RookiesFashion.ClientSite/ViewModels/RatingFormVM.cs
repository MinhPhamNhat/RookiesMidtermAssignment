using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.ViewModels
{
    public class RatingFormVM
    {
        public int RatingVal { get; set; }
        public string? Comment { get; set; }
        public int? ProductId { get; set; }
    }
}