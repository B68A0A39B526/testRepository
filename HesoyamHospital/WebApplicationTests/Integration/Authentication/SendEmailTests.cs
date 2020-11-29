using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;
using System.Collections.Generic;
using System.Net;
using WebApplication;
using System.Net.Http;
using Backend.Util;
using System.Text;
using Xunit;
using Newtonsoft.Json;
using WebApplication.Authentication;
using Moq;

namespace WebApplicationTests.Integration.Authentication
{
    public class SendEmailTests
    {
        [Fact]
        public void Sends_email_for_account_activation()
        {
            var sendEmail = new Mock<ISendEmail>();
            var controller = new RegistrationController(sendEmail.Object);

            controller.Add(new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", new SendEmail().RandomString(10, false), "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "033244377", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4"));

            sendEmail.Verify(n => n.SendActivationEmail(It.IsAny<long>(), It.IsAny<string>()), Times.Once);
        }
    }
}
