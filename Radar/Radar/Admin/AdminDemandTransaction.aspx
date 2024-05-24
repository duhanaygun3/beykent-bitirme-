<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="AdminDemandTransaction.aspx.cs" Inherits="Radar.Admin.AdminDemandTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="userID" runat="server" Visible="false"></asp:Label>
    <div style="background-image: url('../Image/bg4.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container p-md-4 p-sm-4">
            <h3 class="text-center mt-3">Talep Ýþlem</h3>
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-6">
                    <input id="filterCompanyName" type="text" placeholder="Þirket Adý" runat="server" autofocus="" class="form-control rounded-pill border-0 shadow-sm px-4" />
                    <asp:Button ID="btnCompanyNameFilter" runat="server" CssClass="btn btn-primary btn-block" BackColor="#105d69" Text="Filtrele" OnClick="btnCompanyNameFilter_Click" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="Görüntülenecek talep bulunmamaktadýr."
                        AutoGenerateColumns="False" AllowPaging="True" PageSize="4" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="DemandId" OnRowCommand="GridView1_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Talep Numarasý">
                                <ItemTemplate>
                                    <asp:Label ID="lblDemandID" runat="server" Text='<%# Eval("DemandId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Talep Tarihi">
                                <ItemTemplate>
                                    <asp:Label ID="lblDemandDate" runat="server" Text='<%# Eval("DemandDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Tutar">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Þirket">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Þirket Adresi">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyAdress" runat="server" Text='<%# Eval("CompanyAdress") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talep Açýklamasý">
                                <ItemTemplate>
                                    <asp:Label ID="lblDemandDesc" runat="server" Text='<%# Eval("DemandDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talep Durumu">
                                <ItemTemplate>
                                    <asp:Label ID="lblDemandStatus" runat="server" Text='<%# Eval("StatusDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talep Ýnceleniyor">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Talep Ýnceleniyor" CommandName="DemandReview" CommandArgument='<%# Container.DataItemIndex %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talep Onayla">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Talep Onayla" CommandName="DemandApproval" CommandArgument='<%# Container.DataItemIndex %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talep Red">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Talep Red" CommandName="DemandRejection" CommandArgument='<%# Container.DataItemIndex %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talep Ek Bilgi">
                                <ItemTemplate>
                                    <asp:Button runat="server" Text="Talep Ek Bilgi" CommandName="DemandAdditional" CommandArgument='<%# Container.DataItemIndex %>' />
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

