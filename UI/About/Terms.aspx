<%@ Page Title="GoTournamental - Terms And Conditions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Terms.aspx.cs" Inherits="GoTournamental.UI.Organiser.Terms" %>
<%@ Register TagPrefix="Navigation" TagName="AboutMenu" Src="~/UI/Menus/AboutMenu.ascx" %>
<%@ Register TagPrefix="Advertisements" TagName="AdvertPanel" Src="~/UI/Adverts/AdvertPanel.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="well">
	<Navigation:AboutMenu id="AboutMenuControl" runat="server" />	
    <br />
    <asp:Panel ID="TermsPanel" runat="server">
    						
    <div class="row">
        <div class="col-md-8">
            <h3>Terms And Conditions</h3>
            <p>
                <asp:Hyperlink ID="TermsAndConditionsLink" Text="Click Here" Target="_blank" runat="server" /> to read our Terms and Conditions<br />
                <asp:Panel ID="TermsSignatoryPanel" Visible="false" runat="server">
                    I have read and understand the Terms and Conditions and wish to create a tournament&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="TermsSigned" Width="15" Height="15" runat="server" />
                    <asp:Button ID="SaveTermsSigned" onClick="SaveTermsSigned_Click" Text="Save" runat="server" />
                </asp:Panel>
            </p>
        </div>
        <div class="col-md-4" style="text-align:right;">
            <Advertisements:AdvertPanel id="Advert300x250" runat="server" />
        </div>
    </div>
    					


    </asp:Panel>
    </div>
</asp:Content>
