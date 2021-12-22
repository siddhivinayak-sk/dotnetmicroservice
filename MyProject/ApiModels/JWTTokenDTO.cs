using System;

namespace MyProject.ApiModels
{
    public class JWTTokenDTO
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }
    }
}
