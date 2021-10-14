using ProjectRunner.WPF.Enums;
using System.Windows;
using System.Windows.Controls;

namespace ProjectRunner.WPF.Components
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

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(FormField), new PropertyMetadata(""));

        public EFormFieldType Type
        {
            get => (EFormFieldType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(EFormFieldType), typeof(FormField), new PropertyMetadata(EFormFieldType.Text));

        public FormField()
        {
            InitializeComponent();
        }
    }
}
