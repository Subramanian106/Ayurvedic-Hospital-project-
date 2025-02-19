<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SiddhaHospitalManagement.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login - Siddha Hospital</title>
    <style>
        .login-container {
            width: 350px;
            padding: 20px;
            background: green;
            border-radius: 8px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            margin: auto;
            margin-top: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="login-container">
            <h3 class="text-center">Login</h3>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            <div class="mb-3">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Password"></asp:TextBox>
            </div>
            <div class="d-grid">
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="btnLogin_Click" />
            </div>
            <p class="text-center mt-2"><a href="Register.aspx">Don't have an account? Register</a></p>
        </div>
    </div>
        </form>
</body>
</html>
