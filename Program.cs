namespace PTiraz
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            if (args.Length == 0)
            {
                Application.Run(new SelectServer());
            }
            else
            {
                // 引数を取得してグローバル変数に設定
                GlobalV.ServerName = args[0];
                if (int.TryParse(args[1], out int eventNo))
                {
                    GlobalV.EventNo = eventNo;
                }
                else
                {
                    MessageBox.Show("イベント番号が無効です。");
                    return;
                }

                // メインフォームを表示
                Application.Run(new MainForm());
            }
        }

    }
    public static class GlobalV
        {
            public const string MagicWord = "\\SQLEXPRESS;Encrypt=True;TrustServerCertificate=True;";
            public const string MagicHead = "Persist Security Info=False;User ID=Sw;Password=;Initial Catalog=Sw;Server=";
            public static int EventNo;
            public static string ServerName = string.Empty;
        }

}