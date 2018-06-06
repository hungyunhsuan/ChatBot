using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebHook
{
    public partial class Userid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot("b+Ig65GIZu0O3cLDADGj9Ryl3n+EH/Kz2FqmKoO83Ex4iiHByFkfaQcV6sPjT+mNdxgrcR6Lwrh20q91R//rphzyhb0nry2A9YbsD3bCafiS72Kok43ddoWf9rB6Knz9OE52W1cxOWJZfSqCbBm1zQdB04t89/1O/w1cDnyilFU=");
            bot.PushMessage("U29d6cb64144a5157c8b8363817618240", DateTime.Now.ToString());
            var userinfo = bot.GetUserInfo("U29d6cb64144a5157c8b8363817618240");
            Response.Write(userinfo.displayName + "<br/>" + userinfo.statusMessage);
        }
    }
}