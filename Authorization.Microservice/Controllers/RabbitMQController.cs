using Authorization.Microservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Authorization.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMQController : ControllerBase
    {
       
        [HttpGet]
        [Route("GetMessRabbitmqForADMIN_QUEUE")]
        public IActionResult GetMessRabbitmqForADMIN_QUEUE()
        {
            var message_list = new List<string>();
            var msgsRecievedGate = new ManualResetEventSlim(false);

            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq"
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var response= channel.QueueDeclare("admin_microservice", exclusive: false);
            //Set Event object which listen message from chanel which is sent by producer
            var consumer = new EventingBasicConsumer(channel);

            var msgCount = response.MessageCount;
            var msgRecieved = 0;

            consumer.Received += (model, eventArgs) => {
                msgRecieved++;
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                message_list.Add(message);
                //  Console.WriteLine(message);
                if (msgRecieved == msgCount)
                {
                    // Set signal here
                    msgsRecievedGate.Set();

                    // exit function 
                    return;
                }
            };
            //read the message
            channel.BasicConsume(queue: "admin_microservice", autoAck: true, consumer: consumer);
            // Wait here until all messages are retrieved
            msgsRecievedGate.Wait();

            return Ok(message_list);
        }



        [HttpGet]
        [Route("GetMessRabbitmqForUSER_QUEUE")]
        public IActionResult GetMessRabbitmqForUSER_QUEUE()
        {
            var message_list = new List<string>();
            var msgsRecievedGate = new ManualResetEventSlim(false);

            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq"
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var response = channel.QueueDeclare("user_microservice", exclusive: false);
            //Set Event object which listen message from chanel which is sent by producer
            var consumer = new EventingBasicConsumer(channel);

            var msgCount = response.MessageCount;
            var msgRecieved = 0;

            consumer.Received += (model, eventArgs) => {
                msgRecieved++;
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                message_list.Add(message);
                //  Console.WriteLine(message);
                if (msgRecieved == msgCount)
                {
                    // Set signal here
                    msgsRecievedGate.Set();

                    // exit function 
                    return;
                }
            };
            //read the message
            channel.BasicConsume(queue: "user_microservice", autoAck: true, consumer: consumer);
            // Wait here until all messages are retrieved
            msgsRecievedGate.Wait();

            return Ok(message_list);
        }
    }
}
