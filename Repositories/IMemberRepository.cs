using Fubon_T.Models;

namespace Fubon_T.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        bool Exists(string username);
        void Create(Member member);
    }
}
