using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.User;
using WebApplicationCSharp.dto.Request.User;

namespace WebApplicationCSharp.Service.UserService
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Get List User
        /// </summary>
        /// <param name="request"></param>
        /// <returns> ListUser</returns>
        public async Task<UserGetListResponse> GetListUser(UserRequest request)
        {


            UserGetListResponse response = new UserGetListResponse()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };
            ///conect database to table user
            using (ApplicatitonContext context = new ApplicatitonContext())
            {
                IQueryable<User> query = context.Users.Where(a => a.Name.Contains(request.Name) && a.Email.Contains(request.Email));
                response.userGetListResponse = await query
                     .Skip(request.PageSize * (request.PageIndex - 1))
                     .Take(request.PageSize)
                     .Select(a => new UserResponse
                     {
                         Id = a.Id,
                         Name = a.Name,
                         Email = a.Email,
                         Password = a.Password,

                     }).ToListAsync();
                /// coutn total record
                response.Total = query.Count();

            }
            ///return data user
            return response;
        }
        /// <summary>
        /// Get user folow userid
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>User data follow UserId</returns>
        public async Task<UserResponse> GetUserId(Guid Id)
        {
            UserResponse response = new();
            await using (ApplicatitonContext context = new())

            {   /// conect user find with UserId
                User? user = context.Users.Find(Id);

                if (user != null)
                {
                    response = new()
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                        Password = user.Password,

                    };
                }
                else
                {
                    Console.WriteLine(" not found ");
                }
            }
            /// return data user follow UserId
            return response;
        }
        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>true or fale</returns>
        public async Task<bool> CreateUser(UserCreateRequest request)
        {
            using (ApplicatitonContext context = new())
            {
                User user = new User()
                {
                    Name = request.Name,
                    Email = request.Email,
                    Password = request.Password,
                };
                context.Users.Add(user);
                int y = await context.SaveChangesAsync();

                return y > 0;
            }
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="request"></param>
        /// <returns> updated user == GetUserId</returns>
        public async Task<UserResponse> UpdateUser(UserUpdateRequest request)
        {
            using (ApplicatitonContext context = new())
            {
                if (context.Users != null)
                {
                    User? query = context.Users.Find(request.Id);
                    if (query != null)
                    {
                        query.Name = (request.Name == "") ? query.Name : request.Name;
                        query.Email = (request.Email == "") ? query.Email : request.Email;
                        query.Password = (request.Password == "") ? query.Password : request.Password;
                    }
                }
            }
            return await GetUserId(request.Id);
        }
        public Task<UserResponse> DeleteUser(Guid Id)
        {
            throw new NotImplementedException();
        }


    }
}
