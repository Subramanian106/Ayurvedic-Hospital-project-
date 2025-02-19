<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SiddhaHospitalManagement.Dashboard" %>

<!DOCTYPE html>
<html>
<head>
    <title>Dashboard - Siddha Hospital</title>
    <style>
        .dashboard-container {
            margin: auto;
            margin-top: 50px;
            text-align: center;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="dashboard-container">
            <h2>Welcome, <asp:Label ID="lblUserName" runat="server" /></h2>
            <h5>Your Role: <asp:Label ID="lblUserRole" runat="server" /></h5>
            <a href="Logout.aspx" class="btn btn-danger">Logout</a>
        </div>
    </div>
</body>
</html>
