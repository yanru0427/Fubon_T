using Fubon_T.Models;
using Fubon_T.Repositories.Interfaces;
using Fubon_T.ViewModels;
using Microsoft.CodeAnalysis.Scripting;

namespace Fubon_T.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repo;

        public MemberService(IMemberRepository repo)
        {
            _repo = repo;
        }

        public Result Register(RegisterViewModel model)
        {
            if (_repo.Exists(model.Username))
                return Result.Fail("帳號已存在");

            var member = new Member
            {
                Username = model.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Email = model.Email,
                AddTime = DateTime.UtcNow
            };

            _repo.Create(member);
            return Result.Ok();
        }
    }
}
