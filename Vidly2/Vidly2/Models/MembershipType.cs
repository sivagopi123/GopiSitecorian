
namespace Vidly2.Models
{
    public class MembershipType
    {
        public int MembershipTypeId { get; set; }

        public string MembershipTypeName { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }
    }
}