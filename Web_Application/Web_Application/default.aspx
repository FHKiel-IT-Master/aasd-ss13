<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web_Application._default" MasterPageFile ="~/WebbApp.Master" %>


<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
<style type="text/css">
     .inputTxt {
         margin-top: 216px;
         height:30px;
         width: 550px;
     }
    .btn_search {
        margin-left:235px;
        margin-right:auto;
        margin-top:5px;
        height:18px;
        width:80px;
    }
    .btn_tile {
        background-color: white;
        opacity: 0.5;
        border: 1px solid #fff;
        margin-bottom:5px;
        margin-left:5px;
        height:100px;
        width:100px;
    }
        .btn_tile:hover {
            background-color: #72c2a2;
            opacity: 1;
        }
    .btn_tile_clicked {
        background-color: white;
        opacity: 1;
        border: 1px solid #fff;
        margin-bottom:5px;
        margin-left:5px;
        height:100px;
        width:100px;
    }

</style>
    <ul>
        <li id="page_home">
            <form id="form1" runat="server" style="background:none">
                <div class="container_16">
                    <input id="Hidden1" type="hidden" runat="server" />
                        <div class="grid_6">
                            <div class="slogan">
                                <p>Find<br/>what you<br/>need</p>
                            </div>
                        </div>
                    <div class="grid_5 pull_2">      
                        <asp:TextBox ID="TxtB_Input" runat="server" CssClass="inputTxt"></asp:TextBox>
                        <asp:Button ID="Btn_Search" runat="server" Text="Search" OnClick="Btn_Search_Click" CssClass="btn_search" />
                    </div>
                        <div class="grid_4 push_3">
                            <div class="rel">
                                <div class="scroll" style="height:445px; width:auto; margin-top:20px; margin-bottom:20px">
                                    <div id="contexts" runat="server"></div>
                                </div>
                            </div>  
                        </div>
                    <div class="grid_1 push_3">
                        <div class="scrollBtns" style="padding-top: 59px">
                            <a href="#" class="scrollUp"><span></span></a>
                            <a href="#" class="scrollDown"><span></span></a>
                        </div>
                    </div>
                </div>
            </form>
        </li>
    </ul >

<script type="text/javascript">

    var btn_tile = document.getElementsByClassName('btn_tile');

    for (var i = 0; i < btn_tile.length; i++) {
        btn_tile[i].addEventListener('click', function () {
            if (this.getAttribute('class') == 'btn_tile') {
                this.setAttribute('class', 'btn_tile_clicked');
            } else {
                this.setAttribute('class', 'btn_tile');
            }
        });
    }

    function context_clicked(click_id) {
        var hidden = document.getElementById("<%:Hidden1.ClientID%>").value;
                                if (hidden.search(click_id) == -1) {
                                    document.getElementById("<%:Hidden1.ClientID%>").value += "%" + click_id;
                                } else {
                                    hidden = hidden.replace("%" + click_id, "");
                                    document.getElementById("<%:Hidden1.ClientID%>").value = hidden;
                                }
                            }

</script>
</asp:Content>
