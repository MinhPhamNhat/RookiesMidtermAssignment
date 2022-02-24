using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.ClientSite.Models.ViewModels;
public class RoleVM
{
    public RoleConstants RoleId { get; set; }
    public string? Description { get; set; }

}