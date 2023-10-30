using Microsoft.AspNetCore.Identity;
using OnlineAuction.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Auctions.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public bool IsSold { get; set; } = false;
        [Required]
        public string? IdentityUserId { get; set; }
        [ForeignKey("IdentityUserId")]
        public IdentityUser? User { get; set; }
        public List<Bid>? Bids { get; set; }
        public List<Comment>? Comments { get; set; }




        [NotMapped] // This ensures the property isn't mapped to a database column
        public IFormFile Image { get; set; }

        // ... other properties ...
   


}
}
