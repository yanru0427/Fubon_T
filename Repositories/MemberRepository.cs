using Dapper;
using Fubon_T.Models;
using Fubon_T.Repositories.Interfaces;
using System.Data;

namespace Fubon_T.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IDbConnection _db;

        public MemberRepository(IDbConnection db)
        {
            _db = db;
        }

        public bool Exists(string username)
        {
            var sql = "SELECT COUNT(1) FROM Members WHERE Username = @Username";
            return _db.ExecuteScalar<int>(sql, new { Username = username }) > 0;
        }

        public void Create(Member member)
        {
            var sql = @"
                INSERT INTO Members (Username, Email, Password, AddTime)
                VALUES (@Username, @Email, @Password, @AddTime)";

            _db.Execute(sql, member);
        }
    }
}
