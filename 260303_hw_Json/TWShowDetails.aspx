<%@ Page Title="戲劇演出時間" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TWShowDetails.aspx.cs" Inherits="_260303_hw_Json.TWShowDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="time" HeaderText="Time" />
                    <asp:BoundField DataField="location" HeaderText="Location" />
                    <asp:BoundField DataField="locationName" HeaderText="Location Name" />
                </Columns>
                
            </asp:GridView>
        </div>
    </main>
</asp:Content>

