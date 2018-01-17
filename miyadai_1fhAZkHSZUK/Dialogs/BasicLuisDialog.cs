using System;
using System.Configuration;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace Microsoft.Bot.Sample.LuisBot
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(ConfigurationManager.AppSettings["LuisAppId"], ConfigurationManager.AppSettings["LuisAPIKey"])))
        {
        }

        [LuisIntent("無線ネットワーク")]
        public async Task WireLess(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"初めてSSIDにパソコンなどの端末を接続するとセキュリティコードを求められます。\r\n" +
                $"「miyazaki-u」と打ち込んでください。" +
                $"正しいコードを入力して接続すると自動的にIPアドレスを取得してネットワーク接続が行われます。" +
                $"その後、IEやFirefoxなどのブラウザを開いて、ネットワーク認証を行うことで接続が完了します。" +
                $"本学教職員は特に申請は不要です。" +
                $"学外者については、宮大FreeSpotもしくはEduroamを利用してください。" +
                $"詳しくはhttps://www.cc.miyazaki-u.ac.jp/service/internal/wlan.php"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("宮崎大学統一認証アカウント＿概要")]
        public async Task Authentication_abstract(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"利用者の利便性向上を図るために異なる情報システムにおいて統一的に利用できる認証基盤として宮崎大学統一認証アカウント（通称：ＭＩＤ）の運用を行っています。" +
                $"平成２２年度より運用を開始しており、本学における全学的な情報システムの利用者認証について、ほとんどの情報システムでＭＩＤ認証を利用しています。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("宮大FreeSpot")]
        public async Task FreeSpot(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"木花キャンパスの、ユーザ認証を必要としない無線LANです。" +
                $"学内制限がかかった情報システムには接続できません。" +
                $"ＳＳＩＤ：「FreeSpot」"); //
            context.Wait(MessageReceived);
        }
  
        [LuisIntent("学認ID＿申請")]
        public async Task ID_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"宮崎大学の教職員・学生に限ります。" +
                $"【教職員】情報基盤センター発行のメールアドレス（@cc）が必要です。発行を受けていない方は、先に情報基盤センター一般利用申請から申請を行ってください。" +
                $"【学生】入学時に発行される情報基盤センター発行のメールアドレス（@student）を用意してください。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("学認ID＿概要")]
        public async Task ID_abstract(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学認認証フェデレーションとは、学術e-リソースを利用する大学、学術e-リソースを提供する機関・出版社等から構成された連合体のことです。" +
                $"各機関はフェデレーションが定めた規定（ポリシー）を信頼しあうことで、相互に認証連携を実現することが可能となります。" +
                $"詳しくはhttp://www.cc.miyazaki-u.ac.jp/gakunin/GakuNin.html"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("宮崎大学統一認証アカウント＿申請")]
        public async Task Authentication_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"○新規発行について" +
                $"大学所属の教職員および学生の新規発行の申請は不要です。人事情報・教務情報を元に自動的に発行します。" +
                $"もし採用・入学後にＭＩＤが届かない場合は、お手数ですが情報基盤センターまでお問い合わせ下さい。" +
                $"大学所属以外の方についても、本学システムの利用など、発行が必要と認められた場合に限り、ＭＩＤを発行いたします。" +
                $"申請書および職名を証明できる書類等の写しを添付の上、情報基盤センターに提出してください。" +
                $"○パスワード忘れについて" +
                $"教職員については、情報基盤センターもしくは医学部医療情報部にお問い合わせください。" +
                $"学生の方がパスワードを忘れた際は、パスワード再発行の申請が必要です。申請書に記入の上、情報基盤センターまでお越しください。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("固定IPアドレス＿概要")]
        public async Task IPadress_abstract(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"プリンターなどのネットワーク認証ができない機器やサーバ用途などで固定IPアドレスが必要な機器などについては、固定IPアドレスを発行しています。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("ファイアウォール通信許可＿申請")]
        public async Task FireWall_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"次のような場合に申請が必要となります。" +
                $"外部業者がリモートから学内機器のメンテナンスを行う" +
                $"学外者と学内のネットワーク会議システムを使ってTV会議を行う" +
                $"学外者に研究室設置のNASや演算サーバを利用させる" +
                $"以下の情報が必要です。" +
                $"接続元IPv4アドレス" +
                $"接続先(学内)IPv4アドレス" +
                $"接続先(学内)FQDN(任意)" +
                $"サービスポート(ポート番号 / プロトコル)" +
                $"利用用途"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("ゲストネットワーク利用＿申請")]
        public async Task GuestNet_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"" +
                $"〇申請者：本学の教職員（常勤）に限ります。" +
                $"〇利用期限：" +
                $"最長で申請年度となります。" +
                $"〇申請にあたって：" +
                $"利用の１週間前までに申請を行って下さい。アカウント数によっては、発行が遅くなる場合があります。" +
                $"〇利用にあたって：" +
                $"申請者の責任の下でアカウントの管理およびネットワーク接続を行って下さい。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("ゲストネットワーク利用＿概要")]
        public async Task GuestNet_abstract(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"本学教職員以外の学外者が本学の情報システムを利用するにあたって、木花キャンパスの情報ネットワーク(有線・無線)での接続が必要な場合に限り、ネットワーク認証専用のゲスト用アカウントを臨時で発行しています。" +
                $"インターネットを利用するだけの目的であれば、「eduroam」または「FreeSpot」をご利用下さい。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("SSL-VPNサービス＿申請")]
        public async Task SSL_VPN_abstract(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"SSL-VPNを利用するには接続するパソコンに専用のソフトウェアをインストールする必要があります。" +
                $"※インストールの際は必ず「VPNのみ(VPN Only)」を選択してください。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("情報基盤センター利用＿概要")]
        public async Task InformationTechnologyCenter_abstract(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"本学の教職員（ＭＩＤを保持しない方、組織用など）もしくは共同研究者などの学外者に対して、情報基盤センター一般利用者アカウントを発行しています。" +
                $"本アカウントは以下の情報システムで利用できます。" +
                $"電子メール（＠cc）、Webサイトの開設、演算サーバ（Linux）" +
                $"木花キャンパスのネットワーク認証（有線・無線）"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("SSL-VPNサービス＿概要")]
        public async Task SSL_VPN_abstrast(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学外から木花キャンパスにある情報システムに対してセキュアにアクセスする手段として、宮崎大学統一認証アカウント（MID）保有者に対してSSL-VPN（Secure Sockets Layer Virtual Private Network）サービスを提供します。" +
                $"これにより、宮崎大学の学内専用Webサイトの閲覧や情報基盤センターのオンラインストレージ等をSSL - VPNを経由して利用できます。" +
                $"ただし、事務シンクライアントシステムおよび附属図書館が提供する電子ジャーナルにはアクセスできません。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("情報基盤センター利用＿申請")]
        public async Task InformationTechnologyCenter_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"〇対象者" +
                $"利用者および受入先担当者／代表者は以下の方に限ります。" +
                $"【利用者】" +
                $"本学の教職員" +
                $"情報基盤センター長が適当と認めた方（学外者）" +
                $"【受入先担当者／代表者】" +
                $"本学の教職員" +
                $"〇利用期限" +
                $"本学の教職員：在職中は継続して利用できます。" +
                $"情報基盤センター長が適当と認めた方（学外者）：申請年度内に限ります。" +
                $"翌年度も続けて利用される場合は【情報基盤センター利用申請書（ＰＤＦ版、Ｗｏｒｄ版）【学内制限】】を提出してください。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("有線ネットワーク")]
        public async Task WiredNetwork(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"情報コンセントとパソコンなどの端末を接続すると、DHCPサーバにより自動的にIPアドレスを取得してネットワーク接続が行われます。" +
                $"その後、IEやFirefoxなどのブラウザを開いて、ネットワーク認証を行うことで接続が完了します。" +
                $"ネットワーク認証に利用できるIDは以下のとおりです。" +
                $"宮崎大学統一認証アカウント（MID）" +
                $"情報基盤センター利用者アカウント" +
                $"ゲストネットワーク用アカウント" +
                $"なお、ネットワーク認証はタイムアウトがあり、以下の時間を過ぎると再認証が発生します。" +
                $"・無通信時間が１時間" +
                $"・最初の認証から１２時間経過" +
                $"プリンターなどのネットワーク認証ができない機器やサーバ用途などで固定IPアドレスが必要な機器などについては、固定IPアドレス申請を行なってください。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("eduroam")]
        public async Task eduroam(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"宮崎大学では、木花キャンパスの無線LANの以下のSSIDで利用可能です。" +
                $"その他の利用可能なサイトは、関連リンクの「eduroam基地局マップ」をご覧ください。" +
                $"○ＳＳＩＤ：「eduroam」" +
                $"○ＩＤ／パスワード：" +
                $"【教職員】@ccメールアドレス／MIDのパスワード" +
                $"【学生】@studentメールアドレス／MIDのパスワード"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("固定IPアドレス＿申請")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"情報コンセント番号と機器のMACアドレスが必要です。" +
                $"情報コンセント番号とは、各部屋にある有線LANの差込口に振られた英字3、数字3のユニークな番号です。"); //
            context.Wait(MessageReceived);
        }

      
        

        // Go to https://luis.ai and create a new intent, then train/publish your luis app.
        // Finally replace "MyIntent" with the name of your newly created intent in the following handler
        [LuisIntent("None")]
        public async Task hahaha(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"該当なっしん"); //
            context.Wait(MessageReceived);
        }

    }
}