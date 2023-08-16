using ClashRoyaleApiBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ClashRoyaleApiBackend.Services
{
    public class RoyaleAPIService
    {
        private readonly HttpClient _httpClient;

        public RoyaleAPIService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Players> GetMembersOfClan(string clanTag)
        {
            var url = $"https://api.clashroyale.com/v1/clans/%23{clanTag}/members?limit=100";
            var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6Ijg2ZTYxNGYyLTljNGUtNGY0NS04NDgzLTExMWU1YTQ2MDZhMiIsImlhdCI6MTY5MjIxMTgxMSwic3ViIjoiZGV2ZWxvcGVyLzc0ZDBkZDAxLWJmZDgtYWNkYy01ZjM3LTVhM2VhZjM1ZWNhOCIsInNjb3BlcyI6WyJyb3lhbGUiXSwibGltaXRzIjpbeyJ0aWVyIjoiZGV2ZWxvcGVyL3NpbHZlciIsInR5cGUiOiJ0aHJvdHRsaW5nIn0seyJjaWRycyI6WyIyMTIuOTUuNS4yMDIiXSwidHlwZSI6ImNsaWVudCJ9XX0.oC3tLIDZ8XMcD0Aoxw-NiJA9MKUJX6v9L1iBQk6z_22rdUGoAyaNANy_KE96BwoqH9FKyJCVJTOaYrC56vo98A";

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var players = await response.Content.ReadFromJsonAsync<Players>();
                if (players == null) return new Players();

                return players;
            }

            return new Players();
        }
    }
}
