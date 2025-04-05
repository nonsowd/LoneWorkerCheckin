namespace SafetySystems.LoneWorkerCheckin.Domain;

public record Longitude (double Value)
{
    public override string ToString() => Value.ToString();
}
