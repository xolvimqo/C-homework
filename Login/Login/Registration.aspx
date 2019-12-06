<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Login.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body> 
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <p>This is Registration page</p>

    <form id="form1" runat="server"> 
        <div> 
            <table class="auto-style1"> 
                <tr> 
                    <td>Name :</td> 
                    <td> 
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox> 
                    </td> 
                    <td> 
                        <asp:Button ID="btnSubmit" runat="server" Text="SUBMIT" OnClick="btnSubmit_Click" /> 
                    </td>
 
               </tr> 
               
              
            </table> 
        </div>

       

         <br />
    <br /><br /><br />
        <asp:GridView ID="GridView2"
            OnRowCommand="GridView2_RowCommand" OnRowEditing="GridView2_RowEditing"
            OnRowCancelingEdit="GridView2_RowCancelingEdit" OnRowUpdating="GridView2_RowUpdating"
            OnRowDeleting="GridView2_RowDeleting"
        
            runat="server" DataKeyNames="Id" CellPadding="4" AutoGenerateColumns="False" ShowFooter="True" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle ForeColor="#333333" BackColor="#FFFBD6" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />

            <AlternatingRowStyle BackColor="White" />

            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label Text='<%#Eval("Name")%>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName"  Text='<%#Eval("Name")%>' runat="server"/>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtFooterName"  runat="server"/>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/pencilEdit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Images/Delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="UPdate" ToolTip="Update" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label id="lblSuccessMsg" Text="" runat="server" ForeColor="Green" />
        <br />
        <br />
        <asp:Label id="lblErrorMsg" Text="" runat="server" ForeColor="Red" />
    </form> 
</body> 
</html>
