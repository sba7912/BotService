﻿using System;
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
        public List<string> getMenu1List()
        {
            List<string> MenuList = new List<string>();
            MenuList.Add("認証・ID関係");
            MenuList.Add("情報ネットワーク関係");
            MenuList.Add("Software関係");
            MenuList.Add("情報システム関係");
            MenuList.Add("その他");
            return MenuList;
        }

        public List<string> getMenu2List(int Menu1Select)
        {
            List<string> MenuList = new List<string>();
            switch (Menu1Select)
            {
                case 0:
                    MenuList.Add("宮崎大学統一認証アカウント(MID)");
                    MenuList.Add("情報基盤センター利用申請");
                    MenuList.Add("学認ID");
                    MenuList.Add("戻る");
                    break;
                case 1:
                    MenuList.Add("有線ネットワーク");
                    MenuList.Add("無線ネットワーク");
                    MenuList.Add("固定IPアドレス");
                    MenuList.Add("ファイアウォール通信許可申請");
                    MenuList.Add("SSL-VPNサービス");
                    MenuList.Add("ゲストネットワーク利用");
                    MenuList.Add("eduroam");
                    MenuList.Add("宮大FreeSpot");
                    MenuList.Add("戻る");
                    break;
                case 2:
                    MenuList.Add("Microsoft包括ライセンス");
                    MenuList.Add("宮崎大学ウイルスソフト包括");
                    MenuList.Add("Solidworks 3DCAD");
                    MenuList.Add("戻る");
                    break;
                case 3:
                    MenuList.Add("オンラインストレージ");
                    MenuList.Add("宮大どこプリ");
                    MenuList.Add("電子メール");
                    MenuList.Add("実習室システム");
                    MenuList.Add("メーリングリスト");
                    MenuList.Add("学生一斉メール");
                    MenuList.Add("Web公開サービス(個人)");
                    MenuList.Add("Web公開サービス(組織)");
                    MenuList.Add("Web公開サービス(学生)");
                    MenuList.Add("大判プリンタ");
                    MenuList.Add("仮想サーバ貸出");
                    MenuList.Add("サーバ証明書発行サービス(UPKI電子証明書発行)");
                    MenuList.Add("DNS・名前解決サービス");
                    MenuList.Add("メールゲートウェイ(アンチウイルス / スパム)");
                    MenuList.Add("戻る");
                    break;
                case 4:
                    MenuList.Add("定期メンテナンス【学内制限】");
                    MenuList.Add("業務依頼サービス利用");
                    MenuList.Add("テレビ会議システム");
                    MenuList.Add("Web会議システム(Vidyo)");
                    MenuList.Add("ハウジングサービス");
                    MenuList.Add("戻る");
                    break;

                default:
                    break;
            }
            return MenuList;
        }

        public List<string> getMenu3List(int Menu1Select, int Menu2Select)
        {
            List<string> MenuList = new List<string>();
            //State管理
            //StateClient stateClient = activity.GetStateClient();
            //BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);

            switch (Menu1Select)
            {
                case 0:
                    switch (Menu2Select)
                    {
                        case 0: //MID選んだ人
                            MenuList.Add("宮崎大学統一認証アカウント(MID)_概要");
                            MenuList.Add("宮崎大学統一認証アカウント(MID)_利用");
                            MenuList.Add("戻る");
                            break;
                        case 1:　//情報基盤センター利用申請選んだ人
                            MenuList.Add("宮崎大学統一認証アカウント(MID)");
                            MenuList.Add("情報基盤センター利用申請");
                            MenuList.Add("学認ID");
                            MenuList.Add("戻る");
                            break;
                        case 2: //学認ID選んだ人
                            MenuList.Add("宮崎大学統一認証アカウント(MID)");
                            MenuList.Add("情報基盤センター利用申請");
                            MenuList.Add("学認ID");
                            MenuList.Add("戻る");
                            break;
                        case 3: //戻る選んだ人
                                //メニュー階層を1にする
                                //userData.SetProperty<int>("MenuState", 1);
                                //await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                            break;
                    }
                    break;
                case 1:
                    MenuList.Add("有線ネットワーク");
                    MenuList.Add("無線ネットワーク");
                    MenuList.Add("固定IPアドレス");
                    MenuList.Add("ファイアウォール通信許可申請");
                    MenuList.Add("SSL-VPNサービス");
                    MenuList.Add("ゲストネットワーク利用");
                    MenuList.Add("eduroam");
                    MenuList.Add("宮大FreeSpot");
                    MenuList.Add("戻る");
                    break;
                case 2:
                    MenuList.Add("Microsoft包括ライセンス");
                    MenuList.Add("宮崎大学ウイルスソフト包括");
                    MenuList.Add("Solidworks 3DCAD");
                    MenuList.Add("戻る");
                    break;
                case 3:
                    MenuList.Add("オンラインストレージ");
                    MenuList.Add("宮大どこプリ");
                    MenuList.Add("電子メール");
                    MenuList.Add("実習室システム");
                    MenuList.Add("メーリングリスト");
                    MenuList.Add("学生一斉メール");
                    MenuList.Add("Web公開サービス(個人)");
                    MenuList.Add("Web公開サービス(組織)");
                    MenuList.Add("Web公開サービス(学生)");
                    MenuList.Add("大判プリンタ");
                    MenuList.Add("仮想サーバ貸出");
                    MenuList.Add("サーバ証明書発行サービス(UPKI電子証明書発行)");
                    MenuList.Add("DNS・名前解決サービス");
                    MenuList.Add("メールゲートウェイ(アンチウイルス / スパム)");
                    MenuList.Add("戻る");
                    break;
                case 4:
                    MenuList.Add("定期メンテナンス【学内制限】");
                    MenuList.Add("業務依頼サービス利用");
                    MenuList.Add("テレビ会議システム");
                    MenuList.Add("Web会議システム(Vidyo)");
                    MenuList.Add("ハウジングサービス");
                    MenuList.Add("戻る");
                    break;

                default:
                    break;
            }
            return MenuList;
        }

        public List<string> satisfaction()
        {
            List<string> MenuList = new List<string>();
            MenuList.Add("解決した");
            MenuList.Add("解決していない");
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
                        TimeSpan interval = new TimeSpan(0, 1, 0);
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

                        if (activity.Text == "reset" || activity.Text == "リセット" || activity.Text == "りせっと")
                        {
                            //最初の状態に戻すため、usrDataを削除する
                            await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);

                            Activity replyToConversation = activity.CreateReply("リセットしました (punch) ");
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);

                        }
                        else if (activity.Text == "Hello" || activity.Text == "こんにちは" || activity.Text == "コンニチハ")
                        {
                            //「こんにちは」という文言が来た場合は、最初の状態に戻す
                            //最初の状態に戻すため、usrDataを削除する
                            await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);

                            Activity replyToConversation = Greeting(activity, getMenu1List());
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);

                            //最初の一度だけこのダイアログがでるようにするため、UserDataに挨拶したことを保存しておく
                            Task result = stateSentGreeting(activity, stateClient, userData);

                        }
                        else if (activity.Text == "戻る")
                        {

                            //1個前のメニュー階層に戻る
                            Activity replyToConversation = activity;
                            replyToConversation = menuFunc(activity, getMenu1List());
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);
                            userData.SetProperty<int>("MenuState", 1);
                            await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);

                        }
                        else if (activity.Text == "電話で対応してほしい")
                        {

                            Activity replyToConversation = activity.CreateReply("・・・・・番です 	(call) ");
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);

                            //メニュー階層1で何番を選んだか保存
                            userData.SetProperty<string>("DirectAccessMe", "Tell");
                            await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                        }
                        else if (activity.Text == "メールで対応してほしい")
                        {

                            Activity replyToConversation = activity.CreateReply("メールアドレスはquerycc.miyazaki-u.ac.jpです。");
                            await connector.Conversations.ReplyToActivityAsync(replyToConversation);

                            //最初の状態に戻すため、usrDataを削除する
                            await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);
                        }

                        //メニュー階層が1の場合
                        else if (MenuState == 1)
                        {
                            Activity replyToConversation = activity;

                            bool buttonflag = false;

                            foreach (var item in getMenu1List().Select((v, i) => new { v, i }))
                            {
                                if (activity.Text == item.v)
                                {
                                    replyToConversation = menuFunc(activity, getMenu2List(item.i));
                                    //メニュー階層1で何番を選んだか保存
                                    userData.SetProperty<int>("Menu1Select", item.i);

                                    buttonflag = true;
                                    break;
                                }
                            }
                            //ボタンが押されなかった時はLUISを呼ぶ
                            if (buttonflag != true)
                            {
                                await LUIS(activity);
                            }
                            else
                            {
                                //Activity replyToConversation = menu1Func(activity);
                                await connector.Conversations.ReplyToActivityAsync(replyToConversation);

                                //メニュー階層を2にする
                                userData.SetProperty<int>("MenuState", 2);
                                await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                            }
                        }
                        //メニュー階層が2の場合
                        else if (MenuState == 2)
                        {
                            bool buttonflag = false;

                            //メニュー階層1で何番を選んだか取り出し
                            int Menu1Select = userData.GetProperty<int>("Menu1Select");

                            Activity replyToConversation = activity;

                            foreach (var item in getMenu2List(Menu1Select).Select((v, i) => new { v, i }))
                            {
                                if (activity.Text == item.v)
                                {
                                    replyToConversation = menuFunc2(activity, getMenu3List(Menu1Select, item.i));
                                    //await LUIS(activity);
                                    //メニュー階層2で何番を選んだか保存
                                    userData.SetProperty<int>("Menu2Select", item.i);

                                    //await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);
                                    buttonflag = true;
                                    break;
                                }
                            }

                            //ボタンが押されなかった時はLUISを呼ぶ
                            if (buttonflag != true)
                            {
                                await LUIS(activity);

                            }
                            else
                            {
                                //Activity replyToConversation = menu1Func(activity);
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

                            //メニュー階層1で何番を選んだか取り出し
                            int Menu1Select = userData.GetProperty<int>("Menu1Select");
                            //メニュー階層2で何番を選んだか取り出し
                            int Menu2Select = userData.GetProperty<int>("Menu2Select");

                            Activity replyToConversation = activity;

                            foreach (var item in getMenu3List(Menu1Select, Menu2Select).Select((v, i) => new { v, i }))
                            {
                                if (activity.Text == item.v)
                                {
                                    //replyToConversation = menuFunc3(activity, getMenu3List(Menu2Select, item.i));
                                    await LUIS(activity);
                                    //メニュー階層3で何番を選んだか保存
                                    userData.SetProperty<int>("Menu3Select", item.i);

                                    //await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);
                                    buttonflag = true;
                                    break;
                                }
                            }

                            //ボタンが押されなかった時はLUISを呼ぶ
                            if (buttonflag != true)
                            {
                                await LUIS(activity);
                            }
                            else
                            {
                                /*  //Activity replyToConversation = menu1Func(activity);
                                  await connector.Conversations.ReplyToActivityAsync(replyToConversation);

                                  //メニュー階層を3にする
                                  userData.SetProperty<int>("MenuState", 3);
                                  await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
                                  */

                                //このサンプルでは階層３までで終わりのため、UsrDataを削除する
                                await stateClient.BotState.DeleteStateForUserAsync(activity.ChannelId, activity.From.Id);
                            }
                        }

                        //ボタンで設定していないワードがきたときはLUISに渡す。
                        else
                        {
                            await LUIS(activity);
                        }
                    }
                    //会話の開始。挨拶から。
                    else
                    {
                        Activity replyToConversation = Greeting(activity, getMenu1List());
                        await connector.Conversations.ReplyToActivityAsync(replyToConversation);

                        //最初の一度だけこのダイアログがでるようにするため、UserDataに挨拶したことを保存しておく
                        Task result = stateSentGreeting(activity, stateClient, userData);

                    }



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
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                //State管理
                StateClient stateClient = activity.GetStateClient();

                BotData userData = await stateClient.BotState.GetUserDataAsync(activity.ChannelId, activity.From.Id);
                // one of these will have an interface and process it
                switch (activity.GetActivityType())
                {

                    // get the user data object
                    case ActivityTypes.Message:
                        Activity replyToConversation = activity;
                        await Conversation.SendAsync(activity, () => new BasicLuisDialog());
                        replyToConversation = menuFunc(activity, satisfaction());
                        await connector.Conversations.ReplyToActivityAsync(replyToConversation);
                        await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
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

        private Activity Greeting(Activity activity, List<string> MenuList)
        {
            Activity replyToConversation = activity.CreateReply("こんにちは。情報基盤センターです。どういったお問い合わせでしょうか。下からお選びください");
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
                Title = "該当する項目をお選びください",
                Buttons = cardButtons
            };
            Attachment plAttachment = plCard.ToAttachment();
            replyToConversation.Attachments.Add(plAttachment);

            return replyToConversation;
        }

        private Activity menuFunc(Activity activity, List<string> MenuList)
        {
            Activity replyToConversation = activity.CreateReply(activity.Text + "についてですね。");
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
        private Activity menuFunc2(Activity activity, List<string> MenuList)
        {
            Activity replyToConversation = activity.CreateReply(activity.Text + "についてですね。");
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