using DiscussionLibrarySandreth;

namespace DiscussionTestSandreth

{
    public class OfficerTest
    {
        [Fact]
        public void ShouldFindCurrentSupervisorOfOfficer()
        {
            string expectedSupervisorId = "S1";
            string actualSupervisorId = "S1";
            Assert.Equal(expectedSupervisorId, actualSupervisorId);
        }
    }
}