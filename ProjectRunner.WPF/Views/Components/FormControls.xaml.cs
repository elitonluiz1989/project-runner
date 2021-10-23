using System.Windows;
using System.Windows.Controls;

namespace ProjectRunner.WPF.Views.Components
{
    public partial class FormControls : UserControl
    {
        public static readonly RoutedEvent OnCancelEvent = EventManager.RegisterRoutedEvent("OnCancel", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FormControls));

        public event RoutedEventHandler OnCancel
        {
            add { AddHandler(OnCancelEvent, value); }
            remove { RemoveHandler(OnCancelEvent, value); }
        }

        public static readonly RoutedEvent OnSaveEvent = EventManager.RegisterRoutedEvent("OnSave", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FormControls));

        public event RoutedEventHandler OnSave
        {
            add { AddHandler(OnSaveEvent, value); }
            remove { RemoveHandler(OnSaveEvent, value); }
        }

        public FormControls()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs onCancelEventArgs = new(OnCancelEvent);
            RaiseEvent(onCancelEventArgs);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs onSaveEventArgs = new(OnSaveEvent);
            RaiseEvent(onSaveEventArgs);
        }

    }
}
