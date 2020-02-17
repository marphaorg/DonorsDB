using System;
namespace DTO
{
    public class Donation
    {
        public Guid DonationID { get; set; }
        public double DonationValue { get; set; }

        public Guid DonationTypeID { get; set; }
        public DonationType DonationType { get; set; }

        public string DonationDesc { get; set; }

        public Guid DonationMethodID { get; set; }
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
