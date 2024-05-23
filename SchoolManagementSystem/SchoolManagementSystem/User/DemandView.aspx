﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true" CodeBehind="DemandView.aspx.cs" Inherits="SchoolManagementSystem.User.DemandView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="userID" runat="server" Visible="false"></asp:Label>
    <div style="background-image: url('../Image/bg4.jpg'); width: 100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed;">
        <div class="container p-md-4 p-sm-4">
            <h3 class="text-center mt-3">Talep Görüntüle</h3>
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                 <div class="col-md-6">
                     <input id="filterCompanyName" type="text" placeholder="Şirket Adı" runat="server" autofocus="" class="form-control rounded-pill border-0 shadow-sm px-4" />
                     <asp:Button ID="btnCompanyNameFilter" runat="server" CssClass="btn btn-primary btn-block" BackColor="#007F00" Text="Filtrele" OnClick="btnCompanyNameFilter_Click"/>
                     <asp:Button ID="btnAllDemands" runat="server" CssClass="btn btn-primary btn-block" BackColor="#007F00" Text="Tüm Talepleri Listele" OnClick="btnAllDemands_Click"/>
 </div>
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="Görüntülenecek talebiniz bulunmamaktadır."
                        AutoGenerateColumns="False" AllowPaging="True" PageSize="4" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="DemandId">
                        <Columns>
                            <asp:TemplateField HeaderText="Talep Numarası">
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

                            <asp:TemplateField HeaderText="Şirket">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyName" runat="server" Text='<%# Eval("CompanyName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Şirket Adresi">
                                <ItemTemplate>
                                    <asp:Label ID="lblCompanyAdress" runat="server" Text='<%# Eval("CompanyAdress") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talep Açıklaması">
                                <ItemTemplate>
                                    <asp:Label ID="lblDemandDesc" runat="server" Text='<%# Eval("DemandDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Talep Durumu">
                                <ItemTemplate>
                                    <asp:Label ID="lblDemandDesc" runat="server" Text='<%# Eval("StatusDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <HeaderStyle BackColor="#007F00" ForeColor="White" />
                    </asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

