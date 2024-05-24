<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true" CodeBehind="UserEditDemand.aspx.cs" Inherits="Radar.User.UserEditDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="userID" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="demandID" runat="server" Visible="false"></asp:Label>
    <div style="background-image: url('../Image/bg4.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="ml-auto text-right">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="1000"></asp:Timer>
                        <asp:Label ID="lblTime" runat="server" Font-Bold="true"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <h3 class="text-center mt-3">Talep Düzenle</h3>

            <div class="col-md-6">
                <div class="col-md-12">
                    <label for="demandDate">Talep Tarihi</label>
                    <asp:TextBox ID="inputDemandDate" runat="server" CssClass="form-control" placeholder="demandDate" TextMode="Date" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="Amount">Tutar</label>
                    <asp:TextBox ID="inputAmount" runat="server" CssClass="form-control" placeholder="Tutar" TextMode="Number" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="companyName">Ýþletme Adý</label>
                    <asp:TextBox ID="inputCompanyName" runat="server" CssClass="form-control" placeholder="Ýþletme Adý" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="companyAddress">Ýþletme Adresi</label>
                    <asp:TextBox ID="inputCompanyAddress" runat="server" CssClass="form-control" placeholder="Ýþletme Adresi" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="demandDesc">Talep Açýklamasý</label>
                    <asp:TextBox ID="inputDemandDesc" runat="server" CssClass="form-control" placeholder="Talep Açýklamasý" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
                <div id="divDemandAdditional" runat="server" class="col-md-12">
                    <label for="inputDemandAdditional">Talep Ek Bilgi</label>
                    <asp:TextBox ID="inputDemandAdditional" runat="server" CssClass="form-control" placeholder="Talep Ek Bilgi" TextMode="SingleLine">
                    </asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-block" BackColor="#105d69" Text="Kaydet" OnClick="btnSave_Click" />
                </div>
            </div>

        </div>
    </div>


</asp:Content>
