using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Bot.Sample.LuisBot;
using Microsoft.Bot.Builder.Dialogs;
using System.Diagnostics;
using Microsoft.Rest;

namespace Microsoft.Bot.Sample.LuisBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {

        ////TOP Menu


        public List<string> getcustomer1List()
        {
            List<string> MenuList = new List<string>();
            MenuList.Add("解決した");
            MenuList.Add("解決していない");
            return MenuList;
        }

        public List<string> getcustomer2List(int Menu1Select)
        {
            List<string> MenuList = new List<string>();
            //if (Menu1Select == 1)
            //{
                MenuList.Add("電話で対応してほしい");
                MenuList.Add("メールで対応してほしい");
            //}
            return MenuList;
        }


        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                //Connectorからのデータ入出力
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                //State管理
                StateClient stateClient = activity.GetStateClient();

                try
                {
                    BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);

                    //UserDataの取り出し（セッションデータの取り出し）
                    bool SentGreeting = userData.GetProperty<bool>("SentGreeting");
                    string SentGreetingTime = userData.GetProperty<string>("SentGreetingTime");
                    //時間切れになっていないか。一定時間経って会話がないと最初のステータスに戻り、挨拶に戻る。
                    bool overtimeflg = false;

                    //一定時間会話が途切れてなかったかどうかチェック）
                    if (SentGreetingTime != null)
                    {
                        DateTime nowtime = DateTime.Now;
                        TimeSpan duration = nowtime - DateTime.Parse(SentGreetingTime);
                        //TImeSpan TimeSpan(Int32, Int32, Int32)	  TimeSpan(時間数,分数,秒数)
                        TimeSpan interval = new TimeSpan(1, 0, 0);
                        if (duration > interval)
                        {
                            overtimeflg = true;
                        }
                    }

