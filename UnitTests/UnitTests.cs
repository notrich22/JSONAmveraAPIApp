using JSONAmveraAPIApp.Model.Entities;
using JSONAmveraAPIApp.Services;
using Microsoft.AspNetCore.SignalR.Protocol;
using static JSONAmveraAPIApp.Messages.Messages;

namespace UnitTests
{
    public class Tests
    {
        private IBaseConverter converter;
        private DBLogicService dbLogicService;
        private MainLogicService mainLogicService;
        private ConverterLogicService converterLogicService;
        [SetUp]
        public void Setup()
        {
            converter = new SimpleBaseConverter();
            dbLogicService = new DBLogicService();
            mainLogicService = new MainLogicService();
            converterLogicService = new ConverterLogicService();
        }
        static readonly KnownHost TestEntity = new KnownHost()
        {
            IP = "127.0.0.1",
            UserAgent = "user_agent_test"
        };
        static readonly Request TestRequest= new Request()
        {
            KnownHost = new KnownHost()
            {
                IP = "127.0.0.1",
                UserAgent = "user_agent_test"
            },
            isHttps = false,
            Path = "/test"
        };
        const string newUserCheckIP = "newUserIp";
        const string newIP = "updateTest";
        const string updateTestString = "/test_update";
        KnownHost returnedHost { get;set; }
        Request returnedRequest { get;set; }

        [Test]
        public async Task KnownHostTests()
        {
            //KnownHosts CRUD test
            returnedHost = await dbLogicService.AddHost(TestEntity);

            Assert.IsNotNull(returnedHost);
            Assert.That(returnedHost.IP, Is.EqualTo(TestEntity.IP));
            Assert.That(returnedHost.UserAgent, Is.EqualTo(TestEntity.UserAgent));

            Assert.DoesNotThrowAsync(dbLogicService.GetHosts);
            Assert.DoesNotThrowAsync(async () => await dbLogicService.isUserNew(newUserCheckIP));
            Assert.DoesNotThrowAsync(async () => await dbLogicService.isUserNew(TestEntity.IP));
            Assert.DoesNotThrowAsync(async () => await dbLogicService.GetHostByÌP(TestEntity.IP));
            Assert.DoesNotThrowAsync(async () => await dbLogicService.GetHost(returnedHost.Id));

            TestEntity.IP = newIP;
            var tempHost = await dbLogicService.UpdateHost(returnedHost.Id, TestEntity);
            Assert.IsNotNull(tempHost);
            Assert.That(tempHost.IP, Is.EqualTo(newIP));
            Assert.DoesNotThrowAsync(async () => await dbLogicService.DeleteHost(tempHost.Id));

        }
        [Test]
        public async Task RequestsTests()
        {
            //Requests CRUD test
            returnedRequest = await dbLogicService.AddRequest(TestRequest.KnownHost.IP, TestRequest);

            Assert.IsNotNull(returnedRequest);
            Assert.That(TestRequest.KnownHost.IP, Is.EqualTo(returnedRequest.KnownHost.IP));
            Assert.That(TestRequest.KnownHost.UserAgent, Is.EqualTo(returnedRequest.KnownHost.UserAgent));
            Assert.That(TestRequest.isHttps, Is.EqualTo(returnedRequest.isHttps));
            Assert.That(TestRequest.Path, Is.EqualTo(returnedRequest.Path));

            Assert.DoesNotThrowAsync(dbLogicService.GetRequests);
            Assert.DoesNotThrowAsync(async () => await dbLogicService.GetRequest(returnedRequest.Id));
            Assert.DoesNotThrowAsync(async () => await dbLogicService.GetRequestsByHost(returnedRequest.KnownHost.IP));

            TestRequest.Path = updateTestString;
            //TODO
            returnedRequest = await dbLogicService.UpdateRequest(returnedRequest.Id, TestRequest);
            Assert.IsNotNull(returnedRequest);
            Assert.That(returnedRequest.Path, Is.EqualTo(updateTestString));
            Assert.DoesNotThrowAsync(async () => { await dbLogicService.DeleteRequest(returnedRequest.Id); });
        }
        [Test]
        public void MainLogicServiceTest()
        {
            Assert.DoesNotThrowAsync(mainLogicService.GetServerInfo);
            Assert.DoesNotThrowAsync(mainLogicService.GetServerStatus);
        }
        [Test]
        public void ConverterLogicServiceTest()
        {
            ConvertOutputMessage outConv = converterLogicService.Convert(new ConvertInputMessage("256", 10, 2), converter);
            Assert.IsNotNull(outConv);
            Assert.That(outConv.Result, Is.EqualTo("100000000"));
        }
        [Test]
        public void ConverterTest()
        {
            ConvertInputMessage message = new ConvertInputMessage("256", 10, 2);
            ConvertOutputMessage outMessage = converter.ConvertBase(message);
            Assert.IsNotNull(outMessage);
            Assert.That(outMessage.Result, Is.EqualTo("100000000"));
        }
    }
}