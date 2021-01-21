$(document).ready(function () {
  $('.select2').select2();

  $("#btnGetPhotos").click(function () {
    var albumId = $("#album-list").val();

    if (albumId != "" && albumId != 0){
      $("#photoTable").load("/Home/PhotoTable/" + albumId);
    }

  });

});

function getComments(photoId) {
    $("#commentList").load("/Home/CommentList/" + photoId);
    $('html, body').animate({ scrollTop: $('#commentList').offset().top }, 'slow');
  }