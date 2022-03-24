using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.ClientSite.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }   
    }
}