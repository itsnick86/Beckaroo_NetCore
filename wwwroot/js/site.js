// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function(){

  //Provides modal functionality on the Zoo page
  $(".AnimalPictureModal").click(function(){
    $("#exampleModal").modal();
  });

  //Initializes the Tiny Cloud Rich Text Editor for any Text Areas with the specified class
  tinymce.init({
    selector: '.richtextarea'
    });
});