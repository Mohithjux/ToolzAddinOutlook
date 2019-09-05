using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Outlook;
using System.IO;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System.Text.RegularExpressions;

namespace ToolzAddinOutlook
{
    public partial class ToolzRibbon { 

        private void ToolzRibbon_Load(object sender, RibbonUIEventArgs e)
    {

    }
    private void ZipPass_Click(object sender, RibbonControlEventArgs e)
    {
        ProcessZip(true);
    }
    private void ZipNoPass_Click(object sender, RibbonControlEventArgs e)
    {
        ProcessZip(false);
    }

    // Compresses the files in the nominated folder, and creates a zip file 
    // on disk named as outPathname.
    public void CreateZipFile(string outPathname, string password, string folderName)
    {

        using (FileStream fsOut = File.Create(outPathname))
        using (var zipStream = new ZipOutputStream(fsOut))
        {

            //0-9, 9 being the highest level of compression
            zipStream.SetLevel(3);

            // optional. Null is the same as not setting. Required if using AES.
            zipStream.Password = password;

            // This setting will strip the leading part of the folder path in the entries, 
            // to make the entries relative to the starting folder.
            // To include the full path for each entry up to the drive root, assign to 0.
            int folderOffset = folderName.Length + (folderName.EndsWith("\\") ? 0 : 1);

            CompressFolder(folderName, zipStream, folderOffset);

        }

    }

    // Recursively compresses a folder structure
    private void CompressFolder(string path, ZipOutputStream zipStream, int folderOffset)
    {

        var files = Directory.GetFiles(path);

        foreach (var filename in files)
        {

            var fi = new FileInfo(filename);

            // Make the name in zip based on the folder
            var entryName = filename.Substring(folderOffset);

            // Remove drive from name and fixe slash direction
            entryName = ZipEntry.CleanName(entryName);

            var newEntry = new ZipEntry(entryName);

            // Note the zip format stores 2 second granularity
            newEntry.DateTime = fi.LastWriteTime;

            // Specifying the AESKeySize triggers AES encryption. 
            // Allowable values are 0 (off), 128 or 256.
            // A password on the ZipOutputStream is required if using AES.
            //   newEntry.AESKeySize = 256;

            // To permit the zip to be unpacked by built-in extractor in WinXP and Server2003,
            // WinZip 8, Java, and other older code, you need to do one of the following: 
            // Specify UseZip64.Off, or set the Size.
            // If the file may be bigger than 4GB, or you do not need WinXP built-in compatibility, 
            // you do not need either, but the zip will be in Zip64 format which
            // not all utilities can understand.
            //   zipStream.UseZip64 = UseZip64.Off;
            newEntry.Size = fi.Length;

            zipStream.PutNextEntry(newEntry);

            // Zip the file in buffered chunks
            // the "using" will close the stream even if an exception occurs
            var buffer = new byte[4096];
            using (FileStream fsInput = File.OpenRead(filename))
            {
                StreamUtils.Copy(fsInput, zipStream, buffer);
            }
            zipStream.CloseEntry();
        }

        // Recursively call CompressFolder on all folders in path
        var folders = Directory.GetDirectories(path);
        foreach (var folder in folders)
        {
            CompressFolder(folder, zipStream, folderOffset);
        }
    }

