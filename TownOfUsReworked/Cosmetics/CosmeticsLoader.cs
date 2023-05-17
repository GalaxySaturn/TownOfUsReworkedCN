using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TownOfUsReworked.Cosmetics
{
    public static class CosmeticsLoader
    {
        private const string REPO = "https://raw.githubusercontent.com/AlchlcDvl/ReworkedHats/master";
        private static bool HatsRunning;
        private static bool NameplatesRunning;
        private static bool VisorsRunning;
        private static Task FetchHat;
        private static Task FetchNameplate;
        private static Task FetchVisor;
        public readonly static List<CustomNameplates.CustomNameplate> NameplateDetails = new();
        public readonly static List<CustomHats.CustomHat> HatDetails = new();
        public readonly static List<CustomVisors.CustomVisor> VisorDetails = new();

        public static void LaunchFetchers()
        {
            LaunchHatFetcher();
            LaunchNameplateFetcher();
            LaunchVisorFetcher();
        }

        private static void LaunchHatFetcher()
        {
            if (HatsRunning)
                return;

            HatsRunning = true;
            FetchHat = LaunchHatFetcherAsync();
            Utils.LogSomething("Fetched hats");
        }

        private static void LaunchNameplateFetcher()
        {
            if (NameplatesRunning)
                return;

            NameplatesRunning = true;
            FetchNameplate = LaunchNameplateFetcherAsync();
            Utils.LogSomething("Fetched nameplates");
        }

        private static void LaunchVisorFetcher()
        {
            if (VisorsRunning)
                return;

            VisorsRunning = true;
            FetchVisor = LaunchVisorFetcherAsync();
            Utils.LogSomething("Fetched visors");
        }

        private static async Task LaunchHatFetcherAsync()
        {
            try
            {
                var status = await FetchHats();

                if (status != HttpStatusCode.OK)
                    Utils.LogSomething("Custom Hats could not be loaded");
            }
            catch (Exception e)
            {
                Utils.LogSomething("Unable to fetch hats\n" + e.Message);
            }

            HatsRunning = false;
        }

        private static async Task LaunchNameplateFetcherAsync()
        {
            try
            {
                var status = await FetchNameplates();

                if (status != HttpStatusCode.OK)
                    Utils.LogSomething("Custom Nameplates could not be loaded");
            }
            catch (Exception e)
            {
                Utils.LogSomething("Unable to fetch nameplates\n" + e.Message);
            }

            NameplatesRunning = false;
        }

        private static async Task LaunchVisorFetcherAsync()
        {
            try
            {
                var status = await FetchVisors();

                if (status != HttpStatusCode.OK)
                    Utils.LogSomething("Custom Visors could not be loaded");
            }
            catch (Exception e)
            {
                Utils.LogSomething("Unable to fetch visors\n" + e.Message);
            }

            VisorsRunning = false;
        }

        public static async Task<HttpStatusCode> FetchHats()
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.CacheControl = new() { NoCache = true };
            var response = await http.GetAsync(new Uri($"{REPO}/CustomHats.json"), HttpCompletionOption.ResponseContentRead);

            try
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    return response.StatusCode;

                if (response.Content == null)
                {
                    Utils.LogSomething("Server returned no data: " + response.StatusCode.ToString());
                    return HttpStatusCode.ExpectationFailed;
                }

                var json = await response.Content.ReadAsStringAsync();
                var jobj = JObject.Parse(json)["hats"];

                if (jobj == null || jobj?.HasValues == false)
                    return HttpStatusCode.ExpectationFailed;

                var hatdatas = new List<CustomHats.CustomHat>();

                for (var current = jobj.First; current != null; current = current.Next)
                {
                    if (current.HasValues)
                    {
                        var info = new CustomHats.CustomHat
                        {
                            Name = current["name"]?.ToString(),
                            ID = current["id"]?.ToString()
                        };

                        if (info.ID == null || info.Name == null) // required
                            continue;

                        info.BackID = current["backid"]?.ToString();
                        info.ClimbID = current["climbid"]?.ToString();
                        info.FlipID = current["flipid"]?.ToString();
                        info.BackflipID = current["backflipid"]?.ToString();
                        info.Artist = current["artist"]?.ToString();
                        info.Condition = current["condition"]?.ToString();
                        info.NoBouce = current["nobounce"] != null;
                        info.Adaptive = current["adaptive"] != null;
                        info.Behind = current["behind"] != null;
                        hatdatas.Add(info);
                    }
                }

                var markedfordownload = new List<string>();
                var filePath = Path.GetDirectoryName(Application.dataPath) + "\\CustomHats\\";

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                foreach (var data in hatdatas)
                {
                    if (!File.Exists(filePath + data.ID + ".png"))
                        markedfordownload.Add(data.ID);

                    if (data.BackID != null && !File.Exists(filePath + data.BackID + ".png"))
                        markedfordownload.Add(data.BackID);

                    if (data.ClimbID != null && !File.Exists(filePath + data.ClimbID + ".png"))
                        markedfordownload.Add(data.ClimbID);

                    if (data.FlipID != null && !File.Exists(filePath + data.FlipID + ".png"))
                        markedfordownload.Add(data.FlipID);

                    if (data.BackflipID != null && !File.Exists(filePath + data.BackflipID + ".png"))
                        markedfordownload.Add(data.BackflipID);
                }

                foreach (var file in markedfordownload)
                {
                    var hatFileResponse = await http.GetAsync($"{REPO}/hats/{file}.png", HttpCompletionOption.ResponseContentRead);

                    if (hatFileResponse.StatusCode != HttpStatusCode.OK)
                        continue;

                    var responseStream = await hatFileResponse.Content.ReadAsStreamAsync();
                    var fileStream = File.Create($"{filePath}\\{file}");
                    responseStream.CopyTo(fileStream);
                }

                HatDetails.Clear();
                HatDetails.AddRange(hatdatas);
            }
            catch (Exception ex)
            {
                Utils.LogSomething(ex);
            }

            return HttpStatusCode.OK;
        }

        public static async Task<HttpStatusCode> FetchVisors()
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.CacheControl = new() { NoCache = true };
            var response = await http.GetAsync(new Uri($"{REPO}/CustomVisors.json"), HttpCompletionOption.ResponseContentRead);

            try
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    return response.StatusCode;

                if (response.Content == null)
                {
                    Utils.LogSomething("Server returned no data: " + response.StatusCode.ToString());
                    return HttpStatusCode.ExpectationFailed;
                }

                var json = await response.Content.ReadAsStringAsync();
                var jobj = JObject.Parse(json)["visors"];

                if (jobj == null || jobj?.HasValues == false)
                    return HttpStatusCode.ExpectationFailed;

                var visorDatas = new List<CustomVisors.CustomVisor>();

                for (var current = jobj.First; current != null; current = current.Next)
                {
                    if (current.HasValues)
                    {
                        var info = new CustomVisors.CustomVisor
                        {
                            Name = current["name"]?.ToString(),
                            ID = current["id"]?.ToString()
                        };

                        if (info.ID == null || info.Name == null) // required
                            continue;

                        info.FlipID = current["flipid"]?.ToString();
                        info.Artist = current["artist"]?.ToString();
                        info.Condition = current["condition"]?.ToString();
                        info.Adaptive = current["adaptive"] != null;
                        visorDatas.Add(info);
                    }
                }

                var markedfordownload = new List<string>();
                var filePath = Path.GetDirectoryName(Application.dataPath) + "\\CustomVisors\\";

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                foreach (var data in visorDatas)
                {
                    if (!File.Exists(filePath + data.ID + ".png"))
                        markedfordownload.Add(data.ID);

                    if (data.FlipID != null && !File.Exists(filePath + data.FlipID + ".png"))
                        markedfordownload.Add(data.FlipID);
                }

                foreach (var file in markedfordownload)
                {
                    var hatFileResponse = await http.GetAsync($"{REPO}/visors/{file}.png", HttpCompletionOption.ResponseContentRead);

                    if (hatFileResponse.StatusCode != HttpStatusCode.OK)
                        continue;

                    var responseStream = await hatFileResponse.Content.ReadAsStreamAsync();
                    var fileStream = File.Create($"{filePath}\\{file}");
                    responseStream.CopyTo(fileStream);
                }

                VisorDetails.Clear();
                VisorDetails.AddRange(visorDatas);
            }
            catch (Exception ex)
            {
                Utils.LogSomething(ex);
            }

            return HttpStatusCode.OK;
        }

        public static async Task<HttpStatusCode> FetchNameplates()
        {
            var http = new HttpClient();
            http.DefaultRequestHeaders.CacheControl = new() { NoCache = true };
            var response = await http.GetAsync(new Uri($"{REPO}/CustomNameplates.json"), HttpCompletionOption.ResponseContentRead);

            try
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    return response.StatusCode;

                if (response.Content == null)
                {
                    Utils.LogSomething("Server returned no data: " + response.StatusCode.ToString());
                    return HttpStatusCode.ExpectationFailed;
                }

                var json = await response.Content.ReadAsStringAsync();
                var jobj = JObject.Parse(json)["nameplates"];

                if (jobj == null || jobj?.HasValues == false)
                    return HttpStatusCode.ExpectationFailed;

                var namePlateDatas = new List<CustomNameplates.CustomNameplate>();

                for (var current = jobj.First; current != null; current = current.Next)
                {
                    if (current.HasValues)
                    {
                        var info = new CustomNameplates.CustomNameplate
                        {
                            Name = current["name"]?.ToString(),
                            ID = current["id"]?.ToString()
                        };

                        if (info.ID == null || info.Name == null) // required
                            continue;

                        info.Artist = current["artist"]?.ToString();
                        info.Condition = current["condition"]?.ToString();
                        namePlateDatas.Add(info);
                    }
                }

                var markedfordownload = new List<string>();
                var filePath = Path.GetDirectoryName(Application.dataPath) + "\\CustomNameplates\\";

                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                foreach (var data in namePlateDatas)
                {
                    if (!File.Exists(filePath + data.ID + ".png"))
                        markedfordownload.Add(data.ID);
                }

                foreach (var file in markedfordownload)
                {
                    var NameplateFileResponse = await http.GetAsync($"{REPO}/nameplates/{file}.png", HttpCompletionOption.ResponseContentRead);

                    if (NameplateFileResponse.StatusCode != HttpStatusCode.OK)
                        continue;

                    var responseStream = await NameplateFileResponse.Content.ReadAsStreamAsync();
                    var fileStream = File.Create($"{filePath}\\{file}");
                    responseStream.CopyTo(fileStream);
                }

                NameplateDetails.Clear();
                NameplateDetails.AddRange(namePlateDatas);
            }
            catch (Exception ex)
            {
                Utils.LogSomething(ex);
            }

            return HttpStatusCode.OK;
        }
    }
}