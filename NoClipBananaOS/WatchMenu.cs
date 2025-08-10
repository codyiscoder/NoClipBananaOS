using BananaOS;
using BananaOS.Pages;
using System.Text;

namespace NoClipBananaOS
{
    internal class WatchMenu : WatchPage
    {
        public override string Title => "<color=green>NoClip</color>";
        public override bool DisplayOnMainMenu => true;

        public override string OnGetScreenContent()
        {
            var BuildMenuOptions = new StringBuilder();
            BuildMenuOptions.AppendLine("<color=black>========================</color>");
            BuildMenuOptions.AppendLine("<align=center><color=green>NoClip</color>");
            BuildMenuOptions.AppendLine("");
            BuildMenuOptions.AppendLine("<align=center>By: <color=blue>Estatic</color>");
            BuildMenuOptions.AppendLine("<color=black>========================</color>");
            BuildMenuOptions.AppendLine("");
            BuildMenuOptions.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, $"[Enabled : {Plugin.IsEnabled}] "));
            return BuildMenuOptions.ToString();
        }

        public override void OnButtonPressed(WatchButtonType buttonType)
        {
            switch (buttonType)
            {
                case WatchButtonType.Down:
                    selectionHandler.MoveSelectionDown();
                    break;

                case WatchButtonType.Up:
                    selectionHandler.MoveSelectionUp();
                    break;

                case WatchButtonType.Enter:
                    if (selectionHandler.currentIndex == 0)
                        Plugin.IsEnabled = !Plugin.IsEnabled;
                    break;

                case WatchButtonType.Back:
                    ReturnToMainMenu();
                    break;
            }
        }
    }
}
