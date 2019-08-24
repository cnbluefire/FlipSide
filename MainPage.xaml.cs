using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace FlipSide
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            _FlipSide.AddHandler(PointerReleasedEvent, new PointerEventHandler(OnFlipSidePointerReleased), true);
        }

        private void OnFlipSidePointerReleased(object sender, PointerRoutedEventArgs e)
        {
            var position = e.GetCurrentPoint(_FlipSide).Position;
            var v2 = (position.ToVector2() - _FlipSide.RenderSize.ToVector2() / 2);
            _FlipSide.Axis = new Vector2(-v2.Y, v2.X);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _FlipSide.IsFlipped = !_FlipSide.IsFlipped;
        }
    }
}
