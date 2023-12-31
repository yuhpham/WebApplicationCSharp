﻿using WebApplicationCSharp.dto.Reponse.User;
using WebApplicationCSharp.dto.Request.User;

namespace WebApplicationCSharp.Service.UserService
{
    public interface IUserService
    {
        public Task<UserGetListResponse> GetListUser(UserRequest request);
        public Task<UserResponse> GetUserId(Guid Id);
        public Task<Boolean> CreateUser(UserCreateRequest request);
        public Task<UserResponse> UpdateUser(UserUpdateRequest request);
        public Task<UserResponse> DeleteUser(Guid Id);
    }
}
