namespace EfCrossDbSample.Controllers;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string CountryName { get; set; } = default!;
}
