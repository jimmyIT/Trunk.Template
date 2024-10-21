using Microsoft.AspNetCore.Identity;

namespace Template.Trunk.Shared.Cryptography;

public interface IHasher
{
    /// <summary>
    /// One-way hashed string with 16 byte array salt password using HMACSHA256.
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    string GetHash(string password, string salt);

    /// <summary>
    /// To validate password.
    /// </summary>
    /// <param name="hashedPassword"></param>
    /// <param name="providedPassword"></param>
    /// <returns></returns>
    PasswordVerificationResult VerifyHash(string hashedPassword, string providedPassword);
}

public class Hasher : IHasher
{
    private readonly IPasswordHasher<object> _passwordHasher;
    public Hasher(IPasswordHasher<object> passwordHasher)
        => _passwordHasher = passwordHasher;

    public string GetHash(string password, string salt) => _passwordHasher.HashPassword(new { }, $"{salt}{password}");

    public PasswordVerificationResult VerifyHash(string hashedPassword, string providedPassword)
        => _passwordHasher.VerifyHashedPassword(new { }, hashedPassword, providedPassword);
}
