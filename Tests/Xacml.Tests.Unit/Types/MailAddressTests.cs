using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xacml.Types;
using System.Net.Mail;

namespace Xacml.Tests.Unit.Types
{
    /// <summary>
    /// <see cref="http://en.wikipedia.org/wiki/Email_address#Invalid_email_addresses"/>
    /// </summary>
    [TestClass]    
    public class MailAddressTests
    {
        [TestMethod]
        public void Test_MailAddress_Parse_Simple()
        {
            var rfc822Name = new MailAddress("niceandsimple@example.com");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Period_In_Local_Name()
        {
            var rfc822Name = new MailAddress("very.common@example.com");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Period_In_Both_Parts_Suceeds()
        {
            var rfc822Name = new MailAddress("a.little.lengthy.but.fine@dept.example.com");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Disposable_Style_Email_With_Symbol()
        {
            var rfc822Name = new MailAddress("disposable.style.email.with+symbol@example.com");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Dash()
        {
            var rfc822Name = new MailAddress(@"other.email-with-dash@example.com");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_IPV4_Domain()
        {
            var rfc822Name = new MailAddress(@"jsmith@[192.168.2.1]");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_IPV6_Domain()
        {
            var rfc822Name = new MailAddress(@"user@[IPv6:2001:db8:1ff::a0b:dbd0]");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Quoted_Local_Part()
        {
            var rfc822Name = new MailAddress(@"""much.more unusual""@example.com");
        }
        
        [TestMethod]
        public void Test_MailAddress_Parse_With_Inline_Symbols()
        {
            var rfc822Name = new MailAddress(@"""very.(),:;<>[]\"".VERY.\""very@\\ \""very\"".unusual""@strange.example.com");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Top_Level_Domain_Name()
        {
            var rfc822Name = new MailAddress(@"postbox@com");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Local_Domain_Name_No_TLD()
        {
            var rfc822Name = new MailAddress(@"admin@mailserver1");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Symbol_Local_Part()
        {
            var rfc822Name = new MailAddress(@"!#$%&'*+-/=?^_`{}|~@example.org");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Quoted_Symbol_Local_Part()
        {
            var rfc822Name = new MailAddress(@"""()<>[]:,;@\\\""!#$%&'*+-/=?^_`{}| ~.a""@example.org");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Quoted_Space_Local_Part()
        {
            var rfc822Name = new MailAddress(@""" ""@example.org");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Unicode_Local_Part()
        {
            var rfc822Name = new MailAddress(@"üñîçøðé@example.com");
        }

        [TestMethod]
        public void Test_MailAddress_Parse_With_Unicode_Local_And_Domain_Parts()
        {
            var rfc822Name = new MailAddress(@"üñîçøðé@üñîçøðé.com");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_MailAddress_Parse_An_At_Character_Must_Separate_The_Local_And_Domain_Parts()
        {
            var rfc822Name = new MailAddress(@"Abc.example.com");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_MailAddress_Parse_Only_One_At_Is_Allowed_Outside_Quotation_Marks()
        {
            var rfc822Name = new MailAddress(@"A@b@c@example.com");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_MailAddress_Parse_None_Of_The_Special_Characters_In_This_Local_Part_Is_Allowed_Outside_Quotation_Marks()
        {
            var rfc822Name = new MailAddress(@"a""b(c)d,e:f;g<h>i[j\k]l@example.com");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_MailAddress_Parse_Quoted_Strings_Must_Be_Dot_Separated_Or_The_Only_Element_Making_Up_The_Local_Part()
        {
            var rfc822Name = new MailAddress(@"just""not""right@example.com");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_MailAddress_Parse_Spaces_Quotes_Backslashes_May_Only_Exist_When_Within_Quoted_Strings_And_Preceeded_By_A_Backslash()
        {
            var rfc822Name = new MailAddress(@"this is""not\allowed@example.com");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_MailAddress_Parse_Even_If_Escaped_Spaces_Quotes_And_Backslashes_Must_Still_Be_Contained_By_Quotes()
        {
            var rfc822Name = new MailAddress(@"this\ still\""not\\allowed@example.com");
        }
    }
}
