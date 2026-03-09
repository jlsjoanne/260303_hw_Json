<%@ Page Title="戲劇表演資訊" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TWShow.aspx.cs" Inherits="_260303_hw_Json.TWShow" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="UID" HeaderText="UID" />
                    <asp:BoundField DataField="title" HeaderText="Title" />

                    <asp:HyperLinkField DataNavigateUrlFields="webSales" HeaderText="售票連結" Text="Link" />
                    <asp:TemplateField HeaderText="演出時間">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">View Details</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                
            </asp:GridView>
            
        </div>
        <!-- source: https://data.gov.tw/dataset/6016-->
    </main>
</asp:Content>

