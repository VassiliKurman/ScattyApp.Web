using System.Text.Json;
using System.Text.Json.Serialization;

namespace ScattyApp.Web.Models
{  
    public class Event
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Place { get; set; }
        // [JsonConverter(typeof(DateTimeOffsetConverter))]
        // public DateTimeOffset Date { get; set; }
        public string Date { get; set; }
        public int Type { get; set; }
        public string Person { get; set; }
        public string Contact { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
        public int Status { get; set; }
        [JsonPropertyName("created_date")]
        // [JsonConverter(typeof(DateTimeOffsetConverter))] 
        // public DateTimeOffset CreatedDate { get; set; }
        public string CreatedDate { get; set; }
        [JsonPropertyName("created_by")]
        public string CreatedBy { get; set; }
        [JsonPropertyName("completed_date")]
        // [JsonConverter(typeof(DateTimeOffsetConverter))] 
        // public DateTimeOffset CompletedDate { get; set; }
        public string CompletedDate { get; set; }
        [JsonPropertyName("completed_by")]
        public string CompletedBy { get; set; }
        [JsonPropertyName("canceled_date")]
        // [JsonConverter(typeof(DateTimeOffsetConverter))] 
        // public DateTimeOffset CanceledDate { get; set; }
        public string CanceledDate { get; set; }
        [JsonPropertyName("canceled_by")]
        public string CanceledBy { get; set; }
        [JsonPropertyName("deleted_date")]
        // [JsonConverter(typeof(DateTimeOffsetConverter))] 
        // public DateTimeOffset DeletedDate { get; set; }
        public string DeletedDate { get; set; }
        [JsonPropertyName("deleted_by")]
        public string DeletedBy { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Event>(this);
    }
}