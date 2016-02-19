$(function () {
    // Set 'Select All' to checked if all other boxes are already checked
    $('#selectAll').prop('checked', $('.check').length == $('.check:checked').length);

    // Add click function to 'Select All' to select all other boxes
    $('#selectAll').click(function () {
        $('.check').prop('checked', this.checked);
    });

    // Add click function to each child checkbox
    $('.check').click(function () {
        $('#selectAll').prop('checked', $('.check').length == $('.check:checked').length);
    });
})