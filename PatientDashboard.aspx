<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientDashboard.aspx.cs" Inherits="SiddhaHospitalManagement.PatientDashboard_aspx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PatientDashboard</title>
</head>
<body>
    <form id="form1" runat="server">
       <asp:GridView ID="gvAppointments" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
    <Columns>
        <asp:BoundField DataField="AppointmentID" HeaderText="Appointment ID" />
        <asp:BoundField DataField="DoctorName" HeaderText="Doctor Name" />
        <asp:BoundField DataField="AppointmentDate" HeaderText="Date" />
        <asp:BoundField DataField="AppointmentTime" HeaderText="Time" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
    </Columns>
</asp:GridView>


          <asp:Label ID="lblDoctorName" runat="server" Text=""></asp:Label>
           <br /><br />
          <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    </form>
</body>
</html>
