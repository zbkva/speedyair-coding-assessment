using Newtonsoft.Json;

public class Order
{
    [JsonProperty("destination")]
    public string Destination { get; set; }
}