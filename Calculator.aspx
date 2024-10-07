<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="ST10097490_POE.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Calculator</h1>
            <asp:Label ID="Label1" runat="server" Text="Credit"></asp:Label>
            <asp:TextBox ID="txtNumber1" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="ClassesPerWeek"></asp:Label>
            <asp:TextBox ID="txtNumber2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Weeks"></asp:Label>
            <asp:TextBox ID="txtNumber3" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Calculate" runat="server" Text="Calculate" Font-Bold="True" Font-Size="Larger" Width="100px" OnClick="btnCalculate_Click" />
            </p>
        <hr />
        <asp:Label ID="StudyHours" runat="server" Font-Bold="True" Font-Size="Larger" ></asp:Label>
    </form>

</body>

</html>
