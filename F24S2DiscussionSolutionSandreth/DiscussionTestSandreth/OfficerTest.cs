using DiscussionLibrarySandreth;

namespace DiscussionTestSandreth

{
    public class OfficerTest
    {
        [Fact]
        public void ShouldFindCurrentSupervisorOfOfficer()
        {
            //AAA

            //Arrange (Set up)
            string expectedSupervisorId = "S2";
            Supervisor actualSupervisor = null;
            //Officer officer = new Officer();
            List<Officer> testOfficers = CreateTestData();


            //Action
            actualSupervisor = testOfficers[0].FindCurrentSupervisorOfOfficer();

            //Assert
            Assert.Equal(expectedSupervisorId, actualSupervisor.Id);


        }//end of method ShouldFindCurrentSupervisorOfOfficer

        public List<Officer> CreateTestData()
        {
            List<Officer> testOfficers = new List<Officer>();

            Officer testOfficer = new Officer { Id = "01" };
            testOfficers.Add(testOfficer);
            testOfficer = new Officer { Id = "02" };
            testOfficers.Add(testOfficer);

            List<Supervisor> testSupervisors = new List<Supervisor>();

            Supervisor testSupervisor = new Supervisor { Id = "S1" };
            testSupervisors.Add(testSupervisor);
            testSupervisor = new Supervisor { Id = "S2" };
            testSupervisors.Add(testSupervisor);


            //S1 supervises 01 12/4/2023
            DateTime startDate = DateTime.Now.AddYears(-1);
            Supervises supervises = new Supervises(testOfficers[0], testSupervisors[0], startDate);
            //end S1, 01 on 12/3/2024
            supervises.EndDate = DateTime.Now.AddDays(-1);
            testOfficers[0].SupervisorsOfOfficer.Add(supervises);
            testSupervisors[0].OfficersSupervised.Add(supervises);


            startDate = DateTime.Now;
            supervises = new Supervises(testOfficers[0], testSupervisors[1], startDate);
            //starts S2, 01 on 12/4/2024
            //supervises.EndDate = DateTime.Now.AddDays(-1);
            testOfficers[0].SupervisorsOfOfficer.Add(supervises);
            testSupervisors[1].OfficersSupervised.Add(supervises);


            //S2 supervises 02, starting on  12/4/2022
            startDate = DateTime.Now.AddYears(-2);
            supervises = new Supervises(testOfficers[1], testSupervisors[1], startDate);
            //end S2, 02 on 12/4/2024
            supervises.EndDate = DateTime.Now.AddMonths(-1);
            testOfficers[1].SupervisorsOfOfficer.Add(supervises);
            testSupervisors[1].OfficersSupervised.Add(supervises);


            startDate = DateTime.Now.AddMonths(-1).AddDays(1);
            supervises = new Supervises(testOfficers[1], testSupervisors[0], startDate);
            //starts S1, 02 on 11/5/2024
            //supervises.EndDate = DateTime.Now.AddDays(-1);
            testOfficers[1].SupervisorsOfOfficer.Add(supervises);
            testSupervisors[0].OfficersSupervised.Add(supervises);






            return testOfficers;

        }//end CreateTestData method

    }//end class OfficerTest


}//end namespace