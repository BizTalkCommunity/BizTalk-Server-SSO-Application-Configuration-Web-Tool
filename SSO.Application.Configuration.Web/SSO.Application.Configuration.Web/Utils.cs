using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace BizTalk.Tools.SSOApplicationConfiguration
{
    public class Utils
    {
        // Import application from a file
        public static bool ImportAppFromXML(string path, string password, string appAdminAcct, string contactInfo, string appUserAcct)
        {
            XmlDocument configDoc = new XmlDocument();
            try
            {
                configDoc.LoadXml(Encryption.DecryptGeral(File.ReadAllText(@path), password));

                string appName = Path.GetFileNameWithoutExtension(@path);

                //grab fields
                XmlNodeList fields = configDoc.SelectNodes("//applicationData/add");
                ArrayList maskArray = new ArrayList();

                try
                {
                    HybridDictionary props = new HybridDictionary();

                    foreach (XmlNode field in fields)
                    {
                        props.Add(field.Attributes["key"].InnerText, field.Attributes["value"].InnerText);
                        maskArray.Add(0);
                    }

                    SSOPropBag propertiesBag = new SSOPropBag(props);

                    CreateAndEnableAppInSSO(appName, string.Empty, contactInfo, appUserAcct, appAdminAcct, propertiesBag, maskArray);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Application already exists with name " + appName + " "+ex);
                    return false;
                }

                return true;
            }
            catch (XmlException)
            {
                Console.WriteLine("Password Incorrect");
                return false;
            }
        }
        public static bool CreateAPP(string appname, string appAdminAcct, string contactInfo, string appUserAcct)
        {
            try
            {
                ArrayList maskArray = new ArrayList();

                try
                {
                    HybridDictionary props = new HybridDictionary();

                    SSOPropBag propertiesBag = new SSOPropBag(props);

                    CreateAndEnableAppInSSO(appname, string.Empty, contactInfo, appUserAcct, appAdminAcct, propertiesBag, maskArray);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Application already exists with name " + appname + " " + ex);
                    return false;
                }

                return true;
            }
            catch (XmlException)
            {
                Console.WriteLine("Can't create App.");
                return false;
            }
        }

        // Create and enable App in SSO
        public static void CreateAndEnableAppInSSO(string appName, string description, string ContactInfo,
           string AppUserAcct, string AppAdminAcct, SSOPropBag propertiesBag, ArrayList maskArray)
        {
            //create and enable application
            SSOConfigManager.CreateConfigStoreApplication(appName, description, ContactInfo,
            AppUserAcct, AppAdminAcct, propertiesBag, maskArray);
            //set default configuration field values
            SSOConfigManager.SetConfigProperties(appName, propertiesBag);
        }

        // List all keys from an App
        public static string LoadGrid(string appName)
        {
            try
            {
                string appUserAcct, appAdminAcct, description, contactInfo;
                HybridDictionary props = SSOConfigManager.GetConfigProperties(appName, out description, out contactInfo,
                 out appUserAcct, out appAdminAcct);
                string html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:arial'>";
                html = html + "<tr>";
                html = html + "<td>Name</td>";
                html = html + "<td>Value</td>";
                html = html + "</tr>";
                foreach (DictionaryEntry appProp in props)
                {
                    html = html + "<tr>";
                    html = html + "<td>" + appProp.Key.ToString() + "</td>";
                    html = html + "<td>" + appProp.Value.ToString() + "</td>";
                    html = html + "</tr>";

                }
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot list keys" + ex);
                return "";
            }
        }

        public static void LoadSpecificGrid(string appName, string keyName)
        {
            string appUserAcct, appAdminAcct, description, contactInfo;
            HybridDictionary props = SSOConfigManager.GetConfigProperties(appName, out description, out contactInfo,
             out appUserAcct, out appAdminAcct);
            Console.WriteLine("Key | Value");
            try { 
                foreach (DictionaryEntry appProp in props)
                {
                    if (appProp.Key.ToString() == keyName)
                    {
                        Console.WriteLine(appProp.Key.ToString() + " | " + appProp.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot list key" + ex);
            }
        }

        // Remove a key from an App
        public static bool RemoveKeyValueFromSSOApp(string KeyValueToBeRemoved, string parentNode)
        {
            string appUserAcct = string.Empty, appAdminAcct = string.Empty,
                    contactInfo = string.Empty, description = string.Empty;
            List<String> keysToRemove = new List<string>();
            ArrayList maskArray = new ArrayList();

            try
            {
                //Gets the configuration information from the configuration store about parentNode
                HybridDictionary props = SSOConfigManager.GetConfigProperties(parentNode, out description,
                        out contactInfo, out appUserAcct, out appAdminAcct);

                //search in 'props' if exists some key/prefix that contains 'KeyValueToBeRemoved'
                //if exists, store it in a list
                foreach (var item in props.Keys)
                {
                    if (item.ToString().Contains(KeyValueToBeRemoved))
                    {
                        keysToRemove.Add(item.ToString());
                        //in this foreach i cannot remove the key directly from 'props'
                    }
                    maskArray.Add(0);
                }

                //remove keys from 'props':
                foreach (string key in keysToRemove)
                {
                    props.Remove(key);
                    maskArray.Remove(0);
                }

                SSOConfigManager.DeleteApplication(parentNode);
                SSOPropBag propertiesBag = new SSOPropBag(props);
                CreateAndEnableAppInSSO(parentNode, string.Empty, contactInfo, appUserAcct, appAdminAcct, propertiesBag, maskArray);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot delete key" + ex);
                return false;
            }
        }
        public static bool UpdateSSOApp(string appname, string newAppName, string password, string appAdminAcct, string contactInfo, string appUserAcct)
        {
            string description;
            HybridDictionary props = SSOConfigManager.GetConfigProperties(appname, out description, out contactInfo, out appUserAcct, out appAdminAcct);
            ArrayList maskArray = new ArrayList();
            try
            {
               foreach(DictionaryEntry appProp in props)
                {
                    maskArray.Add(0);
                }
                SSOConfigManager.DeleteApplication(appname);
                SSOPropBag propertiesBag = new SSOPropBag(props);
                //create and enable application
                SSOConfigManager.CreateConfigStoreApplication(newAppName, "", contactInfo,
                    appUserAcct, appAdminAcct, propertiesBag, maskArray);
                //set default configuration field values
                SSOConfigManager.SetConfigProperties(newAppName, propertiesBag);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Erro" + ex);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro" + ex);
                return false;
            }

            return true;
        }
        private static int lastAppNumberAdded(string appName)
        {
            List<string> al = SSOConfigManager.GetApplication();

            int lastAppNumber = -1;

            foreach (string s in al)
            {
                if (s.Equals(appName)) lastAppNumber = 0;
                if (s.Contains(appName + "("))
                {

                    string regex = Regex.Match(s, @"\([0-9]+\)(?!.*(\([0-9]+\)))").Value;
                    if (regex == "") continue;


                    int splitNumber = Int32.Parse(regex.Split('(')[1].Split(')')[0]);
                    if (splitNumber > lastAppNumber) lastAppNumber = splitNumber;

                }
            }

            return lastAppNumber;
        }
        public static string copyAppName(string appName)
        {
            int splitNumber = lastAppNumberAdded(appName);

            if (splitNumber == -1) return appName;

            return appName + "(" + ++splitNumber + ")";

        }
        public static bool CopySSOApp(string appname, string oldName,string password, string appAdminAcct, string contactInfo, string appUserAcct)
        {
            string description;
            HybridDictionary props = SSOConfigManager.GetConfigProperties(oldName, out description, out contactInfo, out appUserAcct, out appAdminAcct);
            ArrayList maskArray = new ArrayList();
            try
            {
                foreach (DictionaryEntry appProp in props)
                {
                    maskArray.Add(0);
                }
                SSOPropBag propertiesBag = new SSOPropBag(props);
                //create and enable application
                SSOConfigManager.CreateConfigStoreApplication(appname, "", contactInfo,
                    appUserAcct, appAdminAcct, propertiesBag, maskArray);
                //set default configuration field values
                SSOConfigManager.SetConfigProperties(appname, propertiesBag);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Erro" + ex);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro" + ex);
                return false;
            }

            return true;
        }
        // Overwrite an App if already exists
        public static bool OverwriteSSOApplication(string appname, string password, string appAdminAcct, string contactInfo, string appUserAcct, string path)
        {
            XmlDocument configDoc = new XmlDocument();
            configDoc.LoadXml(Encryption.DecryptGeral(File.ReadAllText(@path), password));
            //write to SSOPropBag to figure out how many rows we have
            XmlNodeList fields = configDoc.SelectNodes("//applicationData/add");
            ArrayList maskArray = new ArrayList();

            try
            {
                HybridDictionary props = new HybridDictionary();
                foreach (XmlNode field in fields)
                {
                    props.Add(field.Attributes["key"].InnerText, field.Attributes["value"].InnerText);
                    maskArray.Add(0);
                }
                SSOConfigManager.DeleteApplication(appname);
                SSOPropBag propertiesBag = new SSOPropBag(props);
                //create and enable application
                SSOConfigManager.CreateConfigStoreApplication(appname, "", contactInfo,
                    appUserAcct, appAdminAcct, propertiesBag, maskArray);
                //set default configuration field values
                SSOConfigManager.SetConfigProperties(appname, propertiesBag);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Erro" + ex);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro" + ex);
                return false;
            }

            return true;
        }
        public static bool ExportEncryptedAppToXML(string tempFileName, string appName, string password)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(sw);
            string description, contactInfo, appUserAcct, appAdminAcct;
            HybridDictionary props = SSOConfigManager.GetConfigProperties(appName, out description, out contactInfo, out appUserAcct, out appAdminAcct);
            try
            {
                //start document
                writer.WriteComment("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                //elements
                writer.WriteStartElement("SSOApplicationExport");
                writer.WriteStartElement("applicationData");

                foreach (DictionaryEntry appProp in props)
                {
                        writer.WriteStartElement("add");
                        writer.WriteAttributeString("key", appProp.Key.ToString());
                        writer.WriteAttributeString("value", appProp.Value.ToString());
                        writer.WriteEndElement();
                }

                writer.WriteEndElement();
                //close root
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();

                string encrypted = Encryption.EncryptGeral(sw.ToString(), password);
                File.WriteAllText(tempFileName, encrypted);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot export application to XML  file", "Error");
                return false;
            }
        }
        // Delete an App
        public static bool DeleteSSOApp(string appname)
        {
            XmlDocument configDoc = new XmlDocument();
       
            //write to SSOPropBag to figure out how many rows we have
            XmlNodeList fields = configDoc.SelectNodes("//applicationData/add");
            ArrayList maskArray = new ArrayList();
            string appName2 = Path.GetFileNameWithoutExtension(appname);
            try
            {
                SSOConfigManager.DeleteApplication(appName2);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Erro" + ex);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro" + ex);
                return false;
            }

            return true;
        }

        // List Apps
        public static int ListApps(string appUserAcct,string appAdminAcct, string contactInfo)
        {
            try
            {
                int i = 0;
                Console.Write("Apps");
                foreach (var application in SSOConfigManager.GetApplications(contactInfo))
                {
                    i++;
                    Console.WriteLine(application);
                }
                return i;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot list apps" + ex);
                return 0;
            }
        }

        // Add key to an App and Update in SSO
        public static bool UpdateSSOApplication(string appname, string keyName, string keyValue)
        {
            List<String> keysToRemove = new List<string>();
            ArrayList maskArray = new ArrayList();
            string appUserAcct, appAdminAcct, description, contactInfo;
            try
            {
                //Gets the configuration information from the configuration store about parentNode
                HybridDictionary props = SSOConfigManager.GetConfigProperties(appname, out description, out contactInfo, out appUserAcct, out appAdminAcct);

                foreach (var item in props.Keys)
                {
                    maskArray.Add(0);
                }
                object objPropValue = keyValue.ToString().Replace("\t", "").Replace("\r", "");
                object objPropKey = keyName.ToString().Replace("\t", "").Replace("\r", "");

                props.Add(objPropKey, objPropValue);
                maskArray.Add(0);
                SSOConfigManager.DeleteApplication(appname);
                SSOPropBag propertiesBag = new SSOPropBag(props);
                CreateAndEnableAppInSSO(appname, string.Empty, contactInfo, appUserAcct, appAdminAcct, propertiesBag, maskArray);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot delete key" + ex);
                return false;
            }
           
        }

        // Rename a key from App
        /*
        public static bool RenameKeyValueFromSSOApp(string node, string oldNode, string parentSelectedNode)
        {
            ArrayList maskArray = new ArrayList();
            string appUserAcct = string.Empty, appAdminAcct = string.Empty,
                    contactInfo = string.Empty, description = string.Empty;

            try
            {
                HybridDictionary props = SSOConfigManager.GetConfigProperties(parentSelectedNode, out description,
                        out contactInfo, out appUserAcct, out appAdminAcct);
                HybridDictionary propsTemp = new HybridDictionary();

                //save nodes to rename
                foreach (DictionaryEntry item in props)
                {
                    if (item.Key.ToString().Contains(oldNode))
                    {
                        propsTemp.Add(item.Key.ToString().Replace(oldNode, node), item.Value.ToString());
                    }
                    maskArray.Add(0);
                }

                Utils.RemoveKeyValueFromSSOApp(oldNode, parentSelectedNode);

                props = SSOConfigManager.GetConfigProperties(parentSelectedNode, out description,
                        out contactInfo, out appUserAcct, out appAdminAcct);

                foreach (DictionaryEntry item in propsTemp)
                {
                    props.Add(item.Key.ToString(), item.Value.ToString());
                }

                SSOConfigManager.DeleteApplication(parentSelectedNode);
                SSOPropBag propertiesBag = new SSOPropBag(props);
                Utils.CreateAndEnableAppInSSO(parentSelectedNode, string.Empty, contactInfo,
                    appUserAcct, appAdminAcct, propertiesBag, maskArray);

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot create node");
                return false;
            }

        }
        */

        /// <summary>
        /// Rename nodes/keys (level 2) from treeview
        /// </summary>
        /// <param name="node">Node already renamed</param>
        /// <param name="oldNode">Old node name</param>
        /// <param name="parentSelectedNode">Parent of node renamed</param>
        /// 
        // Decrypt a file with the password
        public static class Encryption
        {
            public static string DecryptGeral(string toDecrypt, string key)
            {
                byte[] inputBuffer = Convert.FromBase64String(toDecrypt);
                byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
                {
                    Key = buffer,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                byte[] bytes = provider2.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.UTF8.GetString(bytes);
            }
            public static string EncryptGeral(string toEncrypt, string key)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
                byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(key));
                TripleDESCryptoServiceProvider provider2 = new TripleDESCryptoServiceProvider
                {
                    Key = buffer,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                byte[] inArray = provider2.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
                return Convert.ToBase64String(inArray, 0, inArray.Length);
            }

        }
        private static bool ok = false;
        private static string password = "";
        public static void getPassword(out bool ok_aux, out string password_aux)
        {
            ok_aux = ok;
            ok = false;
            password_aux = password;
        }
    }
}