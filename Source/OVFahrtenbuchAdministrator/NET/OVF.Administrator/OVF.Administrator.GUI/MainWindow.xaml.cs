using OVF.Administrator.Logic.Login;
using System;
using System.Windows;

namespace OVF.Administrator.GUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region "members"
        private bool _firstLogin = true;
        private bool _result = false;
        private Login _loginService;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            _loginService = new Login();

            if (CheckIfConfigExists() == false)
            {
                txtPassword2.Visibility = Visibility.Visible;
            }
            else
            {
                txtPassword2.Visibility = Visibility.Hidden;
                lblPassword2.Visibility = Visibility.Hidden;
                _firstLogin = false;
            }
        }

        #region "events"
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_firstLogin)
            {
                _result = _loginService.CheckLogin(OV.Framework.Helper.Crypt.Crypt.EncryptString(txtPassword1.Password),
                                                   OV.Framework.Helper.Crypt.Crypt.EncryptString(txtPassword2.Password));              
            }
            else
            {
                _result = _loginService.CheckLogin(OV.Framework.Helper.Crypt.Crypt.EncryptString(txtPassword1.Password));
            }

            if (_result)
            {
                MessageBox.Show("Yeah");
            }
            
        }
        #endregion

        #region "methods"
        #region "private"
        private bool CheckIfConfigExists()
        {
            return OV.Framework.Helper.XML.XMLHelper.CheckIfXmlExists(OVF.Administrator.Logic.Constants.Constants.ADMINPATH);
        }
        #endregion
        #endregion
    }
}
