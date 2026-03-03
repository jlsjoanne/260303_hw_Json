<%@ Page Title="Json Converter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JsonConverter.aspx.cs" Inherits="_260303_hw_Json.JsonConverter" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <h2>JSON轉換練習</h2>
        <h4>物件 to Json</h4>
        <div>
            <p>姓名: <asp:TextBox ID="nameInput" runat="server"></asp:TextBox>
            </p>
            <p>年齡: <asp:TextBox ID="ageInput" runat="server"></asp:TextBox>
            </p>
            <asp:Button ID="Button1" runat="server" Text="轉成Json" OnClick="Button1_Click" />
            <p>
                <asp:Label ID="convertToJson" runat="server" ForeColor="Blue"></asp:Label>
            </p>
        </div>
        <h4>Json to 物件</h4>
        <div>
            <p>輸入JSON字串</p>
            <div>
                <asp:TextBox ID="jsonInput" runat="server" TextMode ="MultiLine" Width ="300px" Height="100px"></asp:TextBox>
                
            </div>
            <asp:Button ID="Button2" runat="server" Text="還原成物件" OnClick="Button2_Click" />
            <p>
                <asp:Label ID="convertToProperties" runat="server" ForeColor="Green"></asp:Label>
            </p>
        </div>
    </main>
</asp:Content>
