<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAppointments.aspx.cs" Inherits="SiddhaHospitalManagement.MyAppointments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:GridView ID="gvMyAppointments" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="DoctorName" HeaderText="Doctor" />
        <asp:BoundField DataField="AppointmentDate" HeaderText="Date" />
        <asp:BoundField DataField="AppointmentTime" HeaderText="Time" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
    </Columns>
</asp:GridView>

        </div>
    </form>
</body>
</html>
