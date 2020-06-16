// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function(){
  $(".AnimalPictureModal").click(function(){
    $("#exampleModal").modal();
  });
});

$('input[name="contentTable"]').bind('change',function(){
  $('#blogTable').toggle(($(this).val() == 'blog') ? true : false);
  $('#animalTable').toggle(($(this).val() == 'animal') ? true : false);
});