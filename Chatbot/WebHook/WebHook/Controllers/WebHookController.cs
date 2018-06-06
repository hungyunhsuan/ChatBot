using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebHook.Controllers
{
    public class WebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "b+Ig65GIZu0O3cLDADGj9Ryl3n+EH/Kz2FqmKoO83Ex4iiHByFkfaQcV6sPjT+mNdxgrcR6Lwrh20q91R//rphzyhb0nry2A9YbsD3bCafiS72Kok43ddoWf9rB6Knz9OE52W1cxOWJZfSqCbBm1zQdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "U29d6cb64144a5157c8b8363817618240";

        [Route("api/LineBot")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
               
                this.ChannelAccessToken = channelAccessToken;
                
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "text") //收到文字
                        this.ReplyMessage(LineEvent.replyToken, "你說了:" + LineEvent.message.text);
                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                    if (LineEvent.message.type == "location") //GPS
                        this.ReplyMessage(LineEvent.replyToken,$"你的位置在 \n{LineEvent.message.latitude} , {LineEvent.message.longitude}");
                    if (LineEvent.message.type == "image") //image
                    {
                        var bytes = this.GetUserUploadedContent(LineEvent.message.id);
                        var guild = Guid.NewGuid().ToString();
                        var filename = $"{guild}.png";
                        var path = System.Web.Hosting.HostingEnvironment.MapPath("~/temp/");
                        System.IO.File.WriteAllBytes(path + filename, bytes);
                        var baseUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
                        var url = $"{baseUrl}/temp/{filename}";
                        this.ReplyMessage(LineEvent.replyToken, $"你的圖片位置在 \n {url}");

                    }

                   
                    //this.ReplyMessage(LineEvent.replyToken, "你的USERid是:" + LineEvent.source.userId);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
