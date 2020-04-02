using Microsoft.AspNetCore.Hosting;
using ScattyApp.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ScattyApp.Web.Services
{
    public class JsonFileEventService
    {
        public JsonFileEventService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "events.json"); }
        }

        public IEnumerable<Event> GetEvents()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                options.Converters.Add(new DateTimeOffsetConverter());

                // Debug.WriteLine(jsonFileReader.ReadToEnd());

                return JsonSerializer.Deserialize<Event[]>(jsonFileReader.ReadToEnd(),
                    options);
            }
        }

        public void AddCompleted(long id)
        {
            var events = GetEvents();

            if (events.First(x => x.Id == id).CompletedDate == null)
            {
                // TODO
                // events.First(x => x.Id == id).CompletedDate = DateTime.Now;
                events.First(x => x.Id == id).CompletedBy = "Web";
            }

            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Event>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    events
                );
            }
        }
    }
}