using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.ViewModels;
public class SizeVM
{
    public int SizeId { get; set; }

    public string Name { get; set; }

    public IEnumerable<ProductVM> Products { get; set; }
}