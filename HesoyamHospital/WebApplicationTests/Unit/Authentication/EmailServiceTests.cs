using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Authentication;
using Xunit;

namespace WebApplicationTests.Unit.Authentication
{
    public class EmailServiceTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Token_to_id(string token, long id)
        {
            long patientId = new SendEmail().TokenToId(token);

            patientId.ShouldBe(id);
        }

        [Fact]
        public void Id_to_token_to_id()
        {
            long patientId = new SendEmail().TokenToId(new SendEmail().CreateToken(35));

            patientId.ShouldBe(35);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { "xD3gRfdE349oO0PwcDEi35", 35 },
            new object[] { "xD3cDEi35", 0 },
            new object[] { "xD3gRfdE349oO0PwcDEi35w", 0 }
        };
    }
}
