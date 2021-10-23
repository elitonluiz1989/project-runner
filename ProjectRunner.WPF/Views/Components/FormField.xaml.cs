using Microsoft.Win32;
using ProjectRunner.WPF.Enums;
using System.Windows;
using System.Windows.Controls;

namespace ProjectRunner.WPF.Views.Components
{
    public partial class FormField : UserControl
    {
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(FormField), new PropertyMetadata("Field"));

        public EFormFieldType Type
        {
            get => (EFormFieldType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(EFormFieldType), typeof(FormField), new PropertyMetadata(EFormFieldType.Text));
        public object Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(FormField), new PropertyMetadata(null));

        public FormField()
        {
            InitializeComponent();
        }

        private void BtnDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            bool? result = openFileDialog.ShowDialog();

            if (result.Value)
            {
                string file = openFileDialog.FileName;
                Value = file;
            }
        }
    }
}
