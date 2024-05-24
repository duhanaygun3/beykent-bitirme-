<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="Radar.User.UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="userID" runat="server" Visible="false"></asp:Label>
    <div style="background-image: url('../Image/bg3.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h2 class="text-center">Kullanıcı Paneli</h2>
            <!-- İlk blok -->
            <div class="container mt-5">
                <div class="row">
                    <div class="col-md-4">
                        <!-- Burada veri gösterebileceğiniz içerik alanı -->
                        <div style="background-color: #f0f0f0; padding: 20px; border: 1px solid #ddd;">
                            <div class="col-md-12">
                                <label for="totalUser">Kullanıcı Sayısı</label>
                                <asp:Label ID="inputTotalUser" runat="server" CssClass="form-control" placeholder="" TextMode="SingleLine" >
                                </asp:Label>
                            </div>
                        </div>
                    </div>
                    <!-- İkinci blok -->
                    <div class="col-md-4">
                        <!-- Burada veri gösterebileceğiniz içerik alanı -->
                        <div style="background-color: #f0f0f0; padding: 20px; border: 1px solid #ddd;">
                            <div class="col-md-12">
                                <label for="totalRadarConfirmDemand">Toplam Çözülen Talep Adeti</label>
                                <asp:Label ID="inputTotalRadarConfirmDemand" runat="server" CssClass="form-control" placeholder="" TextMode="SingleLine" >
                                </asp:Label>
                            </div>
                        </div>
                    </div>
                    <!-- Üçüncü blok -->
                    <div class="col-md-4">
                        <!-- Burada veri gösterebileceğiniz içerik alanı -->
                        <div style="background-color: #f0f0f0; padding: 20px; border: 1px solid #ddd;">
                            <div class="col-md-12">
                                <label for="userOpenDemandCount">Açık Taleplerim</label>
                                <asp:Label ID="inputUserOpenDemandCount" runat="server" CssClass="form-control" placeholder="" TextMode="SingleLine" >
                                </asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
