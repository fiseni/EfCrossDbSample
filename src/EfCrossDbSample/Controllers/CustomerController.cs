using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCrossDbSample.Controllers;

[ApiController]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public CustomerController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("/customers/option1")]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomersOption1(CancellationToken cancellationToken)
    {
        var result = _dbContext.Customers
            .Select(x => new CustomerDto
            {
                Id = x.Id,
                Name = x.Name,
                CountryName = x.Country.Name
            });

        return await result.ToListAsync(cancellationToken);
    }

    [HttpGet("/customers/option2")]
    public async Task<ActionResult<List<CustomerDto>>> GetCustomersOption2(CancellationToken cancellationToken)
    {
        var result = from customer in _dbContext.Customers
                      join country in _dbContext.Countries on customer.CountryId equals country.Id
                      select new CustomerDto
                      {
                          Id = customer.Id,
                          Name = customer.Name,
                          CountryName = country.Name
                      };

        return await result.ToListAsync(cancellationToken);
    }
}
