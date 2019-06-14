using Finances.Core.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Finances.Core.Application.Users.Queries.GetProfileByUserId
{
    public class ProfileByUserIdModel
    {
        #region Person

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string TaxNumber { get; set; }
        public char Gender { get; set; }

        #endregion

        #region User

        public string UserName { get; set; }
        public string Password { get; set; }

        #endregion

        #region UserImage

        public string UserImage { get; set; }

        #endregion

        #region Contact

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        #endregion

        public static Expression<Func<User, ProfileByUserIdModel>> Projection
        {
            get
            {
                return user => new ProfileByUserIdModel
                {
                    UserName = user.Username,
                    Password = user.Password
                };
            }
        }

        public static ProfileByUserIdModel Create(User user)
        {
            return Projection.Compile().Invoke(user);
        }
    }
}