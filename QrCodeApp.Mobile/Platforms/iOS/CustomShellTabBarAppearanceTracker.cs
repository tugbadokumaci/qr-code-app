using System;
using Microsoft.Maui.Controls.Platform.Compatibility;
using UIKit;

namespace QrCodeApp.Mobile.Platforms.iOS;

public class CustomShellTabBarAppearanceTracker : ShellTabBarAppearanceTracker
{
    public override void UpdateLayout(UITabBarController controller)
    {
        base.UpdateLayout(controller);

        // Adjust image insets to center the icon
        foreach (var item in controller.TabBar.Items)
        {
            item.ImageInsets = new UIEdgeInsets(6, 0, -6, 0); // Adjust values as needed
        }
    }
}