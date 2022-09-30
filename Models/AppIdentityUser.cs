
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models;

public class AppIdentityUser : IdentityUser
{
    [MaxLength(120)]
    public string Name { get; set; }
    public DateTimeOffset UserSinceDate { get; set; }
    public DateTimeOffset LastPasswordChangeDate { get; set; }
}
