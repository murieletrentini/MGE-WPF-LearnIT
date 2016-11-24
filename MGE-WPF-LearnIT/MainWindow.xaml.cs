using MGE_WPF_LearnIT.Entities;  
using System.Windows;


namespace MGE_WPF_LearnIT
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
         
            // Initialize
            this.InitializeComponent();

            CardSet set1 = new CardSet("Englisch Voci");
            //ToDo: how to access methods from app??
            // App.AddSet(set1);
            
            // Populate list
            //ToDo: for each CardSet in cardSetList from App
            this.listView.Items.Add(set1);
        }

       
    }
}
