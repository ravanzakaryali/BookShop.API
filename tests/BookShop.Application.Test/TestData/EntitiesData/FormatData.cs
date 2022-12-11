using BookShop.Application.CQRS.Commands.Request.FormatRequest;

namespace BookShop.Application.Test.TestData.EntitiesData;

public class FormatData
{
    public static IEnumerable<FormatCreateRequest[]> FormatCreateRequests
    {
        get
        {
            yield return new FormatCreateRequest[]
            {
                new FormatCreateRequest(new string('A',65))
            };
            yield return new FormatCreateRequest[]
            {
                new FormatCreateRequest(new string('A',1))
            };
            yield return new FormatCreateRequest[]
            {
                new FormatCreateRequest("")
            };
            yield return new FormatCreateRequest[]
            {
                new FormatCreateRequest(" ")
            };
        }
    }
}
