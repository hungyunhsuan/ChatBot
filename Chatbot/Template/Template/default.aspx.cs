using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Template
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "b+Ig65GIZu0O3cLDADGj9Ryl3n+EH/Kz2FqmKoO83Ex4iiHByFkfaQcV6sPjT+mNdxgrcR6Lwrh20q91R//rphzyhb0nry2A9YbsD3bCafiS72Kok43ddoWf9rB6Knz9OE52W1cxOWJZfSqCbBm1zQdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U29d6cb64144a5157c8b8363817618240";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new Bot(channelAccessToken);
            var actions = new List<isRock.LineBot.TemplateActionBase>();

            actions.Add(new isRock.LineBot.MessageAction() { label = "標題-文字回覆", text = "回覆文字" });

            // actions.Add(new isRock.LineBot.UriAction() { label = "標題-開啟URL", uri = new Uri("http://www.google.com") });

            actions.Add(new isRock.LineBot.DateTimePickerAction() { label = "選擇日期", mode = "datetime" });

            actions.Add(new isRock.LineBot.PostbackAction() { label = "標題-發生postack", data = "abc=aaa&def=111" });

            var ButtonTemplate = new isRock.LineBot.ButtonsTemplate()

            {

               

                title = "檢視",

                text ="請選擇其中之一" ,

                altText = "請在手機上檢視" ,

                thumbnailImageUrl = new Uri("https://github.com/hungyunhsuan/JS/blob/master/readmeimage/bg-pic.png?raw=true"),

                actions = actions //設定回覆動作

            };

            //發送

            bot.PushMessage(AdminUserId, ButtonTemplate);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            var actions = new List<isRock.LineBot.TemplateActionBase>();

            actions.Add(new isRock.LineBot.MessageAction() { label = "YES", text = "YES" });
            actions.Add(new isRock.LineBot.MessageAction() { label = "NO", text = "NO" });



            var ConfirmTemplate = new isRock.LineBot.ConfirmTemplate()

            {

                text = "請選擇其中之一",

                altText = "請在手機上檢視",

                actions = actions 

            };

            //發送

            bot.PushMessage(AdminUserId, ConfirmTemplate);

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);


            var actions = new List<isRock.LineBot.TemplateActionBase>();

            actions.Add(new isRock.LineBot.MessageAction() { label = "標題-文字回覆", text = "回覆文字" });

            //actions.Add(new isRock.LineBot.UriAction() { label = "標題-Google", uri = new Uri("http://www.google.com") });

            actions.Add(new isRock.LineBot.DateTimePickerAction() { label = "請選擇時間", mode = "datetime" });

            actions.Add(new isRock.LineBot.PostbackAction() { label = "標題-發生postack", data = "abc=aaa&def=111" });



            var Column = new isRock.LineBot.Column()

            {

                text = "請選擇其中之一",

                title = "檢視",


                thumbnailImageUrl = new Uri("https://arock.blob.core.windows.net/blogdata201706/22-124357-ad3c87d6-b9cc-488a-8150-1c2fe642d237.png"),

                actions = actions 

            };




            var CarouselTemplate = new isRock.LineBot.CarouselTemplate();




            CarouselTemplate.columns.Add(Column);

            CarouselTemplate.columns.Add(Column);

            CarouselTemplate.columns.Add(Column);


            bot.PushMessage(AdminUserId, CarouselTemplate);
        }
    }
}