namespace Mangp.Services.CouponApi.Models.Dto
{
    using System.ComponentModel.DataAnnotations;

    public class CouponDto
    {
        [Key]
        public int CouponId { get; set; }

        [Required]
        public string CouponCode { get; set; }

        [Required]
        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }
    }
}
