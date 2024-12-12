using DiscussionLibrarySandreth;

namespace DiscussionTestSandreth
{
    public class ServiceRequestTest
    {
        [Fact]
        public void TestEqualAndEquilvalent()
        {
            Vehicle vehicle1 = new Vehicle { VehicleId = 1 };
            Vehicle vehicle2 = new Vehicle { VehicleId = 1 };
            Vehicle vehicle3 = vehicle1;


            Assert.Equivalent(vehicle1, vehicle2);

            Officer officer1 = new Officer { Id = "01" };
            Officer officer2 = new Officer { Id = "01" };


            //Assert.Equivalent(officer1, officer2);

        }

        [Fact]

        public void ShouldSearchServiceRequests()
        {
            //AAA patern testing; agile dev (scrum) - Test Driven Dev (TDD) - Test first dev (red - green)

            //1. A - Arrange (Setup)
            //Optional Criteria : 1. ServiceRequestStatus (pending), 2. DateRequestMade (made in Noc)
            List<ServiceRequest> inputServiceRequests = CreateTestData();
            ServiceRequestStatusOptions? inputServiceRequestStatus = null;
            DateTime? inputStartDateRequestMade = null;
            DateTime? inputEndDateRequestMade = null;
            List<ServiceRequest> outputServiceRequests = new List<ServiceRequest>();
            int expectedNumberOfServiceRequests = 4;


            //2. Act
            outputServiceRequests = ServiceRequest.SearchServiceRequests(inputServiceRequests, inputServiceRequestStatus,
                   inputStartDateRequestMade, inputEndDateRequestMade);


            //3. Assert
            Assert.Equal(expectedNumberOfServiceRequests, outputServiceRequests.Count);


            //2.1 Arrange
            inputServiceRequestStatus = ServiceRequestStatusOptions.Pending;
            expectedNumberOfServiceRequests = 3;


            //2.2 Act
            outputServiceRequests = ServiceRequest.SearchServiceRequests(inputServiceRequests, inputServiceRequestStatus,
               inputStartDateRequestMade, inputEndDateRequestMade);




            //2.3 Assert
            Assert.Equal(expectedNumberOfServiceRequests, outputServiceRequests.Count);


            //3.1
            inputStartDateRequestMade = new DateTime(2024, 11, 1); 
            inputEndDateRequestMade = new DateTime(2024, 11, 30); 
            expectedNumberOfServiceRequests = 2;

            //3.2
            outputServiceRequests = ServiceRequest.SearchServiceRequests(inputServiceRequests, inputServiceRequestStatus, 
                inputStartDateRequestMade, inputEndDateRequestMade);


            //3.3
            Assert.Equal(expectedNumberOfServiceRequests, outputServiceRequests.Count);


        }

        public List<ServiceRequest> CreateTestData()
        {
            List<ServiceRequest> testServiceRequests = new List<ServiceRequest>();

            //Pending -2, Nov -2, Dec -1, Denied - 1

            ServiceRequest serviceRequest =
                new ServiceRequest
                {
                    ServiceRequestId = 1,
                    ServiceRequestStatus = ServiceRequestStatusOptions.Pending,
                    DateRequestMade = new DateTime(2024, 11, 1)
                };
            testServiceRequests.Add(serviceRequest);

            serviceRequest =
                new ServiceRequest
                {
                    ServiceRequestId = 2,
                    ServiceRequestStatus = ServiceRequestStatusOptions.Pending,
                    DateRequestMade = new DateTime(2024, 11, 15)
                };
            testServiceRequests.Add(serviceRequest);

            serviceRequest =
                new ServiceRequest
                {
                    ServiceRequestId = 3,
                    ServiceRequestStatus = ServiceRequestStatusOptions.Pending,
                    DateRequestMade = new DateTime(2024, 12, 1)
                };
            testServiceRequests.Add(serviceRequest);
            serviceRequest = new ServiceRequest 
            {
                ServiceRequestId = 4, 
                ServiceRequestStatus = ServiceRequestStatusOptions.Denied, 
                DateRequestMade = new DateTime(2024, 11, 3) }; 
            testServiceRequests.Add(serviceRequest);


            return testServiceRequests;
        }




    }
}
