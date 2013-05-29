<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="s_results.aspx.cs" Inherits="Web_Application.s_results" MasterPageFile ="~/WebbApp.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <ul>
    <li id="page_results">
                    <div class="container_16 pad1">
                        <div class="wrapper">
                            <div class="prefix_6 grid_10">
                               <h4>Results</h4>
                                <asp:Literal ID="SearchTopic" runat="server"></asp:Literal>
                               <div class="rel">
                                        <div class="scroll" style="height:330px">
                                            <asp:Literal ID="ResultsLiteral" runat="server"></asp:Literal>    
                                        </div>
                                        <div class="scrollBtns">
                                            <a href="#" class="scrollUp"><span></span></a>
                                            <a href="#" class="scrollDown"><span></span></a>
                                        </div>
                                  </div>  
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
</asp:Content>
