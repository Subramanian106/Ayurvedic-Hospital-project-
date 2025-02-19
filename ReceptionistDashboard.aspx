<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReceptionistDashboard.aspx.cs" Inherits="SiddhaHospitalManagement.ReceptionistDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReceptionistDashboard</title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>Welcome,Receptionist! </h2>
        <asp:Label ID="lblDoctorName" runat="server" Text=""></asp:Label>
       <br /><br />
       <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        </form>
</body>
</html>
