using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MGE_WPF_LearnIT
{
    /// <summary>
    /// Interaction logic for IconTextButton.xaml
    /// </summary>
    public partial class IconTextButton : UserControl
    {
        public static readonly DependencyProperty BtnTextProperty = DependencyProperty.Register("BtnText", typeof(string), typeof(IconTextButton));
        public static readonly DependencyProperty BtnIconProperty = DependencyProperty.Register("BtnIcon", typeof(string), typeof(IconTextButton));
        
        public string BtnText
        {
            get { return (string)GetValue(BtnTextProperty); }
            set { SetValue(BtnTextProperty, value); }
        }

        public string BtnIcon
        {
            get { return (string)GetValue(BtnIconProperty); }
            set { SetValue(BtnIconProperty, value); }
        }


        public IconTextButton() {
            InitializeComponent();
            this.DataContext = this;
        }

        public event RoutedEventHandler Click;

        void onButtonClick(object sender, RoutedEventArgs e) {
            if (this.Click != null) {
                this.Click(this, e);
            }
        }


    }
}
