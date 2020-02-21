using OVF.Administrator.Logic.Login.Item;
using System;

namespace OVF.Administrator.Logic.Login
{
    public class Login
    {
        #region "members"
        private AdministratorLoginItem _adminItem;
        #endregion

        #region "constructor"
        public Login()
        {
            _adminItem = new AdministratorLoginItem();
        }
        #endregion

        #region "methods"
        #region "public"
        public bool CheckLogin(string password1, string password2 = "optional")
        {
            if (!OV.Framework.Helper.XML.XMLHelper.CheckIfXmlExists(Constants.Constants.ADMINPATH))
            {
                if (!ComparePasswords(password1, password2))
                {
                    return false;
                }
                else
                {
                    try
                    {
                        _adminItem.Password = password1;
                        OV.Framework.Helper.XML.XMLHelper.ConvertObjectToXml(Constants.Constants.ADMINPATH, _adminItem);
                        return true;
                    }
                    catch (System.Exception)
                    {
                        throw;                        
                    }                    
                }
            }
            else
            {
                _adminItem = (AdministratorLoginItem)Convert.ChangeType(OV.Framework.Helper.XML.XMLHelper.ConvertXmlToObjekt(Constants.Constants.ADMINPATH,
                                                                                                                             _adminItem.GetType()), typeof(AdministratorLoginItem));
                if (_adminItem.Password != password1)
                {
                    return false;
                }
                return true;
            }            
        }
        #endregion

        #region "private"
        private void CreateAdministratorConfigXml(string path)
        {
            OV.Framework.Helper.XML.XMLHelper.ConvertObjectToXml(Constants.Constants.ADMINPATH, _adminItem.GetType());
        }

        private bool ComparePasswords(string password1, string password2)
        {
            if (password1 != password2)
            {
                return false;
            }

            return true;
        }
        #endregion
        #endregion
    }
}
