using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AES_Blazor.Client.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace AES_Blazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PaymentResponse> Post([FromBody] CardModel model)
        {
            var keysize = Aes.KeySize.Bits256;

            byte[] plainText = new byte[16];
            byte[] cipherText = new byte[16];

            plainText = Encoding.Unicode.GetBytes(model.CardCvc.ToString().PadRight(8, ' '));
            var aes = new Aes(keysize, new byte[16]);
            aes.InvCipher(plainText, cipherText);

            var response = Encoding.Unicode.GetString(cipherText);
            return Ok(new PaymentResponse() { Message = "CardCvc plainText : " + model.CardCvc + " cipherText : " + response, Error = model.CardCvc }) ;
        }
    }
}
