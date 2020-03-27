<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseRegistration.aspx.cs" Inherits="CourseRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
    <link rel="stylesheet" type="text/css" href="../App_Themes/SiteStyles.css" />

</head>
<body>
    <div>
        <h1>Algonquin College Course Registration</h1>
    </div>
    <asp:Panel runat="server" ID="pnlRegistration">
        <form id="form1" runat="server">

        <div>
            <table>
                <tr class="col">
                    <td>Student Name:</td>
                    <td><asp:TextBox CssClass="input" ID="Student_Name" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:RadioButtonList ID="Student_Type" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Full Time">Full Time</asp:ListItem>
                            <asp:ListItem Value="Part Time">Part Time</asp:ListItem>
                            <asp:ListItem Value="Co-op">Co-op</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </div>

        <div>
            The following courses are currently available for registration:
        </div>

        <div>        
            <asp:Label ID="LabelError" CssClass="error" runat="server"></asp:Label>
        </div>

        <div>
            <asp:CheckBoxList ID="checklist" runat="server" />
        </div>

        <div>
            <asp:Button ID="Button1" CssClass="button" runat="server" OnClick="Submit_Page" Text="Submit" />
        </div>
        </form>
    </asp:Panel>


    <asp:Panel runat="server" ID="pnlResult">
        <asp:Label ID="LabelConfirmation" runat="server"></asp:Label>

        

    </asp:Panel>
</body>
</html>
