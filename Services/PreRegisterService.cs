using oneGoNclex.DAL;
using oneGoNclex.Model;

namespace oneGoNclex.Services
{
    public class PreRegisterService
    {
        public static bool Add(PreRegisterViewModel entity)
        {
            return PreregisterData.Add(entity);
        }
    }
}