using Fubon_T.Models;
using Fubon_T.ViewModels;

namespace Fubon_T.Services
{
    public interface IMemberService
    {
        Result Register(RegisterViewModel model);
    }
}
