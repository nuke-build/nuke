using Nuke.Common.Git.Url.Building;
using Xunit;

namespace Nuke.Common.Tests.Git.Url.Building
{
    public class GitUrlCreatorTest
    {
        [Fact]
        public void GitUrlWithoutPrefix_HttpsUrlGiven_ReturnSshOne()
        {
            // Arrange
            var creator = new GitUrlCreater();

            // Act
            var url = creator.GitUrlWithoutPrefix(creator.From(@"https://github.com/nuke-build/nuke.git"));

            //Assert
            Assert.Equal("git@github.com:nuke-build/nuke.git", url);
        }

        [Fact]
        public void HttpsUrlFrom_SshUrlGiven_ReturnHttpsOne()
        {
            // Arrange
            var creator = new GitUrlCreater();

            // Act
            var url = creator.HttpsUrlFrom(creator.From(@"ssh://github.com/nuke-build/nuke.git"));

            //Assert
            Assert.Equal(@"https://github.com/nuke-build/nuke.git", url);
        }
    }
}