    public static string GeneratePassword(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, int lengthOfPassword)
    {
        const int MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS = 2;
        const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
        const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMERIC_CHARACTERS = "0123456789";
        const string SPECIAL_CHARACTERS = @"!#$%&*@\";
        const string SPACE_CHARACTER = " ";
        const int PASSWORD_LENGTH_MIN = 6;
        const int PASSWORD_LENGTH_MAX = 128;

        if (lengthOfPassword < PASSWORD_LENGTH_MIN || lengthOfPassword > PASSWORD_LENGTH_MAX)
        {
            return "Password length must be between 6 and 128.";
        }

        string characterSet = "";

        if (includeLowercase)
        {
            characterSet += LOWERCASE_CHARACTERS;
        }

        if (includeUppercase)
        {
            characterSet += UPPERCASE_CHARACTERS;
        }

        if (includeNumeric)
        {
            characterSet += NUMERIC_CHARACTERS;
        }

        if (includeSpecial)
        {
            characterSet += SPECIAL_CHARACTERS;
        }

        if (includeSpaces)
        {
            characterSet += SPACE_CHARACTER;
        }

        char[] password = new char[lengthOfPassword];
        int characterSetLength = characterSet.Length;

        System.Random random = new System.Random();
        for (int characterPosition = 0; characterPosition < lengthOfPassword; characterPosition++)
        {
            password[characterPosition] = characterSet[random.Next(characterSetLength - 1)];

            bool moreThanTwoIdenticalInARow =
                characterPosition > MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS
                && password[characterPosition] == password[characterPosition - 1]
                && password[characterPosition - 1] == password[characterPosition - 2];

            if (moreThanTwoIdenticalInARow)
            {
                characterPosition--;
            }
        }

        return string.Join(null, password);
    }

    /// <summary>
    /// Checks if the password created is valid
    /// </summary>
    /// <param name="includeLowercase">Bool to say if lowercase are required</param>
    /// <param name="includeUppercase">Bool to say if uppercase are required</param>
    /// <param name="includeNumeric">Bool to say if numerics are required</param>
    /// <param name="includeSpecial">Bool to say if special characters are required</param>
    /// <param name="includeSpaces">Bool to say if spaces are required</param>
    /// <param name="password">Generated password</param>
    /// <returns>True or False to say if the password is valid or not</returns>
    public static bool PasswordIsValid(bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial, bool includeSpaces, string password)
    {
        const string REGEX_LOWERCASE = @"[a-z]";
        const string REGEX_UPPERCASE = @"[A-Z]";
        const string REGEX_NUMERIC = @"[\d]";
        const string REGEX_SPECIAL = @"([!#$%&*@\\])+";
        const string REGEX_SPACE = @"([ ])+";

        bool lowerCaseIsValid = !includeLowercase || (includeLowercase && Regex.IsMatch(password, REGEX_LOWERCASE));
        bool upperCaseIsValid = !includeUppercase || (includeUppercase && Regex.IsMatch(password, REGEX_UPPERCASE));
        bool numericIsValid = !includeNumeric || (includeNumeric && Regex.IsMatch(password, REGEX_NUMERIC));
        bool symbolsAreValid = !includeSpecial || (includeSpecial && Regex.IsMatch(password, REGEX_SPECIAL));
        bool spacesAreValid = !includeSpaces || (includeSpaces && Regex.IsMatch(password, REGEX_SPACE));

        return lowerCaseIsValid && upperCaseIsValid && numericIsValid && symbolsAreValid && spacesAreValid;
    }

