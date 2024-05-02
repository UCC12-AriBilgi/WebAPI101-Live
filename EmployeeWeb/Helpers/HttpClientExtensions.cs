using System.Text.Json;


namespace EmployeeWeb.Helpers
{
    public static class HttpClientExtensions
    {
        // HttpClient işlemleri sonucu diğer taraftan gelecek olan veriyi çözümleyecek olan bölüm. Çünkü geri planda JSON formatında veriler gidip/geleceği için

        public static async Task<T> ReadContentAsync<T> (this HttpResponseMessage response)
        {
            // Bana API tarafından gönderilen cevap(response) uygun durumda mı diye kontrol işlemi yapacak

            if (response.IsSuccessStatusCode == false)
            {
                throw new ApplicationException($"API çağrılırken problem oluştu : {response.ReasonPhrase}");
            }

            // Eğer duryum uygunsa API tarafından gönderilen bilgi okunacak.

            var dataAsString=await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            // Bu veri şu an bildiğimiz text formatında. Bunu JSON formatına dönüştürmemiz lazım.

            var result = JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            // Json formatına döndürüldü

            return result;
                
        }


    }
}
