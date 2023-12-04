using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CadastroDevs.Dto
{
    public class DevResponseDto
    {

        //[JsonPropertyName("CreatedAt")]
        //public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        //[JsonPropertyName("Avatar")]
        //public string Avatar { get; set; }

        [JsonPropertyName("Squad")]
        public string Squad { get; set; }

        [JsonPropertyName("Login")]
        public string Login { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("Tag")]
        public string Tag { get; set; }

        //[JsonPropertyName("Avatar_url")]
        //public string AvatarUrl { get; set; }
    }
}
