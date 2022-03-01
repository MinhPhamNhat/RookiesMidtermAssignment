using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.ViewModels;
public class UpdatedDate
{
    public int UpdatedDateId { get; set; }

    public int? ProductId { get; set; }
    public ProductVM? Product { get; set; }
    public DateTime Time { get; set; }
}