                    //続きの会話の場合
                    if (SentGreeting == true && overtimeflg == false)
                    {
                        //メニュー階層のどこにいるか取り出し
                        int MenuState = userData.GetProperty<int>("MenuState");
                        //メニュー階層のどこにいるか取り出し
                        string DirectAccessMe = userData.GetProperty<string>("DirectAccessMe");

                        if (activity.Text == "解決した")
                        {
                            //最初の状態に戻すため、usrDataを削除する
                            await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);

                            Activity replyToConversation = activity.CreateReply("お問い合わせありがとうございました！");
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);
                           
                        }
                        else if (activity.Text == "解決していない")
                        {
                            Activity replyToConversation = activity;
                            //メニュー階層1で何番を選んだか取り出し
                            int Menu1Select = userData.GetProperty<int>("Menu1Select");
                            replyToConversation = menuFunc2(activity, getcustomer2List(Menu1Select));
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);
                            userData.SetProperty<int>("MenuState", 3);
                            await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);

                        }
                        else if (activity.Text == "電話で対応してほしい")
                        {
                            //最初の状態に戻すため、UsrDataを削除する
                            await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);

                            Activity replyToConversation = activity.CreateReply("(0985)58-2867へとお問い合わせください");
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);
                        }
                        else if (activity.Text == "メールで対応してほしい")
                        {
                            //最初の状態に戻すため、UsrDataを削除する
                            await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);

                            Activity replyToConversation = activity.CreateReply("query@cc.miyazaki-u.ac.jpへとお問い合わせください");
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);
                        }
                        else if (activity.Text == "MIDって何？")
                        {
                            //最初の状態に戻すため、UsrDataを削除する
                            await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);

                            Activity replyToConversation = activity.CreateReply("利用者の利便性向上を図るために異なる情報システムにおいて統一的に利用できる認証基盤として宮崎大学統一認証アカウント（通称：ＭＩＤ）の運用を行っています。\r\n" +
                                "平成２２年度より運用を開始しており、本学における全学的な情報システムの利用者認証について、ほとんどの情報システムでＭＩＤ認証を利用しています。");
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);
                        }
                        /*

                                                //メニュー階層が1の場合
                                                else if (MenuState == 1)
                                                {
                                                    bool buttonflag = false;
                                                    Activity replyToConversation = activity;
                                                    await LUIS(activity);
                                                    replyToConversation = menuFunc2(activity, getcustomer1List());

                                                    //メニュー階層を2にする
                                                    userData.SetProperty<int>("MenuState", 2);
                                                    await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                                                }
                                                //メニュー階層が2の場合
                                                else if (MenuState == 2)
                                                {
                                                    bool buttonflag = false;

                                                    Activity replyToConversation = activity;
                                                    replyToConversation = menuFunc2(activity, getcustomer1List());
                                                    buttonflag = true;

                                                    //ボタンが押されなかった時はLUISを呼ぶ
                                                    if (buttonflag != true)
                                                    {
                                                        await LUIS(activity);

                                                    }
                                                    else
                                                    {
                                                        await connector.Conversations.ReplyToActivityAsync(replyToConversation);

                                                        //メニュー階層を3にする
                                                        userData.SetProperty<int>("MenuState", 3);
                                                        await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);


                                                        //このサンプルでは階層３までで終わりのため、UsrDataを削除する
                                                        //await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);
                                                    }
                                                }       
                                                //メニュー階層が3の場合
                                                else if (MenuState == 3)
                                                {
                                                    bool buttonflag = false;


                                                    Activity replyToConversation = activity;

                                                    foreach (var item in getcustomer1List().Select((v, i) => new { v, i }))
                                                    {
                                                        if (activity.Text == item.v)
                                                        {
                                                            replyToConversation = menuFunc2(activity, getcustomer2List(item.i));
                                                            //メニュー階層2で何番を選んだか保存
                                                            userData.SetProperty<int>("Menu2Select", item.i);

                                                            buttonflag = true;
                                                            break;
                                                        }
                                                    }

                                                    //ボタンが押されなかった時はLUISを呼ぶ
                                                    if (buttonflag != true)
                                                    {
                                                        //await LUIS(activity);

                                                    }
                                                    else
                                                    {
                                                        await connector.Conversations.ReplyToActivityAsync(replyToConversation);

                                                        await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);


                                                        //このサンプルでは階層３までで終わりのため、UsrDataを削除する
                                                        //await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);
                                                    }
                                                }

                                                //ボタンで設定していないワードがきたときはLUISに渡す。
                                                else
                                                {
                                                    //await LUIS(activity);
                                                }
                                            }
                                            */

                        //会話の開始。挨拶から。
                        else
                        {
                        Activity replyToConversation = Greeting(activity);
                        await connector.Conversations.ReplyToActivityAsync(replyToConversation);
                        //最初の一度だけこのダイアログがでるようにするため、UserDataに挨拶したことを保存しておく
                        Task result = stateSentGreeting(activity, stateClient, userData);

                    }



                
                catch (HttpOperationException err)
                {
                    // handle precondition failed error if someone else has modified your object
                }

            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }




        private async Task LUIS(Activity activity)
        {
            try
            {
                //Connectorからのデータ入出力
                /*ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                //State管理
                StateClient stateClient = activity.GetStateClient();

                BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                Activity replyToConversation = activity;*/
                // one of these will have an interface and process it
                switch (activity.GetActivityType())
                {

                    // get the user data object
                    case ActivityTypes.Message:

                        await Conversation.SendAsync(activity, () => new BasicLuisDialog());
                        //replyToConversation = menuFunc(activity, getcustomer1List());
                        //await connector.Conversations.ReplyToActivityAsync(replyToConversation);
                        //await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                        break;
                    case ActivityTypes.ConversationUpdate:
                    case ActivityTypes.ContactRelationUpdate:
                    case ActivityTypes.Typing:
                    case ActivityTypes.DeleteUserData:
                    default:
                        Trace.TraceError($"Unknown activity type ignored: {activity.GetActivityType()}");
                        break;
                }
            }
            catch (HttpOperationException err)
            {
                // handle precondition failed error if someone else has modified your object
            }

        }

        private Activity Greeting(Activity activity)
        {
            Activity replyToConversation = activity.CreateReply("こんにちは。情報基盤センターです。どういったお問い合わせでしょうか。");
            replyToConversation.Recipient = activity.From;
            replyToConversation.Type = "message";

            return replyToConversation;
        }

        private Activity menuFunc(Activity activity)
        {
            Activity replyToConversation = activity.CreateReply(activity.Text + "についてですね。1");
            //replyToConversation.Recipient = activity.From;
            //replyToConversation.Type = "message";

            return replyToConversation;
        }
        private Activity menuFunc2(Activity activity, List<string> MenuList)
        {
            Activity replyToConversation = activity.CreateReply(activity.Text + "についてですね。2");
            replyToConversation.Recipient = activity.From;
            replyToConversation.Type = "message";
            replyToConversation.Attachments = new List<Attachment>();
            List<CardAction> cardButtons = new List<CardAction>();

            CardAction plButton = new CardAction();

            foreach (string buttonData in MenuList)
            {
                plButton = new CardAction()
                {
                    Value = buttonData,
                    Type = "imBack",
                    Title = buttonData
                };
                cardButtons.Add(plButton);
            }

            HeroCard plCard = new HeroCard()
            {
                Title = "以下からお選びください。",
                Buttons = cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();
            replyToConversation.Attachments.Add(plAttachment);

            return replyToConversation;
        }
        private Activity menuFunc3(Activity activity, List<string> MenuList)
        {
            Activity replyToConversation = activity.CreateReply(activity.Text + "については[こちら](https://www.google.co.jp/search?q=" + MenuList[0] + "のトラブル)");

            return replyToConversation;
        }


        private async Task stateSentGreeting(Activity activity, StateClient stateClient, BotData userData)
        {
            //最初の一度だけこのダイアログがでるようにするため、UserDataに挨拶したことを保存しておく
            userData.SetProperty<bool>("SentGreeting", true);
            DateTime nowtime = DateTime.Now;
            userData.SetProperty<string>("SentGreetingTime", nowtime.ToString());
            //初期はメニュー階層を1にする
            userData.SetProperty<int>("MenuState", 1);
            await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}