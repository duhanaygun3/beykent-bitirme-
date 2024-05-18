﻿<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true" CodeBehind="StudentAttendance.aspx.cs" Inherits="SchoolManagementSystem.User.StudentAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                   <asp:TextBox ID="demandDate" runat="server" CssClass="form-control" placeholder="demandDate" TextMode="Date" required>
              </asp:TextBox>
             </div>
                  <div class="col-md-12">
                            <label for="Amount">Tutar</label>
                           <asp:TextBox ID="Amount" runat="server" CssClass="form-control" placeholder="Tutar" TextMode="Number" required>
                           </asp:TextBox>
                         </div>
                  <div class="col-md-12">
          <label for="companyName">İşletme Adı</label>
         <asp:TextBox ID="companyName" runat="server" CssClass="form-control" placeholder="İşletme Adı" TextMode="SingleLine" required>
         </asp:TextBox>
       </div>
                  <div class="col-md-12">
   <label for="companyAddress">İşletme Adresi</label>
  <asp:TextBox ID="companyAddress" runat="server" CssClass="form-control" placeholder="İşletme Adresi" TextMode="SingleLine" required>
  </asp:TextBox>
</div>
                  <div class="col-md-12">
   <label for="demandDesc">Talep Açıklaması</label>
  <asp:TextBox ID="demandDesc" runat="server" CssClass="form-control" placeholder="Talep Açıklaması" TextMode="SingleLine" required>
  </asp:TextBox>
</div>
               </div>
            </div>
        <div class="col-md-6">        
            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnCreateDemand" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Talep Oluştur" OnClick="btnSubmit_Click" />
                </div>
            </div>

        </div>
</div>


</asp:Content>
