<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppConfiguration.aspx.cs" Inherits="Bioplugin.Cloudscanr.Csharp.Web.Sample.AppConfiguration" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>CloudABIS Configuration</title>
    <link rel="Stylesheet" type="text/css" href="Script/Style.css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        function setConfiguration() {
            var engineName = document.getElementById("engineName");
            engineName = engineName.options[engineName.selectedIndex].value;
            var templateFormat = document.getElementById("templateFormat");
            templateFormat = templateFormat.options[templateFormat.selectedIndex].value;

            var deviceName = document.getElementById("deviceName");
            deviceName = deviceName.options[deviceName.selectedIndex].value;


            if (engineName != '') {
                //set credentials in cookey or any others client storage or get your storage
                setCookie("BioPluginDeviceName", deviceName, 7);
                setCookie("BioPluginEngineName", engineName, 7);
                setCookie("BioPluginTempalteFormat", templateFormat, 7);


                window.open("BioPluginHome.aspx", "_self");
            } else {
                failCall("Please put required values.");
            }
        }

        function setCookie(name, value, days) {
            var expires = "";
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toUTCString();
            }
            document.cookie = name + "=" + (value || "") + expires + "; path=/";
        }

        function failCall(status) {
            document.getElementById('lblMessage').innerHTML = status;
        }
    </script>

</head>
<body style="background-color: ButtonHighlight">
    <div class="formWrapper">
        <form id="form1" runat="server">
            <div class="iholder">
                <h1 class="headline">Active Device</h1>
                <label for="deviceName">Device Name</label>
                <select id="deviceName">
                    <option value="Secugen">Secugen</option>
                    <option value="TwoPrintFutronic">TwoPrintFutronic</option>
                    <option value="TenPrintFutronic">TenPrintFutronic</option>
                    <option value="DigitalPersona">DigitalPersona</option>
                </select>
                <label for="engineName">Engine Name</label>
                <select id="engineName">
                    <option value="FP2">FingerPrint</option>
                </select>
                <label for="templateFormat">Template Format</label>
                <select id="templateFormat">
                    <option value="M2ICS">M2ICS</option>
                    <option value="FP1">FP1</option>
                </select>
                <input type="button" value="Save" onclick="setConfiguration()" />
                <asp:Button ID="Button1" runat="server" Text="Back" OnClick="BtnBack_Click" />
                <label id="lblMessage"></label>
            </div>
        </form>
    </div>
</body>
</html>

