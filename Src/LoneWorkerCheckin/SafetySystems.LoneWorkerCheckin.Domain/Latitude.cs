namespace SafetySystems.LoneWorkerCheckin.Domain;

public record Latitude(double Value)
{
    public override string ToString() => Value.ToString();
}
