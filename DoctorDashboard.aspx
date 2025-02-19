<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorDashboard.aspx.cs" Inherits="SiddhaHospitalManagement.DoctorDashboard" %>
<!DOCTYPE html>
<html>
<head>
    <title>Doctor Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
    <h2>Welcome, Doctor!</h2>
    <asp:Label ID="lblDoctorName" runat="server" Text=""></asp:Label>
    <br /><br />
        <asp:GridView ID="gvAppointments" runat="server" AutoGenerateColumns="False" OnRowCommand="gvAppointments_RowCommand">
    <Columns>
        <asp:BoundField DataField="AppointmentID" HeaderText="ID" />
        <asp:BoundField DataField="PatientName" HeaderText="Patient" />
        <asp:BoundField DataField="AppointmentDate" HeaderText="Date" />
        <asp:BoundField DataField="AppointmentTime" HeaderText="Time" />
        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:Button ID="btnApprove" runat="server" CommandName="Approve" CommandArgument='<%# Eval("AppointmentID") %>' Text="Approve" />
                <asp:Button ID="btnReject" runat="server" CommandName="Reject" CommandArgument='<%# Eval("AppointmentID") %>' Text="Reject" />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

    </form>

</body>
</html>

