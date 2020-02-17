using System;
namespace DTO
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public Guid PersonID { get; set; }
        public Person Person { get; set; }

        public Guid UserRoleID { get; set; }
        public UserRole UserRole { get; set; }

        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
