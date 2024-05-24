<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true" CodeBehind="CreateDemand.aspx.cs" Inherits="Radar.User.CreateDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function checkDate(input) {
            var selectedDate = new Date(input.value);
            var currentDate = new Date();
            if (selectedDate > currentDate) {
                alert("Gelecek bir tarih seçemezsiniz!");
                // İleri bir tarih seçilmemesi için input değerini boşaltabilirsiniz
                input.value = '';
            }
        }
    </script>
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
            <h3 class="text-center mt-3">Talep Oluştur</h3>

            <div class="col-md-6">
                <div class="col-md-12">
                    <label for="demandDate">Talep Tarihi</label>
                    <asp:TextBox ID="inputDemandDate" runat="server" CssClass="form-control" placeholder="demandDate" oninput="checkDate(this)" TextMode="Date" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="Amount">Tutar</label>
                    <asp:TextBox ID="inputAmount" runat="server" CssClass="form-control" placeholder="Tutar" TextMode="Number" step="0.01" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="companyName">İşletme Adı</label>
                    <asp:TextBox ID="inputCompanyName" runat="server" CssClass="form-control" placeholder="İşletme Adı" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="companyAddress">İşletme Adresi</label>
                    <asp:TextBox ID="inputCompanyAddress" runat="server" CssClass="form-control" placeholder="İşletme Adresi" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
                <div class="col-md-12">
                    <label for="demandDesc">Talep Açıklaması</label>
                    <asp:TextBox ID="inputDemandDesc" runat="server" CssClass="form-control" placeholder="Talep Açıklaması" TextMode="SingleLine" required>
                    </asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnCreateDemand" runat="server" CssClass="btn btn-primary btn-block" BackColor="#105d69" Text="Talep Oluştur" OnClick="btnCreateDemand_Click" />
                </div>
            </div>

        </div>
    </div>


</asp:Content>

