using Nuke.Common.Git.Url.Model;
using Xunit;

namespace Nuke.Common.Tests.Git.Url
{
    public class GitUrlTest
    {
        [Fact]
        public void Url_ParametersValid_CorrectUrlReturned()
        {
            // Arrange
            var url = new GitUrl("github.com", "repo", GitProtocol.https);
            // Act
            // Assert
            Assert.Equal(@"https://github.com/repo.git", url.Url);
        }
    }
}
