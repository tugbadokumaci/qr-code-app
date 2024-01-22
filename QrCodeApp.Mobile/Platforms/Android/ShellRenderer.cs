using System;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace QrCodeApp.Mobile.Platforms.Android;

class CustomShellHandler : ShellRenderer
{
    protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
    {
        return new Platforms.Android.CustomShellBottomNavViewAppearanceTracker(this, shellItem.CurrentItem);
    }

}