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