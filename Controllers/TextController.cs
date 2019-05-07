using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Texting.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Texting.Controllers
{
    public class TextController : Controller
    {
        public IActionResult Index()
        {
            var formModel = new SendTextFormModel();
            return View(formModel);
        }
        
        [HttpPost]
        public IActionResult Send(SendTextFormModel formModel)
        {
            if (formModel.PhoneNumber != null && formModel.TextMessage != null)
            {
                if (!formModel.PhoneNumber.StartsWith("+1"))
                {
                    formModel.PhoneNumber = "+1" + formModel.PhoneNumber;
                }

                var accountSid = Environment.GetEnvironmentVariable("sid");
                var authToken = Environment.GetEnvironmentVariable("token");
                
                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    from: new Twilio.Types.PhoneNumber("+16677716661"),
                    body: formModel.TextMessage,
                    to: new Twilio.Types.PhoneNumber(formModel.PhoneNumber)
                );

                return View(message);
            }

            return View();
        }
    }
}