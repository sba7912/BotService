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
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"],
            ConfigurationManager.AppSettings["LuisAPIKey"],
    
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }



        [LuisIntent("MID_概要")]
        public async Task MID_overview(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"利用者の利便性向上を図るために異なる情報システムにおいて統一的に利用できる認証基盤として宮崎大学統一認証アカウント（通称：ＭＩＤ）の運用を行っています。\r\n" +
            $"平成２２年度より運用を開始しており、本学における全学的な情報システムの利用者認証について、ほとんどの情報システムでＭＩＤ認証を利用しています。"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("MID_新規発行")]
        public async Task MID_issue(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"大学所属の教職員および学生の新規発行の申請は不要です。人事情報・教務情報を元に自動的に発行します。\r\n" +
            $"もし採用・入学後にＭＩＤが届かない場合は、お手数ですが情報基盤センターまでお問い合わせ下さい。\r\n" +
            $"大学所属以外の方についても、本学システムの利用など、発行が必要と認められた場合に限り、ＭＩＤを発行いたします。\r\n" +
            $"申請書および職名を証明できる書類等の写しを添付の上、情報基盤センターに提出してください。"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("MID_パスワード忘れ")]
        public async Task MID_forgetPass(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"教職員については、情報基盤センターもしくは医学部医療情報部にお問い合わせください。\r\n" +
            $"学生の方がパスワードを忘れた際は、パスワード再発行の申請が必要です。申請書に記入の上、情報基盤センターまでお越しください。"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("情報基盤センター＿概要")]
        public async Task Center_overview(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"本学の教職員（ＭＩＤを保持しない方、組織用など）もしくは共同研究者などの学外者に対して、情報基盤センター一般利用者アカウントを発行しています。\r\n" +
            $"本アカウントは以下の情報システムで利用できます。\r\n" +
            $"•電子メール（＠cc）、Webサイトの開設、演算サーバ（Linux）\r\n" +
            $"•木花キャンパスのネットワーク認証（有線・無線）\r\n" +
            $"また、すでに宮崎大学統一認証アカウント（ＭＩＤ）を保有されている教職員の方で、Webサイトの開設を希望される方は本申請で受け付けています。"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("学認ID＿概要")]
        public async Task ID_overview(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学認認証フェデレーションとは、学術e-リソースを利用する大学、学術e-リソースを提供する機関・出版社等から構成された連合体のことです。\r\n" +
            $"各機関はフェデレーションが定めた規定（ポリシー）を信頼しあうことで、相互に認証連携を実現することが可能となります。（学認サイトより引用）\r\n" +
            $"宮崎大学は学認認証フェデレーションに参加しており、情報基盤センターが発行する学認IDを取得することで、各機関が提供する電子ジャーナル、多地点接続などの各種サービスを受けることができます。"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("学認ID_申請")]
        public async Task ID_application(IDialogContext context, LuisResult result)
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
            $"詳しくは:(https://www.cc.miyazaki-u.ac.jp/service/internal/wlan.php)"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("固定IPアドレス")]
        public async Task IPadress(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"プリンターなどのネットワーク認証ができない機器やサーバ用途などで固定IPアドレスが必要な機器などについては、固定IPアドレスを発行しています。\r\n" +
            $"申請には、情報コンセント番号と機器のMACアドレスが必要です。\r\n" +
            $"情報コンセント番号とは、各部屋にある有線LANの差込口に振られた英字3、数字3のユニークな番号です。\r\n" +
            $"申請はこちら(学内制限):(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("ファイアウォール＿申請1")]
        public async Task FireWall_request1(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学外から木花キャンパスネットワークに対しての通信は原則遮断しています。\r\n" +
            $"学外から木花キャンパスのネットワークに接続している機器に対して接続が必要な場合は、オンライン申請を行うことで例外的に通信が許可されます。\r\n" +
            $"例えば次のような場合に申請が必要となります。\r\n" +
            $"以下の情報が必要です。\r\n" +
            $"接続元IPv4アドレス\r\n" +
            $"接続先(学内)IPv4アドレス\r\n" +
            $"接続先(学内)FQDN(任意)\r\n" +
            $"サービスポート(ポート番号 / プロトコル)\r\n" +
            $"利用用途"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("ファイアウォール＿申請2")]
        public async Task FireWall_request2(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学外から木花キャンパスネットワークに対しての通信は原則遮断しています。\r\n" +
            $"学外から木花キャンパスのネットワークに接続している機器に対して接続が必要な場合は、オンライン申請を行うことで例外的に通信が許可されます。\r\n" +
            $"例えば次のような場合に申請が必要となります。\r\n" +
            $"以下の情報が必要です。\r\n" +
            $"接続元IPv4アドレス\r\n" +
            $"接続先(学内)IPv4アドレス\r\n" +
            $"接続先(学内)FQDN(任意)\r\n" +
            $"サービスポート(ポート番号 / プロトコル)\r\n" +
            $"利用用途"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("SSL-VPNサービス")]
        public async Task SSL_VPN(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"SSL-VPNサービスは学外から木花キャンパスにある情報システムに対してセキュアにアクセスする手段です。\r\n" +
            $"これにより、宮崎大学の学内専用Webサイトの閲覧や情報基盤センターのオンラインストレージ等をSSL-VPNを経由して利用できます。\r\n" +
            $"SSL-VPNを利用するには接続するパソコンに専用のソフトウェアをインストールする必要があります。(学内制限)"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("ゲストネットワーク利用")]
        public async Task GuestNet(IDialogContext context, LuisResult result)
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
        public async Task Eduroam(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"宮崎大学では、木花キャンパスの無線LANの以下のSSIDで利用可能です。\r\n" +
            $"その他の利用可能なサイトは、関連リンクの「eduroam基地局マップ」をご覧ください。\r\n" +
            $"○ＳＳＩＤ：「eduroam」\r\n" +
            $"○ＩＤ／パスワード：\r\n" +
            $"【教職員】@ccメールアドレス／MIDのパスワード\r\n" +
            $"【学生】@studentメールアドレス／MIDのパスワード"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("宮大FreeSpot")]
        public async Task FreeSpot(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"木花キャンパスの、ユーザ認証を必要としない無線LANです。\r\n" +
      $"学内制限がかかった情報システムには接続できません。\r\n" +
      $"ＳＳＩＤ：「FreeSpot」"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("宮崎大学ウイルスソフト包括")]
        public async Task VirusSoft(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"平成25年4月より,宮崎大学ウイルス対策ソフトの包括ライセンスを開始し, インストール台数の制限が無く, 大学構成員であれば個人用途の端末でも利用することができます. \r\n" +
            $"【利用の範囲】\r\n" +
            $" •宮崎大学の構成員\r\n" +
            $"•附属幼稚園・小学校・中学校の教職員（附属学校園児・児童・生徒は除く） \r\n" +
        $"【利用可能な端末の範囲】\r\n" +
        $" •大学内の端末\r\n" +
        $"•附属学校内の端末\r\n" +
        $"•上記構成員が所有する端末"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("オンラインストレージ＿概要")]
        public async Task OnlineStrage_overview(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"情報基盤センター内に設置したストレージ上でDropboxなどと同様にファイルの保管や共有、大容量ファイル交換に利用できます。\r\n" +
            $"ただし、情報漏えいを防ぐため学外への公開はできません。(SSL-VPNを介して学外から接続は可能)\r\n" +
            $"保存容量は30GB / 人で世代管理機能を有しており、3世代まで保存できます。"); //
            context.Wait(MessageReceived);
        }




        [LuisIntent("オンラインストレージ＿利用")]
        public async Task OnlineStrage_use(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"宮崎大学統一認証アカウント(MID)保有者はWebブラウザかアプリケーション(Windows限定)から利用可能です。\r\n" +
                       $"[詳しくはこちら（学内制限）](https://fshare.ccad.miyazaki-u.ac.jp/)");//
            context.Wait(MessageReceived);
        }





        [LuisIntent("宮大どこプリ＿場所")]
        public async Task Print_place(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"宮大どこプリに対応したプリンターは木花キャンパスの以下の場所に設置されています。\r\n" +
            $"•工学部B棟B207\r\n" +
            $"•農学部講義棟1階ラウンジ\r\n" +
            $"•教育学部実験研究棟1階就職相談室\r\n" +
            $"•附属図書館本館1階カウンター横\r\n" +
            $"•情報基盤センター1階実習室B2");
            context.Wait(MessageReceived);
        }



        [LuisIntent("宮大どこプリ＿量 ")]
        public async Task Print_number(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"とりあえず放置。"); //
            context.Wait(MessageReceived);
        }




        [LuisIntent("宮大どこプリ＿利用")]
        public async Task Print_use(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"パソコンにドライバーのインストールが必要です。\r\n" +
            $"パソコンに合わせたドライバーをダウンロードして、インストールしてください。");
            context.Wait(MessageReceived);
        }




        [LuisIntent("電子メール")]
        public async Task Mail(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"メールソフト(Outlook,Thunderbirdなど)での送受信以外に、Webブラウザで送受信可能なWebメールも利用可能です。\r\n" +
            $"教職員用メール：https://wm.cc.miyazaki-u.ac.jp/cgi-bin/index.cgi\r\n" +
            $"学生用メール：https://wm.student.miyazaki-u.ac.jp/cgi-bin/index.cgi"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("実習室システム")]
        public async Task PracticeRoom(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"センター内実習室Aに授業や自習で利用できるパソコン（Windows8.1）を配置しています。\r\n" +
            $"宮崎大学統一認証アカウント(MID)を保有している方ならどなたでも自由に利用できます。\r\n" +
            $"PCで利用できるアプリケーションは以下のとおりです。\r\n" +
            $"Microsoft Office\r\n" +
            $"Adobe Design Std CS5\r\n" +
            $"SolidWorks 2014\r\n" +
            $"Visual Studio2013"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("メーリングリスト")]
        public async Task MailingList(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"ある特定の宛先に電子メールを送ると、その電子メールはあらかじめ登録されている人全員に配送されるサービスです。\r\n" +
            $"メーリングリスト申請者（管理者）は教職員に限りますが、利用者の追加・削除はWeb管理画面から自由に行えます。"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("学生一斉メール")]
        public async Task AllStudentMail(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"ある特定の宛先に電子メールを送ると、その電子メールはあらかじめ登録されている人全員に配送されるサービスです。\r\n" +
            $"メーリングリスト申請者（管理者）は教職員に限りますが、利用者の追加・削除はWeb管理画面から自由に行えます。\r\n" +
            $"添付ファイルをつけることができません。ウェブサイト上に添付ファイルを設置し、URLを本文中に記載するようにしてください。"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("大判プリンタ")]
        public async Task BigPrint(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"大判プリンタ（EPSON, MAXART F10000）１台を導入しており、下表用紙の印刷が可能です。\r\n" +
            $"なお、予算振替が可能な方、もしくは申請者が許可した方も利用可能ですが、その場合は申請者から利用料が徴収されます。\r\n" +
            $"情報基盤センターに直接お越しいただき、予約に空きがあればすぐに印刷が可能ですが、事前に空き状況の確認も兼ねて情報基盤センター（内線2867）までご連絡ください。\r\n" +
            $"下記の印刷可能なファイル一覧のフォーマットをUSBメモリ等で持参し、各自で印刷を行います。\r\n" +
            $"○印刷可能なファイル\r\n" +
            $"PDF\r\n" +
            $"Word\r\n" +
            $"Excel\r\n" +
            $"PowerPoint"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("仮想サーバ貸出")]
        public async Task VirtualServer(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"学内に多数存在するサーバを集約することにより、ハードウェアに係るコストを削減し、効率的・有効的なサーバの運用を図ることを目的として、仮想サーバの貸出を行なっています。\r\n" +
            $"貸出対象は、学部・学科・研究室単位で、責任者および技術的管理者が明確である必要があります。"); //
            context.Wait(MessageReceived);
        }


        [LuisIntent("サーバ証明書発行サービス")]
        public async Task ServerSertificate(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"宮崎大学は、国立情報学研究所が提供するUPKI電子証明書発行サービスに参加しており、以下の電子証明書が利用者負担なしで発行可能です。\r\n" +
            $"サーバ証明書(RSA2048bit)\r\n" +
            $"クライアント証明書\r\n" +
            $"コード署名用証明書"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("DNS・名前解決サービス")]
        public async Task DNS(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"DNS(Domain Name System/Service)とは、インターネット上でのネットワークとホストのアドレスと名前を組織的に秩序付けるシステムです。\r\n" +
            $"電子メールやWebサイト閲覧などインターネットを利用するときには、通信するホストやネットワークのIPアドレスが使われますが、そのアドレスとホストの名前を対応づけるのに使われます。\r\n" +
            $"DNSは階層構造を持ったドメインとよばれる単位でNS(Name Server)によって運用されます。\r\n" +
            $"宮崎大学のドメイン名は以下のとおりです。\r\n" +
            $"宮崎大学ドメイン名：MIYAZAKI-U.AC.JP\r\n" +
            $"MIYAZAKI-U.JP\r\n" +
            $"Name Server：CNS1.CC.MIYAZAKI-U.AC.JP\r\n" +
            $"CNS1.CC.MIYAZAKI-U.JP\r\n" +
            $"CNS2.CC.MIYAZAKI-U.AC.JP\r\n" +
            $"CNS2.CC.MIYAZAKI-U.JP"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("メールゲートウェイ")]
        public async Task MailGateWay(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"メールゲートウェイでは、悪意のある既知のIPアドレスから送信された電子メールの検査や添付ファイルのウイルス検査、スパムメールの検査を行っています。\r\n" +
            $"検査は送受信ともに行われます。"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("業務依頼サービス利用")]
        public async Task BusinessRequest(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"各種業務の依頼・サービスの利用について申請を受け付けています。\r\n" +
            $"学内外ネットワークの臨時接続(クローズド,オープン,SINET L2VPNなど)\r\n" +
            $"情報システムの移設・委託(ハウジング,ホスティング)\r\n" +
            $"データ提供(MID情報,統計情報など)\r\n" +
            $"システム構築・導入に関する相談または支援\r\n" +
            $"プログラム開発\r\n" +
            $"業務・システム最適化\r\n" +
            $"情報関連の教育研修 等\r\n" +
            $"こちらより申請してください：http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("テレビ会議システム")]
        public async Task TVMeeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"テレビ会議専用機として下記の製品を保有しており、貸出も行っています。\r\n" +
            $"ソニー製　HDビデオ会議システム　PCS-XG80（持ち運び可）２台\r\n" +
            $"ソニー製　HDビデオ会議システム　PCS-XG55（常設）１台\r\n" +
            $"Polycom製　HDX7000（常設）１台"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("Web会議システム")]
        public async Task WebMeeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"マルチデバイス（PC、タブレット、スマートフォン）に対応したWeb会議システム（Vidyo）を提供しています。\r\n" +
            $"基本的には専用ソフトウェアをインストールすることで会議を行いますが、TV会議専用装置を使用して接続することも可能です。\r\n" +
            $"最大３０拠点（専用装置は３台まで）の同時接続が可能です。\r\n" +
            $"なお、利用は先着順の予約制です。"); //
            context.Wait(MessageReceived);
        }



        [LuisIntent("ハウジングサービス")]
        public async Task Housing(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"研究室などに設置されている重要なサーバ機を情報基盤センター内に設置できるスペースを用意しております。\r\n" +
            $"情報基盤センターは、無停電電源装置や3日間電源供給できる自家発電機を有しております。\r\n" +
            $"また、入退室管理や監視カメラなどの環境監視、耐震対策も行っていますので安心・安全な環境で運用できます。"); //
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
