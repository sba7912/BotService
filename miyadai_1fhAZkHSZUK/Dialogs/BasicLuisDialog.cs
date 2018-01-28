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

        public async Task WireLess(IDialogContext context, LuisResult result)


        [LuisIntent("")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($""); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("MID_概要")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"利用者の利便性向上を図るために異なる情報システムにおいて統一的に利用できる認証基盤として宮崎大学統一認証アカウント（通称：ＭＩＤ）の運用を行っています。\r\n" +
                $"平成２２年度より運用を開始しており、本学における全学的な情報システムの利用者認証について、ほとんどの情報システムでＭＩＤ認証を利用しています。" ); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("MID_新規発行")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"大学所属の教職員および学生の新規発行の申請は不要です。人事情報・教務情報を元に自動的に発行します。\r\n" +
                $"もし採用・入学後にＭＩＤが届かない場合は、お手数ですが情報基盤センターまでお問い合わせ下さい。\r\n" +
                $"大学所属以外の方についても、本学システムの利用など、発行が必要と認められた場合に限り、ＭＩＤを発行いたします。\r\n" +
                $"申請書および職名を証明できる書類等の写しを添付の上、情報基盤センターに提出してください。"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("MID_パスワード忘れ")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"教職員については、情報基盤センターもしくは医学部医療情報部にお問い合わせください。\r\n" +
                $"学生の方がパスワードを忘れた際は、パスワード再発行の申請が必要です。申請書に記入の上、情報基盤センターまでお越しください。"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("情報基盤センター＿概要")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"本学の教職員（ＭＩＤを保持しない方、組織用など）もしくは共同研究者などの学外者に対して、情報基盤センター一般利用者アカウントを発行しています。\r\n" +
                $"本アカウントは以下の情報システムで利用できます。\r\n" +
                $"•電子メール（＠cc）、Webサイトの開設、演算サーバ（Linux）\r\n" +
                $"•木花キャンパスのネットワーク認証（有線・無線）\r\n" +
                $"また、すでに宮崎大学統一認証アカウント（ＭＩＤ）を保有されている教職員の方で、Webサイトの開設を希望される方は本申請で受け付けています。"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("学認ID＿概要")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学認認証フェデレーションとは、学術e-リソースを利用する大学、学術e-リソースを提供する機関・出版社等から構成された連合体のことです。\r\n" +
                $"各機関はフェデレーションが定めた規定（ポリシー）を信頼しあうことで、相互に認証連携を実現することが可能となります。（学認サイトより引用）\r\n" +
                $"宮崎大学は学認認証フェデレーションに参加しており、情報基盤センターが発行する学認IDを取得することで、各機関が提供する電子ジャーナル、多地点接続などの各種サービスを受けることができます。"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("学認ID_申請")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学認IDの利用は本学の教職員・学生に限ります。\r\n" +
                $"【教職員】\r\n" +
                $"情報基盤センター発行のメールアドレス（@cc）が必要です。発行を受けていない方は、先に情報基盤センター一般利用申請から申請を行ってください。\r\n" +
                $"【学生】\r\n" +
                $"入学時に発行される情報基盤センター発行のメールアドレス（@student）を用意してください。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("有線ネットワーク")]
        public async Task WiredNetwork(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"＜有線LANの使い方＞\r\n" +
                $"情報コンセントとパソコンなどの端末を接続すると、DHCPサーバにより自動的にIPアドレスを取得してネットワーク接続が行われます。\r\n" +
                $"その後、IEやFirefoxなどのブラウザを開いて、ネットワーク認証を行うことで接続が完了します。\r\n" +
                $"ネットワーク認証に利用できるIDは以下のとおりです。\r\n" +
                $"宮崎大学統一認証アカウント（MID）\r\n" +
                $"情報基盤センター利用者アカウント\r\n" +
                $"ゲストネットワーク用アカウント\r\n" +
                $"なお、ネットワーク認証はタイムアウトがあり、以下の時間を過ぎると再認証が発生します。\r\n" +
                $"・無通信時間が１時間\r\n" +
                $"・最初の認証から１２時間経過\r\n" +
                $"プリンターなどのネットワーク認証ができない機器やサーバ用途などで固定IPアドレスが必要な機器などについては、固定IPアドレス申請を行なってください。"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("無線ネットワーク")]
        public async Task WireLess(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"初めてSSIDにパソコンなどの端末を接続するとセキュリティコードを求められます。\r\n" +
                $"「miyazaki-u」と打ち込んでください。\r\n" +
                $"正しいコードを入力して接続すると自動的にIPアドレスを取得してネットワーク接続が行われます。\r\n" +
                $"その後、IEやFirefoxなどのブラウザを開いて、ネットワーク認証を行うことで接続が完了します。\r\n" +
                $"本学教職員は特に申請は不要です。\r\n" +
                $"学外者については、宮大FreeSpotもしくはEduroamを利用してください。\r\n" +
                $"詳しくはhttps://www.cc.miyazaki-u.ac.jp/service/internal/wlan.php"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("固定IPアドレス")]
        public async Task IPadress_abstract(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"プリンターなどのネットワーク認証ができない機器やサーバ用途などで固定IPアドレスが必要な機器などについては、固定IPアドレスを発行しています。\r\n" +
                $"申請には、情報コンセント番号と機器のMACアドレスが必要です。\r\n" +
                $"情報コンセント番号とは、各部屋にある有線LANの差込口に振られた英字3、数字3のユニークな番号です。\r\n" +
                $"申請はこちらhttp://himuka.cc.miyazaki-u.ac.jp/E-application/login.php（学内制限）"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("ファイアウォール＿申請1")]
        public async Task FireWall_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学外から木花キャンパスネットワークに対しての通信は原則遮断しています。\r\n" +
                $"学外から木花キャンパスのネットワークに接続している機器に対して接続が必要な場合は、オンライン申請を行うことで例外的に通信が許可されます。\r\n" +
                $"例えば次のような場合に申請が必要となります。\r\n
                $"以下の情報が必要です。\r\n" +
                $"接続元IPv4アドレス\r\n" +
                $"接続先(学内)IPv4アドレス\r\n" +
                $"接続先(学内)FQDN(任意)\r\n" +
                $"サービスポート(ポート番号 / プロトコル)\r\n" +
                $"利用用途"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("ファイアウォール＿申請2")]
        public async Task FireWall_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学外から木花キャンパスネットワークに対しての通信は原則遮断しています。\r\n" +
                $"学外から木花キャンパスのネットワークに接続している機器に対して接続が必要な場合は、オンライン申請を行うことで例外的に通信が許可されます。\r\n" +
                $"例えば次のような場合に申請が必要となります。\r\n
                $"以下の情報が必要です。\r\n" +
                $"接続元IPv4アドレス\r\n" +
                $"接続先(学内)IPv4アドレス\r\n" +
                $"接続先(学内)FQDN(任意)\r\n" +
                $"サービスポート(ポート番号 / プロトコル)\r\n" +
                $"利用用途"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("SSL-VPNサービス")]
        public async Task SSL_VPN_abstrast(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"SSL-VPNサービスは学外から木花キャンパスにある情報システムに対してセキュアにアクセスする手段です。\r\n" +
                $"これにより、宮崎大学の学内専用Webサイトの閲覧や情報基盤センターのオンラインストレージ等をSSL-VPNを経由して利用できます。\r\n" +
                $"SSL-VPNを利用するには接続するパソコンに専用のソフトウェアをインストールする必要があります。(学内制限)"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("ゲストネットワーク利用")]
        public async Task GuestNet_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"本学教職員以外の学外者が本学の情報システムを利用するにあたって、木花キャンパスの情報ネットワーク(有線・無線)での接続が必要な場合に限り、ネットワーク認証専用のゲスト用アカウントを臨時で発行しています。\r\n" +
                $"インターネットを利用するだけの目的であれば、「eduroam」または「FreeSpot」をご利用下さい。\r\n" +
                $"〇申請者：本学の教職員（常勤）に限ります。\r\n" +
                $"〇利用期限：\r\n" +
                $"最長で申請年度となります。\r\n" +
                $"〇申請にあたって：\r\n" +
                $"利用の１週間前までに申請を行って下さい。アカウント数によっては、発行が遅くなる場合があります。\r\n" +
                $"〇利用にあたって：\r\n" +
                $"申請者の責任の下でアカウントの管理およびネットワーク接続を行って下さい。"); //
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



        [LuisIntent("宮大FreeSpot")]
        public async Task FreeSpot(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"木花キャンパスの、ユーザ認証を必要としない無線LANです。" +
                $"学内制限がかかった情報システムには接続できません。" +
                $"ＳＳＩＤ：「FreeSpot」"); //
            context.Wait(MessageReceived);




        [LuisIntent("宮崎大学ウイルスソフト包括")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"平成25年4月より,宮崎大学ウイルス対策ソフトの包括ライセンスを開始し, インストール台数の制限が無く, 大学構成員であれば個人用途の端末でも利用することができます. " +
                $"【利用の範囲】" +
                $" •宮崎大学の構成員" +
                $"•附属幼稚園・小学校・中学校の教職員（附属学校園児・児童・生徒は除く） " +
                $"【利用可能な端末の範囲】" +
                $" •大学内の端末" +
                $"•附属学校内の端末" +
                $"•上記構成員が所有する端末"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("オンラインストレージ＿概要")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"情報基盤センター内に設置したストレージ上でDropboxなどと同様にファイルの保管や共有、大容量ファイル交換に利用できます。" +
                $"ただし、情報漏えいを防ぐため学外への公開はできません。(SSL-VPNを介して学外から接続は可能)" +
                $"保存容量は30GB / 人で世代管理機能を有しており、3世代まで保存できます。"); //
            context.Wait(MessageReceived);
        }




        [LuisIntent("オンラインストレージ＿利用")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"宮崎大学統一認証アカウント(MID)保有者はWebブラウザかアプリケーション(Windows限定)から利用可能です。" +
                $"•https://fshare.ccad.miyazaki-u.ac.jp/（学内制限）"); //
            context.Wait(MessageReceived);
        }




        [LuisIntent("宮大どこプリ＿利用")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"宮大どこプリに対応したプリンターは木花キャンパスの以下の場所に設置されています。" +
                $"•工学部B棟B207" +
                $"•農学部講義棟1階ラウンジ" +
                $"•教育学部実験研究棟1階就職相談室" +
                $"•附属図書館本館1階カウンター横" +
                $"•情報基盤センター1階実習室B2" +
            context.Wait(MessageReceived);
        }



        [LuisIntent("宮大どこプリ＿量 ")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($""); //
            context.Wait(MessageReceived);
        }




        [LuisIntent("")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($""); //
            context.Wait(MessageReceived);
        }




        [LuisIntent("")]
        public async Task IPadress_request(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($""); //
            context.Wait(MessageReceived);
        }


        ________________________________________________________________





        [LuisIntent("宮崎大学統一認証アカウント＿概要")]
        public async Task Authentication_abstract(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"利用者の利便性向上を図るために異なる情報システムにおいて統一的に利用できる認証基盤として宮崎大学統一認証アカウント（通称：ＭＩＤ）の運用を行っています。" +
                $"平成２２年度より運用を開始しており、本学における全学的な情報システムの利用者認証について、ほとんどの情報システムでＭＩＤ認証を利用しています。"); //
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

       
       
        





        
     
      
        

        // Go to https://luis.ai and create a new intent, then train/publish your luis app.
        // Finally replace "MyIntent" with the name of your newly created intent in the following handler
        [LuisIntent("None")]
        public async Task hahaha(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"すみません。よく分かりません。"); //
            context.Wait(MessageReceived);
        }

    }
}