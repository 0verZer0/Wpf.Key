using System.Linq;
using System.Windows;

namespace Zer0Key
{
    public partial class App : Application
    {
        #region Member
        private readonly KeyboardListener KListener = new KeyboardListener();
        #endregion

        #region Override Method
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            KListener.KeyDown += KListener_KeyDown;
            KListener.KeyUp += KListener_KeyUp;

        }
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            KListener.Dispose();
        }
        #endregion

        #region Event Method
        void KListener_KeyDown(object sender, RawKeyEventArgs args)
        {
            var key = args.Key.ToString();

            var visual = SetKeyArt(key);

            foreach (BaseKey item in (MainWindow as MainWindow).KeysPanel.Children.OfType<BaseKey>().ToList())
                if (item.Name == key)
                    return;

            (MainWindow as MainWindow).KeysPanel.Children.Add(visual);
        }
        void KListener_KeyUp(object sender, RawKeyEventArgs args)
        {
            var key = args.Key.ToString();

            foreach (BaseKey item in (MainWindow as MainWindow).KeysPanel.Children.OfType<BaseKey>().ToList())
                if (item.Name == key)
                    (MainWindow as MainWindow).KeysPanel.Children.Remove(item);
        }
        #endregion

        #region Helper Method
        private BaseKey SetKeyArt(string key)
        {

            if (key.Contains("Return"))
                return new ModiferKey
                {
                    Name = key,
                    TextContent = "Enter"
                };
            else if (key.Contains("Win"))
                return new WindowsKey
                {
                    Name = key,
                    TextContent = key
                };
            else if (key.Length > 2)
                return new ModiferKey
                {
                    Name = key,
                    TextContent = key
                };
            else if (key.Contains("D") && key.Length > 1)
                return new DefaultKey
                {
                    Name = key,
                    TextContent = key.Replace("D", string.Empty)
                };
            else
                return new DefaultKey
                {
                    Name = key,
                    TextContent = key
                };
        }
        #endregion
    }
}
