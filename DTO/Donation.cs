using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO
{
    public class Donation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DonationID { get; set; }
        public double DonationValue { get; set; }
        public DonationType DonationType { get; set; }
        public string DonationDesc { get; set; }
        public DonationMethod DonationMethod { get; set; }
        public DateTime DateDonated { get; set; }

        public Guid DonorID { get; set; }
        public Donor Donor { get; set; }

        public Guid DonationRecognizedByID { get; set; }
        public User DonationRecognizedBy { get; set; }

        public bool IsReviewed { get; set; }

        public Guid DonationReviewedByID { get; set; }
        public User DonationReviewedBy { get; set; }
        public DateTime DateReviewed{ get; set; }

        public bool IsVerified { get; set; }
        public string Remarks { get; set; }
    }
}
