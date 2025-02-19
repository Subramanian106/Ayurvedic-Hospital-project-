<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SiddhaHospitalManagement.Register" %>

<!DOCTYPE html>
<html>
<head>
    <title>Register - Siddha Hospital</title>
    <style>
        body
        {
            background-color:aquamarine
        }
        .register-container {
            width: 400px;
            padding: 20px;
            background:#76b5c5;
            border-radius: 8px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            margin: auto;
            margin-top: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="register-container">
                <h3 class="text-center">Register</h3>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                <div class="mb-3">
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" Placeholder="Full Name"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Email"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Password"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select Role" Value="" />
                        <asp:ListItem Text="Doctor" Value="Doctor" />
                        <asp:ListItem Text="Receptionist" Value="Receptionist" />
                        <asp:ListItem Text="Pharmacist" Value="Pharmacist" />
                        <asp:ListItem Text="Nurse" Value="Nurse" />
                        <asp:ListItem Text="Patient" Value="Patient" />
                        <asp:ListItem Text="Admin" Value="Admin" />
                    </asp:DropDownList>
                </div>
                <div class="d-grid">
                    <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary" Text="Register" OnClick="btnRegister_Click" />
                </div>
                <p class="text-center mt-2"><a href="Login.aspx">Already have an account? Login</a></p>
            </div>
        </div>
    </form>
</body>
</html>
