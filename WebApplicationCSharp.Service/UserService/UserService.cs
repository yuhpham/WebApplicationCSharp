using Azure;
using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Reponse.User;
using WebApplicationCSharp.dto.Request.User;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplicationCSharp.Service.UserService
{
    public class UserService : IUserService
    {

        public async Task<UserGetListResponse> GetListUser(UserRequest request)
        {


            UserGetListResponse response = new UserGetListResponse()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,


            };
            using (ApplicatitonContext context = new ApplicatitonContext())
            {
                IQueryable<User> query = context.Users.Where(a => a.Id == request.Id);
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
                response.Total = query.Count();


            }
            return response;
        }

        public async Task<UserResponse> GetUserId(Guid Id)
        {
            UserResponse response = new();
            await using (ApplicatitonContext context = new())

            {
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
            return response;
        }
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
