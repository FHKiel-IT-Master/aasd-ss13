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

     .btn_tile.sub {
        background-color: white;
        opacity: 0.5;
        border: 1px solid #fff;
        margin-bottom:5px;
        margin-left:5px;
        height:50px;
        width:50px;
    }
        .btn_tile.sub:hover {
            background-color: #72c2a2;
            opacity: 1;
        }
    .btn_tile.sub_clicked {
        background-color: white;
        opacity: 1;
        border: 1px solid #fff;
        margin-bottom:5px;
        margin-left:5px;
        height:50px;
        width:50px;
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
                    <div class="grid_2 pull_2">      
                        <asp:TextBox ID="TxtB_Input" runat="server" CssClass="inputTxt"></asp:TextBox>
                        <asp:Button ID="Btn_Search" runat="server" Text="Search" OnClick="Btn_Search_Click" CssClass="btn_search" />
                    </div>
                     <div class="grid_3 pull_3">
                         <div id="subcontexts" runat="server" style="height:130px; width:430px; margin-top:50px; margin-bottom:20px"></div>   
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

            var value = this.getAttribute('value');
            var name = "sub_" + value;

            if (this.getAttribute('class') == 'btn_tile') {
                this.setAttribute('class', 'btn_tile_clicked');
                var sub = document.getElementsByName(name);
                for (var i = 0; i < sub.length; i++) {
                    sub[i].setAttribute('style', 'display:inline');
                }
            }
            else if (this.getAttribute('class') == 'btn_tile sub') {
                this.setAttribute('class', 'btn_tile sub_clicked');
            }
            else if (this.getAttribute('class') == 'btn_tile_clicked') {
                this.setAttribute('class', 'btn_tile');
                var sub = document.getElementsByName(name);
                for (var i = 0; i < sub.length; i++) {
                    sub[i].setAttribute('style', 'display:none');
                }
            }
            else if (this.getAttribute('class') == 'btn_tile sub_clicked') {
                this.setAttribute('class', 'btn_tile sub');
            }
        });
    }

    function context_clicked(click_id) {
        var hidden = document.getElementById("<%:Hidden1.ClientID%>").value;
        if (hidden.search(click_id) == -1) {
            document.getElementById("<%:Hidden1.ClientID%>").value += "%" + click_id;
        } else {
            //if the context is deselected, all sub-contexts should also be removed
            var sub = document.getElementsByName("sub_" + click_id);
            for (var i = 0; i < sub.length; i++) {
                hidden = hidden.replace("$" + sub[i].value, "");
            }
            hidden = hidden.replace("%" + click_id, "");
            document.getElementById("<%:Hidden1.ClientID%>").value = hidden;
        }
    }

    function subcontext_clicked(click_id,click_value) {
        var hidden = document.getElementById("<%:Hidden1.ClientID%>").value;
        if (hidden.search(click_value) == -1) {
            //look for the name of the supercontext, so it can add the subcontext besides it
            var position = hidden.search(click_id.substr(4));
            hidden = [hidden.slice(0, (position + click_id.substr(4).length)), "$" + click_value, hidden.slice((position + click_id.substr(4).length))].join('');
            document.getElementById("<%:Hidden1.ClientID%>").value = hidden;
        } else {
            hidden = hidden.replace("$" + click_value, "");
            document.getElementById("<%:Hidden1.ClientID%>").value = hidden;
        }
    }

</script>
</asp:Content>
