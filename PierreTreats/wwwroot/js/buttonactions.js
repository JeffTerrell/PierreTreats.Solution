$("#add-button").on("click", () => {
  $("#add-button-div").slideUp();
  $("#add-form-div").slideDown();
});

$("#stop-add-button").on("click", () => {
  $("#add-form-div").slideUp();
  $("#add-button-div").slideDown();
})

$("#edit-button").on("click", () => {
  $("#edit-button-div").slideUp();
  $("#edit-form-div").slideDown();
});

$("#stop-edit-button").on("click", () => {
  $("#edit-form-div").slideUp();
  $("#edit-button-div").slideDown();
});

$("#delete-button").on("click", () => {
  $("#delete-button-div").slideUp();
  $("#delete-confirm-div").slideDown();
});

$("#stop-delete-button").on("click", () => {
  $("#delete-confirm-div").slideUp();
  $("#delete-button-div").slideDown();
});