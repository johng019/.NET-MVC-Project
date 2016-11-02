<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamBuilder.aspx.cs" Inherits="GolfSrambleWeb.TeamBuilder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Team Builder Form</title>
    <link rel="stylesheet" href="teamBuilder.css" type="text/css" />
    <script src="//code.jquery.com/jquery-1.11.0.min.js"></script>
    <script src="//code.jquery.com/ui/1.11.1/jquery-ui.min.js"></script>
    <script>
        
        var target;
        var source;
        var x;
        
        function allowDrop(ev) {
            //get and store the target listbox id
            ev.preventDefault();
            var x = event.clientX, y = event.clientY,
                elementMouseIsOver = document.elementFromPoint(x, y);
            target = elementMouseIsOver.id;
        }

        function drag(ev) {
            ev.dataTransfer.setData("text", ev.target.id);
        }

        function dragStart(ev) {
            //identify data from textbox and save in x 
            ev.dataTransfer.setData("text", ev.target.id);
            source = ev.dataTransfer.getData("text");
            x = document.getElementById(source).value;
        }

        function drop(ev) {
            ev.preventDefault();
            //opt necessary to add data to listbox
            var opt = document.createElement("option");
            document.getElementById(target).options.add(opt);
            opt.text = x;
            opt.value = x;
            //attempted to reset the selected index of the target listbox and   "click"
            var len = document.getElementById(target).length;
            document.getElementById(target).SelectedIndex = 0;
        }

    </script>

</head>
<body>
    <script type="text/javascript">
        function Button2_click() {
            document.getElementById("Button2").click();
        }
    </script>
    <form id="form1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div>
    
        Team Builder<br />
    
    </div>
    <div> 
        <asp:Label ID="Label2" runat="server" Text="Player Name"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" draggable ="true" ondragstart =" dragStart(event)" ondrop="drop(event)" ondragover ="allowDrop(event)"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add Player" />
        <br />
        <br />
        Player Level<br />
        A<asp:CheckBox ID="CheckBox1" runat="server" />
        B<asp:CheckBox ID="CheckBox2" runat="server" />
        C<asp:CheckBox ID="CheckBox3" runat="server" />
        <br />
        <br />
        Player A &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Player B&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Player C<br />
        <asp:ListBox ID="ListBox1" runat="server" Height="122px" Width="140px" style="margin-left: 0px" draggable="true" ondragstart="dragstart(event)" ondrop="drop(event)" ondragover="allowDrop(event)"></asp:ListBox>
        <asp:ListBox ID="ListBox2" runat="server" Height="122px" Width="129px" style="margin-top: 0px" draggable="true" ondragstart="dragstart(event)" ondrop="drop(event)" ondragover="allowDrop(event)"></asp:ListBox>
        <asp:ListBox ID="ListBox3" runat="server" Height="122px" Width="128px" draggable="true" ondragstart="dragstart(event)" ondrop="drop(event)" ondragover="allowDrop(event)"></asp:ListBox>   
        <p id ="p2" ondrop ="drop(event)" ondragover ="allowDrop"></p>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PlayersCtxtContext %>" SelectCommand="SELECT [Level], [FirstName], [LastName] FROM [Players] ORDER BY [Level], [LastName], [FirstName]"></asp:SqlDataSource>
        <center >
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" OnMouseDown ="ListView1_OnClick" AutoPostback ="true" style="margin-right: 71px;">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC; text-align:center;">
                    <td>
                        <asp:Label ID="LevelLabel" runat="server" Text='<%# Eval("Level") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="LevelTextBox" runat="server" Text='<%# Bind("Level") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="LevelTextBox" runat="server" Text='<%# Bind("Level") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="FirstNameTextBox" runat="server" Text='<%# Bind("FirstName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="LastNameTextBox" runat="server" Text='<%# Bind("LastName") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000; text-align:center; ">
                    <td>
                        <asp:Label ID="LevelLabel" runat="server" Text='<%# Eval("Level") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate >
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif; ">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server">Level</th>
                                    <th runat="server">FirstName</th>
                                    <th runat="server">LastName</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate >
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Label ID="LevelLabel" runat="server" Text='<%# Eval("Level") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        </center> 
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Compile Teams" ></asp:Label>
        <asp:HyperLink id="hyperlink1" 
                  NavigateUrl="~/DisplayTeams.aspx"
                  Text="Link"
                  runat="server"/> 
        <asp:Button ID="Button2" runat="server" Height="31px" Text="Compile" BorderStyle="None" BorderWidth="20px" Style="margin-left: 27px" Width="87px" OnClick="Button2_Click" />
        <br />
        <br />
        <asp:ListBox ID="ListBox4" runat="server" Height="185px" Width="495px"></asp:ListBox>
        <br />
        </div>
    </form>
</body>
</html>
