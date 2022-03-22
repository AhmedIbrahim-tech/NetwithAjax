using Core.Models;

namespace Web.ViewModel
{
    public class CountryCityVM
    {
        public int CountryId { get; set; }
        public List<Country> Countries { get; set; }
    }
}