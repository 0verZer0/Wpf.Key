using System.Windows;
using System.Windows.Controls;

namespace Zer0Key
{
    public class BaseKey : UserControl
    {
        public string TextContent
        {
            get => (string)GetValue(TextContentProperty);
            set => SetValue(TextContentProperty, value);
        }

        public static readonly DependencyProperty TextContentProperty =
            DependencyProperty.Register(nameof(TextContent), typeof(string), typeof(BaseKey), new PropertyMetadata(string.Empty));

    }
}
