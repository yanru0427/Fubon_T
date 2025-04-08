using Fubon_T.Data;
using Fubon_T.Models;
using Fubon_T.Repositories.Interfaces;

namespace Fubon_T.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _db;
        public MemberRepository(AppDbContext db) => _db = db;

        public bool Exists(string username) =>
            _db.Members.Any(x => x.Username == username);

        public void Create(Member member)
        {
            Console.WriteLine($"[DEBUG] 儲存會員：{member.Username}");
            _db.Members.Add(member);
            _db.SaveChanges();
        }
    }
}
