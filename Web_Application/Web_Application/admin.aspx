<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Web_Application.admin" MasterPageFile ="~/WebbApp.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <ul>
    <li id="page_admin">
                    <div class="container_16 pad1">
                        <div class="grid_6">
                        <asp:ListView ID="ListView1" runat="server"></asp:ListView>
                            </div>
                    </div>
                </li>
            </ul>
</asp:Content>
