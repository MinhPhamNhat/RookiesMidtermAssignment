using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.ClientSite.Models
{
    public class Role
    {
        public RoleConstants RoleId { get; set; }
        public string? Description { get; set; }

    }
}