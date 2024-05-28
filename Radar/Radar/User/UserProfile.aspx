<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Radar.User.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="userID" runat="server" Visible="false"></asp:Label>
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
            <h3 class="text-center mt-3">Profil</h3>

            <div class="col-md-6">
                <div class="col-md-12">
                    <label for="identity">T.C Kimlik</label>
                    <asp:TextBox ID="identity" runat="server" CssClass="form-control" placeholder="T.C Kimlik" TextMode="SingleLine" ReadOnly="true" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="name">Ýsim</label>
                    <asp:TextBox ID="name" runat="server" CssClass="form-control" placeholder="Ýsim" TextMode="SingleLine" ReadOnly="true" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="surname">Soyisim</label>
                    <asp:TextBox ID="surname" runat="server" CssClass="form-control" placeholder="Soyisim" TextMode="SingleLine" ReadOnly="true" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="birthDate">Doðum Tarihi</label>
                    <asp:TextBox ID="inputbirthDate" runat="server" CssClass="form-control" placeholder="Doðum Tarihi" TextMode="Date" ReadOnly="true" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="eMail">E-Posta</label>
                    <asp:TextBox ID="eMail" runat="server" CssClass="form-control" placeholder="E-Posta" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="password">Þifre</label>
                    <asp:TextBox ID="password" runat="server" CssClass="form-control" placeholder="Þifre" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="mobileNumber">Telefon Numarasý</label>
                    <asp:TextBox ID="mobileNumber" runat="server" CssClass="form-control" placeholder="Telefon Numarasý" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="adress">Adress</label>
                    <asp:TextBox ID="adress" runat="server" CssClass="form-control" placeholder="Adress" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12 text-left mt-3">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" BackColor="#105d69" Text="Güncelle" OnClick="btnUpdate_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
