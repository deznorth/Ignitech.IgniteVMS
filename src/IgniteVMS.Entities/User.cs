
namespace IgniteVMS.Entities
{
    // Never return this entity to the front-end, use an entity that excludes the password!
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }

        public UserResponse ToUserResponse()
        {
            return new UserResponse
            {
                UserID = UserID,
                Username = Username,
                UserRole = UserRole
            };
        }
    }
}
