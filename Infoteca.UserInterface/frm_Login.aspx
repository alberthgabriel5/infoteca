<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_Login.aspx.cs" Inherits="Infoteca.UserInterface.frm_Login" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Infoteca Policial</title>
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
    <script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>
    <link rel="stylesheet" href='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css' media="screen" />
    <style>
        body {
          background-color:#fff;
          -webkit-font-smoothing: antialiased;
          font: normal 14px Roboto,arial,sans-serif;
        }

        .container {
            padding: 25px;
            position: fixed;
        }

        .form-login {
            background-color: #EDEDED;
            padding-top: 10px;
            padding-bottom: 20px;
            padding-left: 20px;
            padding-right: 20px;
            border-radius: 15px;
            border-color:#d2d2d2;
            border-width: 5px;
            box-shadow:0 1px 0 #cfcfcf;
        }

        h4 { 
         border:0 solid #fff; 
         border-bottom-width:1px;
         padding-bottom:10px;
         text-align: center;
        }

        .form-control {
            border-radius: 10px;
        }

        .wrapper {
            text-align: center;
        }
    </style>    
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <div class="container">                
                <div class="row">
                    <div class="col-sm-2 text-center" style="margin-top:15px!important">
                    </div>
                    <div class="col-sm-1 text-center" style="margin-top:15px!important">
                        <asp:Image id="logo_infoteca" runat="server" ImageUrl="~/images/logo.png" Height="180"/>
                    </div>
                    <div class="col-sm-7 text-center">
                        <asp:Image ID="logo" runat="server" ImageUrl="~/images/poder-judicial-logo.png" Height="200"/>
                    </div>     
                    <div class="col-sm-2 text-center">
                    </div>  
                </div>    
                <div class="row">
                    <br />
                    <br />
                </div>
                <div class="row">
                    <div class="col-sm-5">
                    </div>                
                    <div class="col-sm-7">
                        <div style="max-width: 400px;">
                            <h2 class="form-signin-heading">
                                Login</h2>
                            <label for="UserName">
                                Username</label>
                            <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Enter Username"
                                required />
                            <br />
                            <label for="Password">
                                Password</label>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"
                                placeholder="Enter Password" required />
                            <br/>
                            <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="SignIn" Class="btn btn-primary" />
                            <br />
                            <br />
                            <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
                                <strong>Error!</strong>
                                <asp:Label ID="lblMessage" runat="server" />
                            </div>                            
                        </div>                      
                    </div> 
                </div>
            </div>
        </div>
    </form>
</body>
</html>
