using System.Windows;

namespace OVF.Administrator.GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region "members"

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            if (CheckIfConfigExists() == false)
            {
                txtPassword2.Visibility = Visibility.Visible;
            }
            else
            {
                txtPassword2.Visibility = Visibility.Hidden;
            }
        }

        #region "events"
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region "methods"
        #region "private"
        private bool CheckIfConfigExists()
        {
            return OV.Framework.Helper.XML.XMLHelper.CheckIfXmlExists(OVF.Administrator.Logic.Constants.Constants.XMLPATH);
        }
        #endregion
        #endregion
    }
}
