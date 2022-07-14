namespace EfCrossDbSample;

public class Customer
{
    public Guid Id { get; set; }
    public Guid? CountryId { get; set; }
    public string Name { get; set; } = default!;

    public Country Country { get; set; } = default!;
}
