using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Sibelius.Web.Integration
{
    public static class ReCaptcha
    {
        // KEYS
        public static readonly string PublicReCaptchaKey = 
            Environment.GetEnvironmentVariable("APPSETTING_RECAPTCHA_PUBLIC");
        private static readonly string PrivateReCaptchaKey = 
            Environment.GetEnvironmentVariable("APPSETTING_RECAPTCHA_SECRET");

        // Validation URL
        public static string ReCaptchaURL = 
            "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";

        // Params
        public const string CaptchaParam = "captcha";
        public const string RequestParam = "g-recaptcha-response";
                
        public static bool Validate(string captchaResponse)
        {
            try
            {
                using (var client = new WebClient())
                {
                    JObject jObject = JObject.Parse(client.DownloadString(string.Format(ReCaptchaURL, PrivateReCaptchaKey, captchaResponse)));
                    return (bool)jObject["success"];
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}