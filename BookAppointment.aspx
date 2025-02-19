<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="SiddhaHospitalManagement.BookAppointment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddlDoctors" runat="server"></asp:DropDownList>
            <asp:TextBox ID="txtAppointmentDate" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            <asp:Button ID="btnBookAppointment" runat="server" Text="Book Appointment" OnClick="btnBookAppointment_Click" />
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <asp:Calendar ID="calAppointmentDate" runat="server"></asp:Calendar>
            <asp:TextBox ID="txtAppointmentTime" runat="server" placeholder="HH:MM AM/PM"></asp:TextBox>

        </div>
    </form>
</body>
</html>

