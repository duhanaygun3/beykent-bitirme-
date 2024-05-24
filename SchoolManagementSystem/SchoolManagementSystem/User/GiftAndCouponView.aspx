<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true" CodeBehind="GiftAndCouponView.aspx.cs" Inherits="Radar.User.GiftAndCouponView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="userID" runat="server" Visible="false"></asp:Label>
    <div style="background-image: url('../Image/bg4.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container p-md-4 p-sm-4">
            <h3 class="text-center mt-3">Hediye Kuponu Çek Listesi</h3>
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-6">
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="Görüntülenecek Hediye Kuponu/Çek bulunmamaktadýr."
                        AutoGenerateColumns="False" AllowPaging="True" PageSize="4" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="ID">
                        <Columns>
                            <asp:TemplateField HeaderText="Hediye Kuponu/Çek Numarasý">
                                <ItemTemplate>
                                    <asp:Label ID="lblGiftID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Talep Numarasý">
                                <ItemTemplate>
                                    <asp:Label ID="lblDemandID" runat="server" Text='<%# Eval("DemandId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tutar">
                                <ItemTemplate>
                                    <asp:Label ID="lblGiftAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Kupon Oluþma Tarihi">
                                <ItemTemplate>
                                    <asp:Label ID="lblGiftDate" runat="server" Text='<%# Eval("CreationDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Geçerli Þirket Adý">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <HeaderStyle BackColor="#105d69" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

