﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="HLP.Inicio" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

<!DOCTYPE html>
          <head>
        <title>Bootstrap Example</title>
               <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        
        <style>
             .carousel-inner > .item > img,
            .carousel-inner > .item > a > img {
                width: 70%;
                margin: auto;
            }
             </style>
    </head>
    <body>
        <h1 class="text-center" style="width: auto; height: auto; top: auto; right: auto; bottom: auto; left: auto">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; HOSPITAL PARENSE</h1>
        <div class="container">
            <br>
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                 <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                    <li data-target="#myCarousel" data-slide-to="3"></li>
                </ol>
                 <!-- Wrapper for slides -->
                <div class="carousel-inner" role="listbox">
                    <div class="item active">
                        <img src="images/imagen3.jpg" alt="Chania" width="460" height="345">
                    </div>

                    <div class="item">
                        <img src="images/imagen1.jpg" alt="Chania" width="460" height="345">
                    </div>

                    <div class="item">
                        <img src="images/imagen2.jpg" alt="Flower" width="460" height="345">
                    </div>

                    <div class="item">
                        <img src="images/imagen4.jpg" alt="Flower" width="460" height="345">
                    </div>
                </div>
                 <!-- Left and right controls -->
                <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>

        
    </body>
   
</asp:Content>


