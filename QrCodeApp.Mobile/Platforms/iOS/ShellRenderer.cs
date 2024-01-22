using System;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace QrCodeApp.Mobile.Platforms.iOS;

public class CustomShellRenderer : ShellRenderer
{
    protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
    {
        return new CustomShellTabBarAppearanceTracker();
    }
}
