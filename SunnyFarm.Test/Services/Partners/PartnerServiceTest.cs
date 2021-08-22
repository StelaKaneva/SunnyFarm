namespace SunnyFarm.Test.Services.Partners
{
    using SunnyFarm.Data;
    using SunnyFarm.Data.Models;
    using SunnyFarm.Services.Partners;
    using SunnyFarm.Test.Mocks;
    using Xunit;

    public class PartnerServiceTest
    {
        private const string UserId = "TestUserId";

        [Fact]
        public void IsPartnerShouldReturnTrueWhenUserIsPartner()
        {
            //Arrange
            var partnerService = GetPartnerService();

            //Act
            var result = partnerService.IsPartner(UserId);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPartnerShouldReturnFalseWhenUserIsNotPartner()
        {
            //Arrange
            var partnerService = GetPartnerService();

            //Act
            var result = partnerService.IsPartner("AnotherUserId");

            //Assert
            Assert.False(result);
        }

        private static IPartnerService GetPartnerService()
        {
            var data = DatabaseMock.Instance;

            data.Partners.Add(new Partner { UserId = UserId });
            data.SaveChanges();

            return new PartnerService(data);
        }
    }
}