    private void ProcessZip(bool WithPassword)
    {

        Outlook.Application application = Globals.ThisAddIn.Application;
        Outlook.Inspector inspector = application.ActiveInspector();
        Outlook.MailItem myMailItem = (Outlook.MailItem)inspector.CurrentItem;
        Word.Document wordDocument = myMailItem.GetInspector.WordEditor as Word.Document;
        string strTemp = Path.GetRandomFileName();
        DirectoryInfo di = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), strTemp));
        int AttchCount = myMailItem.Attachments.Count;
        if ((myMailItem.BodyFormat == Outlook.OlBodyFormat.olFormatHTML || myMailItem.BodyFormat == Outlook.OlBodyFormat.olFormatPlain)
            && AttchCount != 0)
        {
            string saveTemp, zipFilename, zipFolderPath, Filename_timeStamp;
            Filename_timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssff") + ".zip";
            zipFolderPath = Path.Combine(Path.GetTempPath(), strTemp);
            zipFilename = Path.Combine(Path.GetTempPath(), Filename_timeStamp);
            for (int i = AttchCount; myMailItem.Attachments.Count > 0; i--)
            {
                try
                {
                    if (myMailItem.Attachments[i].Type == Outlook.OlAttachmentType.olByValue &&
                        !myMailItem.HTMLBody.Contains("cid:" + myMailItem.Attachments[i].FileName))
                    {
                        saveTemp = di.FullName + "\\" + myMailItem.Attachments[i].FileName;
                        try
                        {
                            myMailItem.Attachments[i].SaveAsFile(saveTemp);
                            myMailItem.Attachments.Remove(i);
                        }
                        catch (System.Runtime.InteropServices.COMException)
                        {
                            myMailItem.Attachments.Remove(i);
                            break;
                        }
                    }
                    else
                    {
                        myMailItem.Attachments.Remove(i);
                        break;
                    }
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    myMailItem.Attachments.Remove(i);
                    break;
                }


            }
            if (WithPassword)
            {
                bool includeLowercase = true;
                bool includeUppercase = true;
                bool includeNumeric = true;
                bool includeSpecial = true;
                bool includeSpaces = false;
                int lengthOfPassword = 6;
                string password;
                password = GeneratePassword(includeLowercase, includeUppercase, includeNumeric, includeSpecial, includeSpaces, lengthOfPassword);
                CreateZipFile(zipFilename, password, zipFolderPath);
                myMailItem.Attachments.Add(zipFilename, Outlook.OlAttachmentType.olByValue);

                if (File.Exists(zipFilename))
                {
                    File.Delete(zipFilename);
                }

                Word.Range wordRange = wordDocument.Range(0, 0);
                wordRange.Text =
 @"***************************************************************************
 添付 zip ファイルの復号パスワードは別メールにてご連絡致します
 Password for this mail attachment will be sent in a separate mail
***************************************************************************
";
                    myMailItem.Display();


                Outlook.MailItem NewMailItem = (Outlook.MailItem)inspector.Application.CreateItem(Outlook.OlItemType.olMailItem);
                Word.Document wordDocumentNewMail = NewMailItem.GetInspector.WordEditor as Word.Document;
                NewMailItem.Body = password;
                NewMailItem.Display();

                foreach (dynamic strAddress in myMailItem.Recipients)
                {
                    Outlook.Recipient strNewItemAddress;
                    string strMailAddress;

                    dynamic objAddressEntry = strAddress.AddressEntry.GetExchangeDistributionList();
                    if (objAddressEntry is null)
                    {
                        objAddressEntry = strAddress.AddressEntry.GetExchangeUser();

                        if (objAddressEntry is null)
                        {
                            strMailAddress = strAddress.AddressEntry.Address;
                        }
                        else
                        {
                            strMailAddress = objAddressEntry.PrimarySmtpAddress;
                        }
                    }
                    else
                    {
                        strMailAddress = objAddressEntry.PrimarySmtpAddress;
                    }

                    strNewItemAddress = NewMailItem.Recipients.Add(strMailAddress);
                    strNewItemAddress.Type = strAddress.Type;
                    strNewItemAddress.Resolve();
                }

                NewMailItem.Subject = "[パスワード通知/Password Notification]  " + myMailItem.Subject;
                Word.Range wordRangeNewMail = wordDocumentNewMail.Range(0, 0);
                wordRangeNewMail.Text = 
@"************************************************************************
添付 zip ファイルの復号パスワードをお知らせ致します。
Attachment File Password Notification                
************************************************************************
先にお送りしたメールの添付ファイルのパスワードは以下のとおりです。
Password for the mail sent earlier with an attachment is as below

[件名/Mail Subject]
" + myMailItem.Subject + @"

[パスワード/Password]
" + password + @"

お手数をおかけしますが、ご確認のほどよろしくお願い致します。
Please check the attachment with the password shared with this mail";

            }
            else
            {
                CreateZipFile(zipFilename, null, zipFolderPath);
                myMailItem.Attachments.Add(zipFilename, Outlook.OlAttachmentType.olByValue);

                if (File.Exists(zipFilename))
                {
                    File.Delete(zipFilename);
                }
            }

            di.Delete(true);
        }
    }

    }
}
