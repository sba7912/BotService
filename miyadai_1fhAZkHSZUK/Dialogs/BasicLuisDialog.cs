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
    ConfigurationManager.AppSettings["LuisAPIKey"]
    )))
    {

    [LuisIntent("MID_概要")]
    public async Task MID_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"利用者の利便性向上を図るために異なる情報システムにおいて統一的に利用できる認証基盤として宮崎大学統一認証アカウント（通称：ＭＩＤ）の運用を行っています。\r\n" +
      $"平成２２年度より運用を開始しており、本学における全学的な情報システムの利用者認証について、ほとんどの情報システムでＭＩＤ認証を利用しています。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("MID_新規発行")]
    public async Task MID_issue(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"大学所属の教職員および学生の新規発行の申請は不要です。人事情報・教務情報を元に自動的に発行します。\r\n" +
      $"もし採用・入学後にＭＩＤが届かない場合は、お手数ですが情報基盤センターまでお問い合わせ下さい。\r\n" +
      $"大学所属以外の方についても、本学システムの利用など、発行が必要と認められた場合に限り、ＭＩＤを発行いたします。\r\n" +
      $"申請書および職名を証明できる書類等の写しを添付の上、情報基盤センターに提出してください。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("MID_パスワード忘れ")]
    public async Task MID_forgetPass(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"教職員については、情報基盤センターもしくは医学部医療情報部にお問い合わせください。\r\n" +
      $"学生の方がパスワードを忘れた際は、パスワード再発行の申請が必要です。申請書に記入の上、情報基盤センターまでお越しください。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("情報基盤センター＿概要")]
    public async Task Center_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"本学の教職員（ＭＩＤを保持しない方、組織用など）もしくは共同研究者などの学外者に対して、情報基盤センター一般利用者アカウントを発行しています。\r\n" +
      $"本アカウントは以下の情報システムで利用できます。\r\n" +
      $"•電子メール（＠cc）、Webサイトの開設、演算サーバ（Linux）\r\n" +
      $"•木花キャンパスのネットワーク認証（有線・無線）\r\n" +
      $"また、すでに宮崎大学統一認証アカウント（ＭＩＤ）を保有されている教職員の方で、Webサイトの開設を希望される方は本申請で受け付けています。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("情報基盤センター＿利用者")]
    public async Task Center_user(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"【情報基盤センター利用者】\r\n" +
      $"•本学の教職員\r\n" +
      $"•情報基盤センター長が適当と認めた方（学外者）\r\n" +
      $"【受入先担当者／代表者】\r\n" +
      $"•本学の教職員");
      context.Wait(MessageReceived);
    }

    [LuisIntent("情報基盤センター＿利用期限")]
    public async Task Center_limit(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"本学の教職員：在職中は継続して利用できます。\r\n" +
      $"情報基盤センター長が適当と認めた方（学外者）：申請年度内に限ります。\r\n" +
      $"翌年度も続けて利用される場合は【情報基盤センター利用申請書【学内制限】】を提出してください。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("情報基盤センター＿申請")]
    public async Task Center_appli(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"新規・廃止：" +
      $"情報基盤センターオンライン申請【学内制限】(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)が利用できます。\r\n" +
      $"新規・変更・継続・廃止：情報基盤センター利用申請書（ＰＤＦ版、Ｗｏｒｄ版【学内制限】）を提出して下さい。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("学認ID＿概要")]
    public async Task ID_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"学認認証フェデレーションとは、学術e-リソースを利用する大学、学術e-リソースを提供する機関・出版社等から構成された連合体のことです。\r\n" +
      $"各機関はフェデレーションが定めた規定（ポリシー）を信頼しあうことで、相互に認証連携を実現することが可能となります。（学認サイトより引用）\r\n" +
      $"宮崎大学は学認認証フェデレーションに参加しており、情報基盤センターが発行する学認IDを取得することで、各機関が提供する電子ジャーナル、多地点接続などの各種サービスを受けることができます。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("学認ID_申請")]
    public async Task ID_appli(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"学認IDの利用は本学の教職員・学生に限ります。\r\n" +
      $"【教職員】\r\n" +
      $"情報基盤センター発行のメールアドレス（@cc）が必要です。発行を受けていない方は、先に情報基盤センター一般利用申請から申請を行ってください。\r\n" +
      $"【学生】\r\n" +
      $"入学時に発行される情報基盤センター発行のメールアドレス（@student）を用意してください。\r\n" +
      $"詳しくは" +
      $"こちら(http://www.cc.miyazaki-u.ac.jp/gakunin/GakuNin.html)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("有線ネットワーク_概要")]
    public async Task WiredNetwork_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"有線LANには情報コンセントごとにユニークな管理番号が振られています。各情報コンセントには運用責任者が設けられており、接続する際は運用責任者の承認を受けて利用してください。\r\n" +
      $"研究室を初めて割り当てられた方や、引越しなどにより居室が変更になった場合は情報コンセント運用責任者の申請を行なってください。\r\n" +
      $"情報コンセントを新設・移設したい場合などは、情報基盤センター基盤部門までご相談ください");
      context.Wait(MessageReceived);
    }

    [LuisIntent("有線ネットワーク_利用方法")]
    public async Task WiredNetwork_how(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"情報コンセントとパソコンなどの端末を接続すると、DHCPサーバにより自動的にIPアドレスを取得してネットワーク接続が行われます。\r\n" +
      $"その後、IEやFirefoxなどのブラウザを開いて、ネットワーク認証を行うことで接続が完了します。\r\n" +
      $"ネットワーク認証に利用できるIDは以下のとおりです。\r\n" +
      $"•宮崎大学統一認証アカウント（MID）\r\n" +
      $"•情報基盤センター利用者アカウント\r\n" +
      $"•ゲストネットワーク用アカウント\r\n" +
      $"•無通信時間が１時間\r\n" +
      $"•最初の認証から１２時間経過");
      context.Wait(MessageReceived);
    }

    [LuisIntent("有線ネットワーク_申請")]
    public async Task WiredNetwork_appli(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"有線LANは情報コンセント運用責任者のみ申請が必要です。\r\n" +
      $"利用に関しては情報基盤センターへの申請は不要です。\r\n" +
      $"情報コンセント運用責任者については、以下のいずれかで申請して下さい。\r\n" +
      $"情報基盤センターオンライン申請(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)\r\n" +
      $"情報コンセント運用責任者申請提出");
      context.Wait(MessageReceived);
    }

    [LuisIntent("無線ネットワーク＿概要")]
    public async Task WireLess_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"情報基盤センターは、木花キャンパスにおける無線ネットワークの管理・運用を行なっています。\r\n" +
      $"情報基盤センターが管理する無線LANは" +
      $"こちら(https://www.cc.miyazaki-u.ac.jp/service/internal/wlan.php)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("無線ネットワーク＿利用")]
    public async Task WireLess_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"初めてSSIDにパソコンなどの端末を接続するとセキュリティコードを求められます。「miyazaki-u」と打ち込んでください。\r\n" +
      $"正しいコードを入力して接続すると自動的にIPアドレスを取得してネットワーク接続が行われます。\r\n" +
      $"その後、IEやFirefoxなどのブラウザを開いて、ネットワーク認証を行うことで接続が完了します。\r\n" +
      $"ネットワーク認証に利用できるIDは以下のとおりです。\r\n" +
      $"•宮崎大学統一認証アカウント（MID）\r\n" +
      $"•情報基盤センター利用者アカウント\r\n" +
      $"•ゲストネットワーク用アカウント\r\n" +
      $"なお、ネットワーク認証はタイムアウトがあり、以下の時間を過ぎると再認証が発生します。\r\n" +
      $"•無通信時間が１時間\r\n" +
      $"•最初の認証から１２時間経過");
      context.Wait(MessageReceived);
    }

    [LuisIntent("固定IPアドレス＿概要")]
    public async Task IPadress_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"プリンターなどのネットワーク認証ができない機器やサーバ用途などで固定IPアドレスが必要な機器などについては、固定IPアドレスを発行しています。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("固定IPアドレス＿申請")]
    public async Task IPadress_appli(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"固定IPアドレスの申請には、情報コンセント番号と機器のMACアドレスが必要です。\r\n" +
      $"情報コンセント番号とは、各部屋にある有線LANの差込口に振られた英字3、数字3のユニークな番号です。\r\n" +
      $"申請はこちら(学内制限):(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("ファイアウォール＿概要")]
    public async Task FireWall_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"学外から木花キャンパスネットワークに対しての通信は原則遮断しています。\r\n" +
      $"学外から木花キャンパスのネットワークに接続している機器に対して接続が必要な場合は、ファイウォール申請を行うことで例外的に通信が許可されます。\r\n" +
      $"例えば次のような場合に申請が必要となります。\r\n" +
      $"•外部業者がリモートから学内機器のメンテナンスを行う\r\n" +
      $"•学外者と学内のネットワーク会議システムを使ってTV会議を行う\r\n" +
      $"•学外者に研究室設置のNASや演算サーバを利用させる\r\n" +
      $"なお、学内の機器については固定IPアドレスを事前に取得してください。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("ファイアウォール＿申請")]
    public async Task FireWall_appli(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"ファイアウォール通信許可申請には以下の情報が必要です。\r\n" +
      $"•接続元IPv4アドレス\r\n" +
      $"•接続先(学内)IPv4アドレス\r\n" +
      $"•接続先(学内)FQDN(任意)\r\n" +
      $"•サービスポート(ポート番号 / プロトコル)\r\n" +
      $"•利用用途\r\n" +
      $"申請は" +
      $"こちら(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("SSL-VPNサービス＿概要")]
    public async Task SSL_VPN_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"SSL-VPNサービスは学外から木花キャンパスにある情報システムに対してセキュアにアクセスする手段です。\r\n" +
      $"これにより、宮崎大学の学内専用Webサイトの閲覧や情報基盤センターのオンラインストレージ等をSSL-VPNを経由して利用できます。\r\n" +
      $"ただし、事務シンクライアントシステムおよび附属図書館が提供する電子ジャーナルにはアクセスできません。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("SSL-VPNサービス＿利用")]
    public async Task SSL_VPN_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"SSL-VPNを利用するには申請は不要ですが、" +
      $"接続するパソコンに専用のソフトウェアをインストールする必要があります。(学内制限)\r\n" +
      $"Windows7/8/8.1 32/64bit(https://www.cc.miyazaki-u.ac.jp/software/sslvpnclient_win.exe)\r\n" +
      $"Windows10 32bit(https://www.cc.miyazaki-u.ac.jp/software/FortiClientSetup_5.4.3.0870.exe)\r\n" +
      $"Windows10 64bit(https://www.cc.miyazaki-u.ac.jp/software/FortiClientSetup_5.4.3.0870_x64.exe)\r\n" +
      $"利用できるIDは宮崎大学統一認証アカウント（MID）です。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("ゲストネットワーク＿概要")]
    public async Task GuestNet_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"本学教職員以外の学外者が本学の情報システムを利用するにあたって、木花キャンパスの情報ネットワーク(有線・無線)での接続が必要な場合に限り、" +
      $"ネットワーク認証専用のゲスト用アカウントを臨時で発行しています。\r\n" +
      $"インターネットを利用するだけの目的であれば、「eduroam」または「FreeSpot」をご利用下さい。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("ゲストネットワーク＿利用")]
    public async Task GuestNet_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"〇申請者：本学の教職員（常勤）に限ります。\r\n" +
      $"〇利用期限：\r\n" +
      $"最長で申請年度となります。\r\n" +
      $"〇申請にあたって：\r\n" +
      $"利用の１週間前までに申請を行って下さい。アカウント数によっては、発行が遅くなる場合があります。\r\n" +
      $"〇利用にあたって：\r\n" +
      $"申請者の責任の下でアカウントの管理およびネットワーク接続を行って下さい。" +
      $"情報基盤センターオンライン申請【学内制限】(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)が利用できます。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("eduroam＿概要")]
    public async Task Eduroam_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"eduroam（エデュローム）は、欧州のGEANT Associationで開発された学術無線LANローミング基盤で、日本では国立情報学研究所（NII）がeduroamJPサービスを運用しており、本学はこのeduroamJPに参加しています。\r\n" +
      $"これにより、本学の教職員、学生がeduroamに参加している機関へ出張した際は、出張先の無線LAN「eduroam」が利用できます。\r\n" +
      $"また、eduroamに参加している機関の方が本学木花キャンパスに来学した場合にも、申請なしに無線LANを利用できます。\r\n" +
      $"本学で開催する学会や研究会、共同研究などの参加者へのネットワーク提供にご利用ください。\r\n" +
      $"※「eduroam」のネットワークは、学内ネットワークとは別のネットワークです。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("eduroam＿利用")]
    public async Task Eduroam_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"宮崎大学では、木花キャンパスの無線LANの以下のSSIDで利用可能です。\r\n" +
      $"その他の利用可能なサイトは、関連リンクの「eduroam基地局マップ」をご覧ください。\r\n" +
      $"○ＳＳＩＤ：「eduroam」\r\n" +
      $"○ＩＤ／パスワード：\r\n" +
      $"【教職員】@ccメールアドレス／MIDのパスワード\r\n" +
      $"【学生】@studentメールアドレス／MIDのパスワード");
      context.Wait(MessageReceived);
    }

    [LuisIntent("FreeSpot＿概要")]
    public async Task FreeSpot_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"木花キャンパスの無線LANでユーザ認証を必要としないFreeSpotを提供しています。\r\n" +
      $"学会や研究会、共同研究などの来学者へのネットワーク提供にご利用ください。\r\n" +
      $"なお、本学の学内ネットワークとは別のネットワークに接続しますので、本学が運用する学内制限がかかった情報システムには接続できません。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("FreeSpot＿利用")]
    public async Task FreeSpot_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"木花キャンパス無線LANの以下のSSIDで利用可能です。\r\n" +
      $"○ＳＳＩＤ：「FreeSpot」\r\n" +
      $"申請は不要ですが、利用規約を承諾する必要があります。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("Microsoft包括ライセンス")]
    public async Task Microsoft_lisence(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"詳しくは" +
      $"こちら(http://ms.cc.miyazaki-u.ac.jp/)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("ウイルスソフト包括")]
    public async Task VirusSoft(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"平成25年4月より,宮崎大学ウイルス対策ソフトの包括ライセンスを開始し, インストール台数の制限が無く, 大学構成員であれば個人用途の端末でも利用することができます. \r\n" +
      $"【利用の範囲】\r\n" +
      $" •宮崎大学の構成員\r\n" +
      $"•附属幼稚園・小学校・中学校の教職員（附属学校園児・児童・生徒は除く） \r\n" +
      $"【利用可能な端末の範囲】\r\n" +
      $" •大学内の端末\r\n" +
      $"•附属学校内の端末\r\n" +
      $"•上記構成員が所有する端末");
      context.Wait(MessageReceived);
    }

    [LuisIntent("Solidworks 3DCAD")]
    public async Task 3DCAD(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"詳しくは" +
      $"こちら(http://www.cc.miyazaki-u.ac.jp/solidworks/)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("オンラインストレージ＿概要")]
    public async Task OnlineStrage_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"オンラインストレージでは、情報基盤センター内に設置したストレージ上でDropboxなどと同様にファイルの保管や共有、大容量ファイル交換に利用できます。\r\n" +
      $"ただし、情報漏えいを防ぐため学外への公開はできません。(SSL - VPNを介して学外から接続は可能)\r\n" +
      $"保存容量は30GB / 人で世代管理機能を有しており、3世代まで保存できます。\r\n" +
      $"本ストレージ内のファイルは、学外のデータセンターに設置する情報基盤センター資産のストレージにバックアップをしており、災害等に対してデータを保護します。\r\n" +
      $"組織用（グループ利用）としてのID発行も可能です。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("オンラインストレージ＿利用")]
    public async Task OnlineStrage_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"オンラインストレージは宮崎大学統一認証アカウント(MID)保有者はWebブラウザかアプリケーション(Windows限定)から利用可能です。\r\n" +
      $"[詳しくはこちら（学内制限）](https://fshare.ccad.miyazaki-u.ac.jp/)");
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

    [LuisIntent("宮大どこプリ＿量")]
    public async Task Print_number(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"1人1年間に印刷できる枚数には上限が設定されており、各印刷上限枚数は各学部ごとに決定されています。\r\n" +
      $"詳しくは" +
      $"こちら(https://www.cc.miyazaki-u.ac.jp/service/dokopri.php)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("宮大どこプリ＿利用")]
    public async Task Print_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"申請は不要ですが、パソコンにドライバーのインストールが必要です。\r\n" +
      $"パソコンに合わせたドライバーをダウンロードして、インストールしてください。\r\n" +
      $"•Windows7 32bit(https://www.cc.miyazaki-u.ac.jp/software/MDP_win32_7.exe)\r\n" +
      $"•Windows7 64bit(https://www.cc.miyazaki-u.ac.jp/software/MDP_win64_7.exe)\r\n" +
      $"•Windows8.1/10 32bit(https://www.cc.miyazaki-u.ac.jp/software/MDP_win32_8.1-10.exe)\r\n" +
      $"•Windows8.1/10 64bit(https://www.cc.miyazaki-u.ac.jp/software/MDP_win64_8.1-10.exe)\r\n" +
      $"•Windows 32bit(ENGLISH)(https://www.cc.miyazaki-u.ac.jp/software/MDP_win32_Eng.exe)\r\n" +
      $"•Windows 64bit(ENGLISH)(https://www.cc.miyazaki-u.ac.jp/software/MDP_win64_Eng.exe)\r\n" +
      $"•MacOS(https://www.cc.miyazaki-u.ac.jp/software/MDP_Mac.dmg)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("電子メール＿概要")]
    public async Task Mail_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"学生および2014年以降に採用された教職員に対して入学／採用時に一律してメールアドレスの発行を行なっています。(一般：@cc、学生：@student)\r\n" +
      $"また、共同研究者等の学外者や学部等の組織に対しても希望があれば申請を行うことで発行を認めています。\r\n" +
      $"なお、サーバ上に保存できる容量は以下のとおりです。\r\n" +
      $"•教職員：2GB\r\n" +
      $"•学生：1GB\r\n" +
      $"教職員は、メール保存容量増量申請(学内制限)を行うことで、最大5GBまで増量ができます。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("電子メール＿利用")]
    public async Task Mail_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"メールソフト(Outlook,Thunderbirdなど)での送受信以外に、Webブラウザで送受信可能なWebメールも利用可能です。\r\n" +
      $"教職員用メール(https://wm.cc.miyazaki-u.ac.jp/cgi-bin/index.cgi)\r\n" +
      $"学生用メール(https://wm.student.miyazaki-u.ac.jp/cgi-bin/index.cgi)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("電子メール＿変更")]
    public async Task Mail_change(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"本学教職員については、一度のみ自身でのメールアドレスの変更が可能です。\r\n" +
      $"変更はMID情報変更サイト(https://mauth-ap.cc.miyazaki-u.ac.jp/webmtn/LoginServlet)から変更してください。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("電子メール＿申請")]
    public async Task Mail_appli(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"本学教職員(2014年以降採用)もしくは学生に関しては申請は不要です。\r\n" +
      $"それ以外の教職員、学外者もしくは組織に関しては、" +
      $"情報基盤センター利用申請(https://www.cc.miyazaki-u.ac.jp/service/ccid.php)から申請してください。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("実習室システム＿概要")]
    public async Task PracticeRoom_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"センター内実習室Aに授業や自習で利用できるパソコン（Windows8.1）を配置しています。\r\n" +
      $"宮崎大学統一認証アカウント(MID)を保有している方ならどなたでも自由に利用できます。\r\n" +
      $"利用時間は8：30-17：00\r\n" +
      $"実習室A：PC64台\r\n" +
      $"実習室B1：PCなし　61個の電源、LANケーブル\r\n" +
      $"実習室B2：PCなし　22個の電源、LANケーブル\r\n" +
      $"PCで利用できるアプリケーションは以下のとおりです。\r\n" +
      $"Microsoft Office\r\n" +
      $"Adobe Design Std CS5\r\n" +
      $"SolidWorks 2014\r\n" +
      $"Visual Studio2013");
      context.Wait(MessageReceived);
    }

    [LuisIntent("実習室システム＿利用")]
    public async Task PracticeRoom_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"授業で利用される場合は、" +
      $"実習室利用申請(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)を行なってください。\r\n" +
      $"授業以外で利用される場合は、授業が入っていない間は利用可能です。\r\n" +
      $"時間割を確認して利用してください。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("メーリングリスト＿概要")]
    public async Task MailingList_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"ある特定の宛先に電子メールを送ると、その電子メールはあらかじめ登録されている人全員に配送されるサービスです。\r\n" +
      $"メーリングリスト申請者（管理者）は教職員に限りますが、利用者の追加・削除はWeb管理画面から自由に行えます。\r\n" +
      $"メール投稿について、制限を設けることができるため、問い合わせ用や学生への一斉配信用、グループ内だけの投稿など様々な用途に利用できます。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("メーリングリスト＿利用")]
    public async Task MailingList_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"通常の電子メールの宛先と同様に発行を受けた【メーリングリスト名】@cc.miyazaki-u.ac.jpを宛先にすることで、登録された利用者に一斉にメールが配信されます。\r\n" +
      $"管理画面については、承認書にURLが記載されています。利用方法については、以下の説明をご確認ください。\r\n" +
      $"メーリングリスト管理方法（簡易版）(学内制限)(https://www.cc.miyazaki-u.ac.jp/document/manual/internal/ML-manual.pdf)\r\n" +
      $"メーリングリスト管理方法（詳細版）(学内制限)(https://www.cc.miyazaki-u.ac.jp/document/manual/internal/DEEPML-UsersManual.pdf)\r\n" +
      $"また、申請者（管理者）は学内の教職員に限ります。\r\n" +
      $"情報基盤センターオンライン申請(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("メーリングリスト＿注意点")]
    public async Task MailingList_attention(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"以下の状況において、情報基盤センターはメーリングリストの運用を停止します。\r\n" +
      $"•宮崎大学ネットワーク利用規程、宮崎大学ネットワーク管理者ガイドラインに抵触する場合。\r\n" +
      $"•宮崎大学の情報システム全体の運用に支障をきたす恐れがあると情報基盤センター長が判断した場合。\r\n" +
      $"新しいメーリングリストの作成、削除、メーリングリスト管理者の登録、パスワードの変更は情報基盤センターで行います。\r\n" +
      $"年度末（3月上旬）に情報基盤センターからメーリングリスト管理者宛にメーリングリストを続けるかどうかの問い合わせメールを送ります。\r\n" +
      $"希望するメーリングリスト名を、3つ記入してください。\r\n" +
      $"•メーリングリスト名には先頭を英小文字とする4文字以上の英小文字、数字、記号[-(マイナス)、_(下線)]が使えます。1(イチ)、l(エル)、0(ゼロ)、o(オー)など紛らわしくないように記入してください。\r\n" +
      $"メーリングリスト名は、すでに存在するメールアドレスやSYSTEMで予め予約されている名前は使用出来ません。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("学生一斉メール＿概要")]
    public async Task AllStudentMail_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"@student保有の全学部生・院生に対してシステムから一斉にメール配信するサービスです。\r\n" +
      $"学生に対して通知を行いたい場合などに利用できます。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("学生一斉メール＿利用")]
    public async Task AllStudentMail_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"添付ファイルをつけることができません。\r\n" +
      $"ウェブサイト上に添付ファイルを設置し、URLを本文中に記載するようにしてください。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("Web公開サービス＿個人")]
    public async Task Web_personal(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"本学の教職員（ＭＩＤ保有者）もしくは学外者などで情報基盤センター一般利用者アカウントの発行を受けた方に対してWebサービスです。URLは以下のとおりです。" +
      $"www.cc.miyazaki - u.ac.jp /○○○/ (○○○は申請した際の、公開パス)" +
      $"システムの基本設定として、全IPからのアクセスを拒否しています。" +
      $"各自でアクセス制限の範囲を設定してからWebサイトの公開を行います。" +
      $"詳しくは" +
      $"こちら(https://www.cc.miyazaki-u.ac.jp/service/web.php)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("Web公開サービス＿組織")]
    public async Task Web_organization(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"本学の学部・学科・事務部・センターなどの組織に対してのWebサービスです。URLは以下のとおりです。" +
      $"www.miyazaki - u.ac.jp /○○○/ (○○○は申請した際の、公開パス)" +
      $"システムの基本設定として、全IPからのアクセスを許可しています。" +
      $"各自でアクセス制限の範囲を設定してからWebサイトの公開を行います。" +
      $"詳しくは" +
      $"こちら(https://www.cc.miyazaki-u.ac.jp/service/web-organization.php)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("Web公開サービス＿学生")]
    public async Task Web_student(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"本学の学生（ＭＩＤ保有者）に対して授業で利用できるWebサービスです。URLは以下のとおりです。" +
      $"www.student.miyazaki - u.ac.jp /○○○/ (○○○はメールアドレスの@以前)" +
      $"システムの基本設定として、学内制限に設定しています。" +
      $"各自で変更はできません。" +
      $"詳しくは" +
      $"こちら(https://www.cc.miyazaki-u.ac.jp/service/web-stu.php)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("大判プリンタ＿概要")]
    public async Task BigPrint_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"大判プリンタ（EPSON, MAXART F10000）１台を導入しており、光沢紙、マット紙、普通紙の印刷が可能です。\r\n" +
      $"なお、予算振替が可能な方、もしくは申請者が許可した方も利用可能ですが、その場合は申請者から利用料が徴収されます。\r\n" +
      $"なお、毎年6月、9月、12月及び3月の四半期毎に当該期間の合計額を翌月に請求します。");
      context.Wait(MessageReceived);
    }


    [LuisIntent("大判プリンタ＿利用")]
    public async Task BigPrint_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"情報基盤センターに直接お越しいただき、予約に空きがあればすぐに印刷が可能ですが、事前に空き状況の確認も兼ねて情報基盤センター（内線2867）までご連絡ください。\r\n" +
      $"下記の印刷可能なファイル一覧のフォーマットをUSBメモリ等で持参し、各自で印刷を行います。\r\n" +
      $"○印刷可能なファイル\r\n" +
      $"PDF\r\n" +
      $"Word\r\n" +
      $"Excel\r\n" +
      $"PowerPoint" +
      $"大判プリンタ利用申請書(https://www.cc.miyazaki-u.ac.jp/document/internal/printer.docx)を記入の上、印刷の際に情報基盤センターに持参してください"); //
      context.Wait(MessageReceived);
    }

    [LuisIntent("仮想サーバ貸出＿概要")]
    public async Task VirtualServer_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"学内に多数存在するサーバを集約することにより、ハードウェアに係るコストを削減し、効率的・有効的なサーバの運用を図ることを目的として、仮想サーバの貸出を行なっています。\r\n" +
      $"貸出対象は、学部・学科・研究室単位で、責任者および技術的管理者が明確である必要があります。\r\n" +
      $"情報基盤センターでは、ハードウェアまでの管理を行いますが、OSを含むソフトウェアの管理は利用者で行います。\r\n" +
      $"詳しくは、" +
      $"仮想サーバ利用要項(https://www.cc.miyazaki-u.ac.jp/document/kasouyoukou.pdf)を確認してください。"); //
      context.Wait(MessageReceived);
    }

    [LuisIntent("仮想サーバ貸出＿申請")]
    public async Task VirtualServer_appli(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"仮想サーバ貸出申請については" +
      $"情報基盤センターオンライン申請(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)が利用できます。"); //
      context.Wait(MessageReceived);
    }

    [LuisIntent("サーバ証明書発行＿概要")]
    public async Task ServerSertificate_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"宮崎大学は、国立情報学研究所が提供するUPKI電子証明書発行サービスに参加しており、以下の電子証明書が利用者負担なしで発行可能です。\r\n" +
      $"サーバ証明書(RSA2048bit)\r\n" +
      $"クライアント証明書\r\n" +
      $"コード署名用証明書" +
      $"本学教職員(MID保有者)のみ申請可能です。"); //
      context.Wait(MessageReceived);
    }

    [LuisIntent("サーバ証明書発行＿利用")]
    public async Task ServerSertificate_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"各マニュアルを参照して、オンライン申請よりTSVファイルを提出してください。\r\n" +
      $"•証明書自動発行支援システム操作手順書(利用管理者用)(https://certs.nii.ac.jp/?action=repository_uri&item_id=8&file_id=22&file_no=5)\r\n" +
      $"•証明書自動発行支援システムサーバ証明書インストールマニュアルApache2.0系 + mod_ssl 編(https://certs.nii.ac.jp/?action=repository_uri&item_id=1&file_id=22&file_no=3)\r\n" +
      $"•UPKI電子証明書自動発行支援システムサーバ証明書インストールマニュアルApache1.3 - mod_ssl編(https://certs.nii.ac.jp/?action=repository_uri&item_id=2&file_id=22&file_no=3)\r\n" +
      $"•UPKI電子証明書自動発行支援システムサーバ証明書インストールマニュアルApache - SSL編(https://certs.nii.ac.jp/?action=repository_uri&item_id=3&file_id=22&file_no=3)\r\n" +
      $"•UPKI電子証明書自動発行支援システムサーバ証明書インストールマニュアルIIS7.0・IIS7.5編(https://certs.nii.ac.jp/?action=repository_uri&item_id=4&file_id=22&file_no=5)\r\n" +
      $"•UPKI電子証明書自動発行支援システムサーバ証明書インストールマニュアルIIS8.0・IIS8.5編(https://certs.nii.ac.jp/?action=repository_uri&item_id=16&file_id=22&file_no=4)\r\n" +
      $"•UPKI電子証明書自動発行支援システムサーバ証明書インストールマニュアルTomcat編(https://certs.nii.ac.jp/?action=repository_uri&item_id=6&file_id=22&file_no=3)\r\n" +
      $"TSVファイルに問題がなければ、数日中にダウンロードサイトのURLが記載されたメールが届きます。\r\n" +
      $"各自でアクセスして証明書をダウンロードしてサーバ等にインストールしてください。");
      //  $"情報基盤センターオンライン申請(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)が利用できます。");
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
      $"CNS2.CC.MIYAZAKI-U.JP");
      context.Wait(MessageReceived);
    }

    [LuisIntent("メールゲートウェイ")]
    public async Task MailGateWay(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"メールゲートウェイでは、悪意のある既知のIPアドレスから送信された電子メールの検査や添付ファイルのウイルス検査、スパムメールの検査を行っています。\r\n" +
      $"検査は送受信ともに行われます。\r\n" +
      $"ウイルスメールやスパムメールと判定された電子メールは利用者には配送されず削除されます。\r\n" +
      $"ただし、最新のウイルスや暗号化されたファイルが添付されているものは検査できませんので、電子メール利用者は細心の注意を図り利用するようお願いします。\r\n" +
      $"メールゲートウェイ経由となっているサブドメインのメールサーバは" +
      $"こちら(https://www.cc.miyazaki-u.ac.jp/service/mailgw.php)");
      context.Wait(MessageReceived);
    }

    [LuisIntent("定期メンテナンス")]
    public async Task Maintenance(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"情報基盤センターでは、情報セキュリティに関する様々な脅威に対応するため、情報基盤センターが管理する各種情報システムについて、下記の日時で定期メンテナンスを行なっています。\r\n" +
      $"実施予定日時：毎月第3土曜9:00 - 16:00\r\n" +
      $"メンテナンスに際して、サービス停止を発生させずに実施する予定ですが、メンテナンス内容によっては断続的に停止する可能性がありますのでご了承願います。");
      context.Wait(MessageReceived);
    }

    [LuisIntent("業務依頼サービス")]
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
      $"情報基盤センターオンライン申請(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)より申請してください。"); //
      context.Wait(MessageReceived);
    }

    [LuisIntent("テレビ会議システム")]
    public async Task TVMeeting(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"テレビ会議専用機として下記の製品を保有しており、貸出も行っています。\r\n" +
      $"ソニー製　HDビデオ会議システム　PCS-XG80（持ち運び可）２台\r\n" +
      $"ソニー製　HDビデオ会議システム　PCS-XG55（常設）１台\r\n" +
      $"Polycom製　HDX7000（常設）１台\r\n" +
      $"また、テレビ会議等に利用できる機材として以下も貸出できます。詳しくは情報基盤センターまでご連絡ください。\r\n" +
      $"•ソニー製ライブコンテンツプロデューサーAWS - 750（持ち運び可）１台\r\n" +
      $"•HD対応HDDビデオカメラ　１台\r\n" +
      $"•HD対応ビデオカメラ　１台\r\n" +
      $"•三脚\r\n" +
      $"•HDMI分配器\r\n" +
      $"•RGB分配器\r\n" +
      $"•HDMIケーブル\r\n" +
      $"•RGBケーブル\r\n" +
      $"•有線マイク\r\n" +
      $"•マイク用ケーブル\r\n" +
      $"•RCAケーブル"); //
      context.Wait(MessageReceived);
    }

    [LuisIntent("Web会議システム＿概要")]
    public async Task WebMeeting_overview(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"マルチデバイス（PC、タブレット、スマートフォン）に対応したWeb会議システム（Vidyo）を提供しています。\r\n" +
      $"基本的には専用ソフトウェアをインストールすることで会議を行いますが、TV会議専用装置を使用して接続することも可能です。\r\n" +
      $"最大３０拠点（専用装置は３台まで）の同時接続が可能です。\r\n" +
      $"なお、利用は先着順の予約制です。"); //
      context.Wait(MessageReceived);
    }

    [LuisIntent("Web会議システム＿利用")]
    public async Task WebMeeting_use(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"パソコン等に専用ソフトウェアのインストールが必要です。\r\n" +
      $"初回接続時にインストールを求められるのでインストールしてください。\r\n" +
      $"申請は" +
      $"こちら(http://himuka.cc.miyazaki-u.ac.jp/E-application/login.php)"); //
      context.Wait(MessageReceived);
    }

    [LuisIntent("ハウジングサービス")]
    public async Task Housing(IDialogContext context, LuisResult result)
    {
      await context.PostAsync($"研究室などに設置されている重要なサーバ機を情報基盤センター内に設置できるスペースを用意しております。\r\n" +
      $"情報基盤センターは、無停電電源装置や3日間電源供給できる自家発電機を有しております。\r\n" +
      $"また、入退室管理や監視カメラなどの環境監視、耐震対策も行っていますので安心・安全な環境で運用できます。\r\n" +
      $"ハウジングした機器が使用した電力量は常時測定しており、単価10円/Kwhで計算し徴収します。"); //
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
