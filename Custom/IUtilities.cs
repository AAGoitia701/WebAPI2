using WebAPI2.Models;

namespace WebAPI2.Custom
{
    public interface IUtilities
    {
        public string EncryptingSHA256(string text);
        public string GenerateToken(MainUser userModel);
    }
}
